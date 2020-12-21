using game_project.CollisionDetection;
using game_project.CollisionResponse;
using game_project.ECS.Components;
using game_project.Levels;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace game_project.GameObjects.Block
{
    public class Door : Block
    {
        public static List<ECS.Components.CollisionResponse> doorResponses = new List<ECS.Components.CollisionResponse>();
        public Type doorType;
        public enum Type
        {
            Open = 1,
            Locked,
            Wall,
            BombWall,
        }

        public Door(BasicSprite sprite, Vector2 position, Type type = Type.Open) : base(sprite, position)
        {
            doorType = type;
            var coll = GetComponent<Collider>();

            ECS.Components.CollisionResponse response = new BaseCollisionResponse(this);

            float width = Level.screen_width;
            float height = Level.screen_height;
            //Debug.WriteLine(position);

            Constants.Direction direction = Constants.Direction.UP;
            if (position.X <= 0)
            {
                direction = Constants.Direction.LEFT;
                name = "left";
            }
            else if (position.X > (width / 2) && position.Y > 0)
            {
                direction = Constants.Direction.RIGHT;
                name = "right";
            }
            else if (position.Y >= height)
            {
                direction = Constants.Direction.DOWN;
                name = "down";
            }
            else if (position.X > 0)
            {
                direction = Constants.Direction.UP;
                name = "up";
            }


            switch (type)
            {
                case Type.Open:
                    response = new DoorCollisionResponse(this, direction);
                    doorResponses.Add(response);
                    response.enabled = false;
                    break;
                case Type.BombWall:
                    response = new DoorCollisionResponse(this, direction);
                    doorResponses.Add(response);
                    response.enabled = false;
                    break;
                case Type.Locked:
                    response = new DoorCollisionResponse(this, direction);
                    doorResponses.Add(response);
                    break;
                case Type.Wall:
                    response = new RigidCollisionResponse(this);
                    break;

            }

            if (type == Type.BombWall || type == Type.Wall)
            {
                if (direction == Constants.Direction.UP)
                {
                    var rect = new RectangleF();
                    //b.X = transform.WorldPosition.X;
                    //b.Y = transform.WorldPosition.Y;
                    Sprite s = coll.entity.GetComponent<Sprite>();
                    Rectangle frame = s.sprite.frames[s.sprite.currentFrame];
                    rect.Width = frame.Width * s.sprite.scalar;
                    const float BOMB_WALL_OFFSET = 28f;
                    rect.Height = frame.Height * s.sprite.scalar + BOMB_WALL_OFFSET;
                    //v
                    coll.colliderBounds = new ManualColliderBounds(coll, rect);
                }
            }

            coll.response = response;

        }

    }
}
