using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Link;
using Microsoft.Xna.Framework;
using game_project.GameObjects.Writing;
using game_project.Sprites.Sprites;
using game_project.Content.Sprites.SpriteFactories;
using System;
using System.Collections.Generic;

namespace game_project.GameObjects.GUI
{
    class XPDisplayManager : BehaviorScript
    {
        LinkXPManager xp_manager;
        TextEntity t;
        XPBarBlank bg;
        Vector2 position;
        XPBarFill[] Fills = new XPBarFill[20];

        public XPDisplayManager(Vector2 pos)
        {
            position = pos;
            t = new TextEntity(position, "", Color.White, 0.5f);
            Scene.Add(t);
            bg = new XPBarBlank(Constants.HUD_XPBAR_POSITION);
            Scene.Add(bg);
            for (int i = 1; i <= 20; i++)
            {
                Fills[i - 1] = new XPBarFill(Constants.HUD_XPBAR_POSITION, i);
                Scene.Add(Fills[i - 1]);
            }
        }

        public override void Update(GameTime gameTime)
        {
            // display management
            xp_manager = Scene.Find("Link").GetComponent<LinkXPManager>();
            int xp = xp_manager.linkXp;
            Entity.Destroy(t);

            // color selection
            Color color = Color.White;
            if (xp_manager.IsXPMax())
            {
                color = Color.Green;
            }

            string amount = xp.ToString();

            // xp formatting
            if (xp < 10)
            {
                amount = "  " + xp.ToString();
            }
            else if (xp < 100)
            {
                amount = " " + xp.ToString();
            }

            // update bar
            for (int i = 0; i < 20; i++)
            {
                if (i < xp)
                {
                    Constants.SetLayerDepth(Fills[i], Constants.LayerDepth.Text);
                } else
                {
                    Constants.SetLayerDepth(Fills[i], Constants.LayerDepth.Backdrop);
                }
            }

            // print xp amount
            t = new TextEntity(position, amount, color, 0.5f);
            Scene.Add(t);
        }
    }
}
