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
    class XPBarBlank : Entity
    {
        public XPBarBlank(Vector2 pos)
        {
            var s = new Sprite(HUDSpriteFactory.Instance.CreateXPBarBlank());
            AddComponent(s);
            Constants.SetLayerDepth(this, Constants.LayerDepth.Boxes);

            GetComponent<Transform>().position = pos;
        }

    }
}
