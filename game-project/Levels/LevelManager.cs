using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Enemy;
using game_project.GameObjects.GUI;
using game_project.GameObjects.Items;
using game_project.GameObjects.Layout;
using game_project.GameObjects.Link;
using game_project.GameObjects.Writing;
using game_project.Sounds;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace game_project.Levels
{
    public static class LevelManager
    {
        // Game layer
        public static LevelParent mapRoot;
        public static Dictionary<string, Level> cache;
        public static bool initial; // Needs to be public; BossRush code modifies it 
        public static string currentLevelPath = "2_5";
        public static Level currentLevel;
        public static Level previousLevel;

        // UI layer
        public static Backdrop backdrop;
        public static TextShadowEntity pausedText;
        public static TextShadowEntity deadText;
        public static TextShadowEntity winText;
        public static RetryDialog retryDialog;

        // Player layer
        public static Link link;

        // Debug
        public static bool showFPS;

        static LevelManager()
        {
            //Init();
        }

        public static void Init()
        {
            // Game Layer
            mapRoot = new LevelParent();
            cache = new Dictionary<string, Level>();
            initial = true;
            //currentLevelPath = null;
            currentLevel = null;
            previousLevel = currentLevel;

            // UI Layer
            pausedText = new TextShadowEntity(new Vector2(340, 540), "Paused", Color.White);
            pausedText.State = EntityStates.Disabled;

            deadText = new TextShadowEntity(new Vector2(340, 540), "Defeat", Color.White);
            deadText.State = EntityStates.Disabled;

            winText = new TextShadowEntity(new Vector2(340, 540), "Victory", Color.White);
            winText.State = EntityStates.Disabled;

            retryDialog = new RetryDialog();
            //retryDialog.State = EntityStates.Disabled;

            // UI Backdrop
            backdrop = new Backdrop();
            Scene.Add(backdrop);
            var backdropTransform = backdrop.GetComponent<Transform>();
            backdropTransform.AddChild(mapRoot);

            // Debug
            showFPS = false;
        }

        // Called at every point in the code at which an enemy is killed
        // Controls the "give the player a key when they kill all enemies in a room" 
        public static void EnemyKilled()
        {
            currentLevel.numEnemiesLeft--;

            // If this takes us down to zero, gift the player a key, which they can use to unlock the given door
            if (Game1.inBossRush && currentLevel.numEnemiesLeft == 0)
            {
                LinkInventory inventory = link.GetComponent<LinkInventory>();
                inventory.AddDungeonItem((int)ItemInventory.DungeonInventory.KEYS);

                // change the sprite of the door
            }
            else if (currentLevel.DropKey && currentLevel.numEnemiesLeft == 0)
            {
                Item.CreateKey(currentLevel.KeyPos);
            }

            if (currentLevel.numEnemiesLeft < 0)
            {
                Console.WriteLine("ERROR: EnemyKilled() called in a room with 0 enemies in it!");
            }
        }

        public static void FreezeAllEnemies()
        {
            foreach (Enemy enemy in currentLevel.enemyList)
            {
                enemy.frozen = true;
            }
        }

        public static void Load(string name, bool useCache = true)
        {
            //LevelManager.mapRoot.State = EntityStates.Disabled;

            // If we are in boss rush, generate using custom random gen function
            // Note that this function returns immediately if already in cache, 
            // and places the new one in cache if it does not already exist
            if (Game1.inBossRush)
            {
                var split = name.Split('_');
                int x = Int16.Parse(split[0]);
                int y = Int16.Parse(split[1]);
                BossRush.GenLevel(x, y);
            }

            // If in boss rush, will always go in here because we just generated.
            // Otherwise, in normal gameplay mode, treats normally.
            if (cache.ContainsKey(name) && useCache)
            {
                Debug.WriteLine("Loading from cache: " + name);
                currentLevel = cache[name];
                currentLevelPath = name;
                Level level = cache[name];
                mapRoot.GetComponent<Transform>().AddChild(level.Root);

                // Un-Pause the Level you are entering
                currentLevel.Root.State = EntityStates.Playing;

                Scene.ClearLayer(Scene.Layers.Projectile);

                // If this is the first room loaded, add Link and adjust the "camera"
                // Will only get here if it's first level of boss rush, don't worry
                if (initial)
                {
                    link = level.LoadPlayer(currentLevel.Root.GetComponent<Transform>().position + new Vector2(480, 700));
                    Scene.Add(link);
                    mapRoot.GetComponent<Transform>().AddChild(link);
                    initial = false;
                    mapRoot.GetComponent<Transform>().position = -1 * currentLevel.Root.GetComponent<Transform>().position;
                    // I do not know why this needs to happen, but it does. Further investigation needed
                    // -Matt
                    mapRoot.GetComponent<Transform>().position.Y += Level.screen_height;
                    previousLevel = currentLevel;
                }
            }
            else
            {
                //LevelManager.mapRoot.State = EntityStates.Playing;
                Debug.WriteLine("Loading from disk: " + name);
                Level level;
                level = new Level(name);
                currentLevelPath = name;
                // add that parent to the root of the map
                mapRoot.GetComponent<Transform>().AddChild(level.Root);
                currentLevel = level;
                cache.Add(name, currentLevel);

                // Un-Pause the Level you are entering
                currentLevel.Root.State = EntityStates.Playing;
                Scene.ClearLayer(Scene.Layers.Projectile);

                // If this is the first room loaded, add Link and adjust the "camera"
                if (initial)
                {
                    link = level.LoadPlayer(currentLevel.Root.GetComponent<Transform>().position + new Vector2(480, 700));
                    Scene.Add(link);
                    mapRoot.GetComponent<Transform>().AddChild(link);
                    initial = false;
                    mapRoot.GetComponent<Transform>().position = -1 * currentLevel.Root.GetComponent<Transform>().position;
                    // I do not know why this needs to happen, but it does. Further investigation needed
                    // -Matt
                    mapRoot.GetComponent<Transform>().position.Y += Level.screen_height / 1;
                    previousLevel = currentLevel;
                }
            }
        }

        public static void Defeat()
        {
            deadText.State = EntityStates.Playing;
            mapRoot.State = EntityStates.Paused;
            GameStateManager.State = GameStates.Defeat;

            // Show the "Retry?" dialog
            //retryDialog.State = EntityStates.Playing;
            retryDialog.Show();
        }

        public static void Victory()
        {
            winText.State = EntityStates.Playing;
            GameStateManager.State = GameStates.Victory;
            mapRoot.State = EntityStates.Paused;
        }

        public static void Reset()
        {

            // Hide all text
            retryDialog.State = EntityStates.Disabled;
            pausedText.State = EntityStates.Disabled;
            deadText.State = EntityStates.Disabled;

            // delete all Entities and Components (keep content loaded)
            while (Scene.entities.Count > 0)
            {
                var e = Scene.entities[0];
                Entity.Destroy(e);
            }

            // Clear manager variables
            Entity.Destroy(mapRoot);
            cache.Clear();
            Init();
            Game1.inBossRush = false;

            // Load the entrance Level
            Load(Constants.STARTING_LEVEL, false);
        }
    }
}
