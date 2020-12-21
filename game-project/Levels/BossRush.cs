using game_project.ECS;
using game_project.GameObjects.Link;
using game_project.Sounds;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using static game_project.GameObjects.Items.ItemInventory;

namespace game_project.Levels
{
    // Handles the "Boss Rush", which is basically levels of increasing difficulty.
    // When this class is instantiated, essentially takes control away from rest of level code
    public class BossRush
    {
        // Because this is infinite, we should not generate all levels at beginning 
        private const int STARTING_LEVEL_Y = 5000;
        public static int CurrentLevel { get; set; }
        public BossRush()
        {
            // Change overall game state; used to do dynamic generation in the future
            // Not done with normal game state b/c that screws up more
            Game1.inBossRush = true;
            LevelManager.backdrop.Minimap.Disappear();
            CurrentLevel = 0; // set to zero in case of reset

            Entity.Destroy(Scene.Find("Link")); // Bye, Link! No hard feelings, we just need to recreate you elsewhere; it's easier this way.          
            LevelManager.initial = true; // Flag it such that the game initializes Link to the new position when we run LevelManager.Load()
            LevelManager.cache.Clear(); // Clear cache, cause why not 

            // Load our starting level (a point that will never cross the existing one)
            // (note that genLevel returns immediately if it already exists in cache)
            GenLevel(6, STARTING_LEVEL_Y);
            LevelManager.Load("6_" + STARTING_LEVEL_Y.ToString());

            // Let Link hold more bombs than usual, then start him at zero
            LevelManager.link.GetComponent<LinkInventory>().useInventory[(int)UseInventory.BOMB].amount.SetMax(25);
            LevelManager.link.GetComponent<LinkInventory>().useInventory[(int)UseInventory.BOMB].amount.current = 2;
            Sound.PlayTrack(Sound.Tracks.BlackMist);
        }

        // Generates a new level in the given direction
        // CALLING CONVENTION: Can be called on a level that is already in the cache
        // A call to this represents "if this level hasn't been generated yet, do so. Handle it correctly if it hasn't been"
        public static void GenLevel(int x, int y)
        {
            // If it's already in cache, ignore this call 
            if (LevelManager.cache.ContainsKey(x + "_" + y))
            {
                return;
            }

            // Otherwise, generate via our random generation mechanism and place in cache
            Level gen = GenRandomLevel(x + "_" + y, Math.Abs(y - STARTING_LEVEL_Y) + 1);
            LevelManager.cache.Add(x + "_" + y, gen);
            LevelManager.currentLevel = gen;
            CurrentLevel++;
          
            // It's a fresh level, so give the player two more bombs
            LevelManager.link.GetComponent<LinkInventory>().useInventory[(int)UseInventory.BOMB].amount.AddCurrent(2);

        }

        // Creates a random instance of a level
        // Difficulty is somewhat arbitrary but each point of difficulty will add six difficulty points. Most enemies will add one; bosses will add six.
        // The progression will be like 1, 1, 2, 2, 3, 3, 4, 4, and so on until the player dies.
        // Each type of enemy takes up an amount of those points proportional to their difficulty. 
        // 2.0 = Easy (two enemy points; shouldn't be a challenge)
        // 4.0 = Medium (four enemy points); might be a bit of a challenge)
        // 6.0 = Hard (six enemy points; should be a challenge. Can also be interspersed
        static readonly Dictionary<string, int> enemyPoints = new Dictionary<string, int>()
        {
            { "aquamentus", 6 },
            // { "bladetrap", 1} // Blade trap is exempt b/c unkillable
            { "gel", 1 },
            { "goriya", 1 },
            { "keese", 1 },
            { "stalfo", 1 },
            { "wallmaster", 2 }
        };
        static readonly string[] enemies = { "aquamentus", "gel", "goriya", "keese", "stalfo", "wallmaster" };

        // No need to save to disk; we just stick it in the cache
        public static Level GenRandomLevel(string name, int enemyPointsLeft)
        {
            // Used throughout function
            var split = name.Split('_');
            int x = Int16.Parse(split[0]);
            int y = Int16.Parse(split[1]);

            // Pick out random enemies and deduct points until we have a full list 
            Random random = new Random();
            List<string> levelEnemies = new List<string>();
            while (enemyPointsLeft > 0)
            {
                string enemy = enemies[random.Next(0, enemies.Length)];
                if (enemyPoints[enemy] <= enemyPointsLeft)
                {
                    // If it's an aquamentus, gift link 5 bombs
                    if (enemy.Equals("aquamentus"))
                    {
                        LevelManager.link.GetComponent<LinkInventory>().useInventory[(int)UseInventory.BOMB].amount.AddCurrent(5);
                    }                    

                    levelEnemies.Add(enemy);
                    enemyPointsLeft -= enemyPoints[enemy];
                }
            }

            // Generate a random position for each of the enemies 
            // Maps are 12 wide, 7 tall
            List<Vector2> levelEnemyPositions = new List<Vector2>();
            const int horizGridLength = 12, vertGridLength = 7;
            for (int i = 0; i < levelEnemies.Count; i++)
            {
                // Coords are brought in a bit from the edges to avoid weird edge cases with spawning in walls
                float xPos = random.Next(3, horizGridLength - 3);
                float yPos = random.Next(3, vertGridLength - 3);
                levelEnemyPositions.Add(new Vector2(xPos, yPos));
            }

            // Generate the actual line we feed into the Level class
            List<string[]> lines = new List<string[]>();
            string[] walls = { "block", "0.0", "0.0", "0.0", "0.0", "wall", "walls" }; lines.Add(walls); // Hardcode walls 
            string[] empty = { "block", "2", "2", "0", "0", "none", "empty" }; lines.Add(empty);
            string[] topDoor = { "block", "7", "0", "0", "0", "door", "uplock" }; lines.Add(topDoor); // Hardcode top door
            // Hardcode bottom wall iff it's the bottommost room
            if (Math.Abs(y - STARTING_LEVEL_Y) > 0)
            {
                string[] bottomDoor = { "block", "7", "9", "0.0", "0.0", "door", "downdoor" }; 
                lines.Add(bottomDoor); // give bottom a door
            }
            else
            {
                string[] bottomWall = { "block", "7", "9", "0", "0", "wall", "downwall" }; 
                lines.Add(bottomWall); // Hardcode bottom wall
            }
            string[] leftWall = { "block", "0", "4.5", "0", "0", "wall", "leftwall" }; lines.Add(leftWall); // Hardcode left wall 
            string[] rightWall = { "block", "14", "4.5", "0", "0", "wall", "rightwall" }; lines.Add(rightWall); // Hardcode right wall

            for (int i = 0; i < levelEnemies.Count; i++)
            {
                string[] line = { "enemy", levelEnemyPositions[i].X.ToString(), levelEnemyPositions[i].Y.ToString(), "0.0", "0.0", levelEnemies[i], "", "" };
                lines.Add(line);
            }

            return new Level(name, lines);
        }
    }
}
