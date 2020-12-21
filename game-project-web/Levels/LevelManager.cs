using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.GUI;
using game_project.GameObjects.Layout;
using game_project.GameObjects.Link;
using game_project.GameObjects.Projectiles;
using game_project.GameObjects.Writing;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using Bridge.Utils;

namespace game_project.Levels
{
    public static class LevelManager
    {
        // Game layer
        public static LevelParent mapRoot;
        public static Dictionary<string, Level> cache;
        private static bool initial;
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

        static LevelManager()
        {
            //Init();
        }

        public static void Init()
        {
            Console.Log("Init()");
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
            retryDialog.State = EntityStates.Disabled;

            // UI Backdrop
            backdrop = new Backdrop();
            Scene.Add(backdrop);
            var backdropTransform = backdrop.GetComponent<Transform>();
            backdropTransform.AddChild(mapRoot);
        }

        public static void Load(string name, bool useCache = true)
        {
            Console.Log("LevelManager.Load()");
            if (cache.ContainsKey(name) && useCache)
            {
                Debug.WriteLine("loading from cache: " + name);
                currentLevel = cache[name];
                currentLevelPath = name;

                // Un-Pause the Level you are entering
                currentLevel.Root.State = EntityStates.Playing;

                Scene.ClearLayer(Scene.Layers.Projectile);
            }
            else
            {
                Level level;
                Debug.WriteLine("loading from disk: " + name);
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
                    Console.Log("initial level");
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
            LevelManager.mapRoot.State = EntityStates.Paused;
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

            // 


            // Load the entrance Level
            Load("2_5", false);
        }
    }
}
