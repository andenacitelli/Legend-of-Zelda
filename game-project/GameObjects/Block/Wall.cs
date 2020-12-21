using game_project.CollisionResponse;
using game_project.ECS.Components;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace game_project.GameObjects.Block
{
    public class Wall : Block
    {

        public Wall(BasicSprite sprite, Vector2 position) : base(sprite, position)
        {
            name = "wall";
            // add colliders to each wall to keep characters inside the room
            float thickness = Constants.WALL_THICKNESS;
            float topWallWidth = Constants.WALL_TOP_WIDTH + Constants.DOOR_OFFSET;
            float sideWallWidth = Constants.WALL_SIDE_WIDTH + Constants.DOOR_OFFSET;
            float thicknessTopWall = Constants.WALL_THICKNESS_TOP;

            Rectangle frame = sprite.frames[sprite.currentFrame];
            float width = frame.Width * sprite.scalar;
            float height = frame.Height * sprite.scalar;

            Collider topLeft = new Collider(new RectangleF(0, 0, topWallWidth, thicknessTopWall));
            Collider leftTop = new Collider(new RectangleF(0, 0, thickness, sideWallWidth));
            Collider topRight = new Collider(new RectangleF(width - topWallWidth, 0, topWallWidth, thicknessTopWall));
            Collider rightTop = new Collider(new RectangleF(width - thickness, 0, thickness, sideWallWidth));

            Collider bottomLeft = new Collider(new RectangleF(0, height - thickness, topWallWidth, thickness));
            Collider leftBottom = new Collider(new RectangleF(0, height - sideWallWidth, thickness, sideWallWidth));
            Collider bottomRight = new Collider(new RectangleF(width - topWallWidth, height - thickness, topWallWidth, thickness));
            Collider rightBottom = new Collider(new RectangleF(width - thickness, height - sideWallWidth, thickness, sideWallWidth));

            List<Collider> colls = new List<Collider>();
            colls.Add(topLeft);
            colls.Add(leftTop);
            colls.Add(topRight);
            colls.Add(rightTop);

            colls.Add(bottomLeft);
            colls.Add(leftBottom);
            colls.Add(bottomRight);
            colls.Add(rightBottom);

            foreach (var coll in colls)
            {
                coll.response = new WallCollisionResponse(this);
                AddComponent(coll);
            }

        }

    }
}
