using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_project.GameObjects.GUI
{
    class XPBarFill : Entity
    {
        public XPBarFill(Vector2 pos, int part)
        {
            var s = new Sprite(HUDSpriteFactory.Instance.CreateXPBarFill(part));
            AddComponent(s);
            Constants.SetLayerDepth(this, Constants.LayerDepth.Backdrop);

            GetComponent<Transform>().position = pos + Constants.HUD_XPBAR_FILLSIZE*(part - 1);
        }

    }
}
