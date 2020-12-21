using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace game_project.Sprites
{
    public static class Texture2DStorage
    {
        private static Texture2D enemySpriteSheet;
        private static Texture2D bossSpriteSheet;
        private static Texture2D linkSpriteSheet;
        private static Texture2D itemSpriteSheet;
        private static Texture2D npcSpriteSheet;
        private static Texture2D levelMapSpriteSheet;

        public static void LoadAllTextures(ContentManager content)
        {
            enemySpriteSheet = content.Load<Texture2D>("NES - The Legend of Zelda - Dungeon Enemies");
            bossSpriteSheet = content.Load<Texture2D>("NES - The Legend of Zelda - Bosses");
            linkSpriteSheet = content.Load<Texture2D>("NES - The Legend of Zelda - Link");
            itemSpriteSheet = content.Load<Texture2D>("NES - The Legend of Zelda - Items & Weapons");
            levelMapSpriteSheet = content.Load<Texture2D>("NES - The Legend of Zelda - Dungeon Tileset");
            npcSpriteSheet = content.Load<Texture2D>("NES - The Legend of Zelda - NPCs");
        }

        public static void UnloadAllTextures(ContentManager content)
        {
            // unload all Texture 2Ds - not needed for the scope of this project
        }

        public static Texture2D GetEnemySpriteSheet()
        {
            return enemySpriteSheet;
        }

        public static Texture2D GetBossSpriteSheet()
        {
            return bossSpriteSheet;
        }
        public static Texture2D GetLinkSpriteSheet()
        {
            return linkSpriteSheet;
        }
        public static Texture2D GetItemSpriteSheet()
        {
            return itemSpriteSheet;
        }
        public static Texture2D GetNPCSpriteSheet()
        {
            return npcSpriteSheet;
        }
        public static Texture2D GetLevelMapSpriteSheet()
        {
            return levelMapSpriteSheet;
        }
    }
}
