using game_project.Content.Sprites.SpriteFactories;
using game_project.Levels;
using game_project.Sounds;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace game_project
{
    static class GameContent
    {
        public static bool IsBaseLoaded { get; set; }
        public static bool IsLoaded { get; set; }
        public static int Counter;
        public static int Max = 9;

#if WEB
        public static async Task InitAsync(ContentManager content, GraphicsDevice graphics)
        {
            Counter = 0;
            Font.hudFont = await content.LoadAsync<SpriteFont>("LoZ");
            IsBaseLoaded = true;

            await LinkItemSpriteFactory.Instance.LoadAllTexturesAsync(content); Counter++;
            await ItemSpriteFactory.Instance.LoadAllTexturesAsync(content); Counter++;
            await HUDSpriteFactory.Instance.LoadAllTexturesAsync(content); Counter++;
            await LevelMapSpriteFactory.Instance.LoadAllTexturesAsync(content); Counter++;
            await BossSpriteFactory.Instance.LoadAllTexturesAsync(content); Counter++;
            await NPCSpriteFactory.Instance.LoadAllTexturesAsync(content); Counter++;
            await EnemySpriteFactory.Instance.LoadAllTexturesAsync(content); Counter++;
            await LinkItemSpriteFactory.Instance.LoadAllTexturesAsync(content); Counter++;
            //Content.LoadAsync<SpriteFont>("LoZ")
            //await Sound.Instance.LoadAllSounds(content);
            
            LevelManager.Init();


            IsLoaded = true;
        }
#endif
        public static void Init(ContentManager content, GraphicsDevice graphics)
        {
            Counter = 0;
            //Texture.Pixel  = await content.LoadAsync<Texture2D>("Pixel");
            Font.hudFont = content.Load<SpriteFont>("LoZ"); Counter++;
            IsBaseLoaded = true;


            LinkSpriteFactory.Instance.LoadAllTextures(content); Counter++;
            ItemSpriteFactory.Instance.LoadAllTextures(content); Counter++;
            HUDSpriteFactory.Instance.LoadAllTextures(content); Counter++;
            LevelMapSpriteFactory.Instance.LoadAllTextures(content); Counter++;
            BossSpriteFactory.Instance.LoadAllTextures(content); Counter++;
            NPCSpriteFactory.Instance.LoadAllTextures(content); Counter++;
            EnemySpriteFactory.Instance.LoadAllTextures(content); Counter++;
            LinkItemSpriteFactory.Instance.LoadAllTextures(content); Counter++;
            Sound.Instance.LoadAllSounds(content); Counter++;

            LevelManager.Init();

            IsLoaded = true;
        }


        public static class Font
        {
            public static SpriteFont hudFont;
        }

    }
}



