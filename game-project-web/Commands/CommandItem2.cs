using System;
using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Items;
using game_project.GameObjects.Link;
using game_project.GameObjects.Projectiles;
using Microsoft.Xna.Framework;

namespace game_project.Commands
{
    class CommandItem2 : ICommand
    {
        public void Execute()
        {
            //bool moving = true, disappearing = true;
            //int framesToDraw = 180;

            //// Better to pass direction in here, as it is more flexible in the future if we need to throw something in a direction Link isn't currently facing         
            //MovingItem item = new MovingItem(moving, disappearing, framesToDraw, LinkState.linkDirection);
            //item.GetComponent<Sprite>().SetSprite(ItemSpriteFactory.Instance.CreateCompass());
            //// Vector2 linkPos = Game1.link.GetComponent<Transform>().position;
            //// item.GetComponent<Transform>().position = new Vector2(linkPos.X, linkPos.Y);


            Link link = (Link)Scene.Find("link");
            if (link != null)
            {
                // Create new Boomerang
                // TODO: LinkState.linkDirection should not be static @pranav
                Boomerang b = new Boomerang(LinkBehavior.linkDirection, link);

            }

        }
    }
}
