using game_project.CollisionDetection;
using game_project.CollisionResponse;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;
using System;

namespace game_project.GameObjects.Block
{
    public class InvisibleBlock : Block
    {
        public InvisibleBlock(BasicSprite sprite, Vector2 position) : base(sprite, position)
        {
            // don't do any logic here, just add Components that do the logic
            GetComponent<Transform>().position = position;
            Constants.SetLayerDepth(this, Constants.LayerDepth.Block);

            Sprite s = new Sprite(sprite);
            AddComponent(s);

            var coll = new Collider();
            var rect = GetRectColliders();
            rect.Y += Constants.INVIS_BLOCK_OFFSET / 4;
            rect.Height += Constants.INVIS_BLOCK_OFFSET;
            coll.colliderBounds = new ManualColliderBounds(coll, rect);
            AddComponent(coll);
            coll.response = new InvisibleBlockCollisionResponse(this);
        }

    }
}
