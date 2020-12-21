using game_project.Controllers;
using game_project.ECS;
using game_project.ECS.Systems;
using game_project.Levels;
using game_project.Sounds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace game_project
{

    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphics;
        public static Viewport viewport;
        SpriteBatch spriteBatch;

        KeyboardController keyboard;

        // Required to exit from other folders
        public static Game1 self;

        // We save the instance here so that we don't lose the
        // reference and it gets picked up by the garbage collector
        public static BossRush bossRush;
        public static bool inBossRush = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = Constants.SCREEN_PREFERRED_WIDTH_PX,
                PreferredBackBufferHeight = Constants.SCREEN_PREFERRED_HEIGHT_PX
            };
            //graphics.SynchronizeWithVerticalRetrace = false;
            //IsFixedTimeStep = false;
            IsMouseVisible = true;
            graphics.ApplyChanges();
#if WEB
#else
            Window.Position = Constants.SCREEN_WINDOW_ORIGIN;
#endif
            viewport = graphics.GraphicsDevice.Viewport;
            Content.RootDirectory = "Content";
            self = this;
        }

        protected override void Initialize()
        {
            keyboard = new KeyboardController();
            ColliderSystem.DrawDebug = false;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            LoadStuff();
        }
        private async void LoadStuff()
        {
#if WEB
            await GameContent.InitAsync(Content, GraphicsDevice);
#else
            GameContent.Init(Content, GraphicsDevice);
#endif
            string initialPath = Constants.STARTING_LEVEL;
            LevelManager.Load(initialPath);
            Sound.PlayTrack(Sound.Tracks.Underworld);
        }

        protected override void UnloadContent()
        {
            Content.Unload();

            // We need to clear all our components to reset state; If the program is reset they will be created fresh by the new Link() instance
            TransformSystem.Clear();
            ColliderSystem.Clear();
            BehaviorScriptSystem.Clear();
            SpriteSystem.Clear();
            TextSystem.Clear();

            Scene.Clear();
        }


        protected override void Update(GameTime gameTime)
        {
            if (!GameContent.IsLoaded)
            {
                base.Update(gameTime);
                return;
            }

            // Update KeyboardController for Commands
            keyboard.Update();

            Input.GetState();

            // Game implemented using Entity-Component-System,
            // Systems store instances of certain types of Components
            TransformSystem.Update(gameTime);
            BehaviorScriptSystem.Update(gameTime);
            ColliderSystem.Update(gameTime);
            ColliderSystem.Check();
            SpriteSystem.Update(gameTime);
            TextSystem.Update(gameTime);
            Sound.Update(gameTime);

            base.Update(gameTime);
        }

        int frame = 0;
        int frameCounter = 0;
        int _lastTime = 0;

        protected override void Draw(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Seconds > _lastTime)
            {
                _lastTime = gameTime.TotalGameTime.Seconds;
                frame = frameCounter;
                frameCounter = 0;
            }
            frameCounter++;


            if (!GameContent.IsLoaded)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                if (GameContent.IsBaseLoaded)
                {
                    var size = GameContent.Font.hudFont.MeasureString("Click on game area to start it!");

                    spriteBatch.Begin();

                    if (!GameContent.IsLoaded)
                    {
                        spriteBatch.DrawString(GameContent.Font.hudFont,
                            "Zelda is loading: " + GameContent.Counter + " / " + GameContent.Max,
                            new Vector2(20, 440 - size.Y - 10),
                            Color.White,
                            0f,
                            Vector2.Zero,
                            .5f,
                            SpriteEffects.None,
                            1f);
                        //spriteBatch.Draw(GameContent.Texture.Pixel, new Rectangle(20, 440, (int)(760 * (GameContent.Counter / (float)GameContent.Max)), 20), Color.White);
                    }

                    spriteBatch.End();
                }

                base.Draw(gameTime);
                return;
            }

            GraphicsDevice.Clear(Color.IndianRed);

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp);

            SpriteSystem.Draw(spriteBatch); // Draw all Sprite components
            ColliderSystem.Draw(spriteBatch); // Draw all Collider debug boxes
            TextSystem.Draw(spriteBatch); // Draw all Text components

            if (LevelManager.showFPS)
            {
                DrawShadowedString(GameContent.Font.hudFont, "FPS: " + frame, new Vector2(440f, 20f), Color.Yellow);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawShadowedString(SpriteFont font, string value, Vector2 position, Color color)
        {
            spriteBatch.DrawString(font, value, position + new Vector2(1.0f, 1.0f), Color.Black, 0, Vector2.Zero, .3f, SpriteEffects.None, .99f);
            spriteBatch.DrawString(font, value, position, color, 0, Vector2.Zero, .3f, SpriteEffects.None, 1f);

        }
    }
}
