using System;
using game_project.Content.Sprites.SpriteFactories;
using game_project.GameObjects.Items;
using Microsoft.Xna.Framework;

namespace game_project.Commands
{
    class LinkUseBomb : ICommand
    {
        public void Execute()
        {
            //Item bomb = new Item(ItemSpriteFactory.Instance.CreateBomb(), new Vector2(200, 400));
            //bomb.AddComponent(new BombBehaviorScript());
        }
    }
}
