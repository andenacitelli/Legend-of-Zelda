using System.Collections.Generic;
using System.Threading.Tasks;
using game_project.Sprites;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace game_project.Content.Sprites.SpriteFactories
{
    public class NPCSpriteFactory
    {
        private Texture2D NPCSpriteSheet;
        private readonly NPCSpriteFrames npcSpriteFrames = new NPCSpriteFrames();

        private static readonly NPCSpriteFactory instance = new NPCSpriteFactory();

        public static NPCSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private NPCSpriteFactory() { }

        public async Task LoadAllTextures(ContentManager content)
        {
            NPCSpriteSheet = await content.LoadAsync<Texture2D>("NES - The Legend of Zelda - NPCs");
        }
        public async Task LoadAllTexturesAsync(ContentManager content)
        {
            NPCSpriteSheet = await content.LoadAsync<Texture2D>("NES - The Legend of Zelda - NPCs");
        }

        public BasicSprite CreateOldMan1()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                npcSpriteFrames.frames["OldMan1"]
            };
            return new BasicSprite(NPCSpriteSheet, frames);
        }

        public BasicSprite CreateOldMan2()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                npcSpriteFrames.frames["OldMan2"]
            };
            return new BasicSprite(NPCSpriteSheet, frames);
        }
        public BasicSprite CreateOldWoman()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                npcSpriteFrames.frames["OldWoman"]
            };
            return new BasicSprite(NPCSpriteSheet, frames);
        }
        public BasicSprite CreateMerchantGreen()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                npcSpriteFrames.frames["MerchantGreen"]
            };
            return new BasicSprite(NPCSpriteSheet, frames);
        }
        public BasicSprite CreateMerchantWhite()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                npcSpriteFrames.frames["MerchantWhite"]
            };
            return new BasicSprite(NPCSpriteSheet, frames);
        }
        public BasicSprite CreateMerchantRed()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                npcSpriteFrames.frames["MerchantRed"]
            };
            return new BasicSprite(NPCSpriteSheet, frames);
        }
        public BasicSprite CreateCircles()
        {
            List<Rectangle> frames = new List<Rectangle>
            {
                npcSpriteFrames.frames["GreenCircle"],
                npcSpriteFrames.frames["NavyCircle"],
                npcSpriteFrames.frames["RedCircle"],
                npcSpriteFrames.frames["BlueCircle"]
            };
            return new BasicSprite(NPCSpriteSheet, frames);
        }
    }
}
