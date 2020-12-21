using game_project.CollisionDetection;
using game_project.CollisionResponse;
using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS.Components;
using game_project.Levels;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

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

        public void OpenDoor()
        {
            var coll = GetComponent<Collider>();
            var rect = GetRectColliders();

            switch (name) //name is left, right, down, or up
            {
                case "up":
                    rect.Width /= 2; // divide width by 2
                    rect.X += Constants.DOOR_OFFSET;
                    rect.Y -= Constants.DOOR_OFFSET;
                    GetComponent<Sprite>().SetSprite(LevelMapSpriteFactory.Instance.CreateTopOpen());
                    break;
                case "down":
                    rect.Width /= 2; // divide width by 2
                    rect.X += Constants.DOOR_OFFSET;
                    rect.Y += Constants.DOOR_OFFSET;
                    GetComponent<Sprite>().SetSprite(LevelMapSpriteFactory.Instance.CreateDownOpen());
                    break;
                case "left":
                    rect.Height /= 2; // divide height by 2
                    rect.Y += Constants.DOOR_OFFSET;
                    rect.X -= Constants.DOOR_OFFSET;
                    GetComponent<Sprite>().SetSprite(LevelMapSpriteFactory.Instance.CreateLeftOpen());
                    break;
                case "right":
                    rect.Height /= 2; // divide height by 2
                    rect.Y += Constants.DOOR_OFFSET;
                    rect.X += Constants.DOOR_OFFSET;
                    GetComponent<Sprite>().SetSprite(LevelMapSpriteFactory.Instance.CreateRightOpen());
                    break;
            }
            doorType = Type.Open;
            coll.colliderBounds = new ManualColliderBounds(coll, rect);
        }

        public Door(BasicSprite sprite, Vector2 position, Type type = Type.Open) : base(sprite, position)
        {
            doorType = type;

            ECS.Components.CollisionResponse response = new BaseCollisionResponse(this);
            var coll = GetComponent<Collider>();
            Sprite s = GetComponent<Sprite>();
            Rectangle frame = s.sprite.frames[s.sprite.currentFrame];
            // set bounds
            var rect = GetRectColliders();

            float width = Level.screen_width;
            float height = Level.screen_height;

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

            // move collider bounds for doors if not a wall
            if (type == Type.Open)
            {
                OpenDoor();
            }
            else
            {
                // set collider bounds
                coll.colliderBounds = new ManualColliderBounds(coll, rect);

            }


            switch (type)
            {
                case Type.Open:
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
                    coll.colliderBounds = new SpriteColliderBounds(coll);
                    break;

            }

            if (type == Type.BombWall || type == Type.Wall)
            {
                if (direction == Constants.Direction.UP)
                {
                    const float BOMB_WALL_OFFSET = 28f;
                    rect.Height = frame.Height * s.sprite.scalar + BOMB_WALL_OFFSET;
                    // sets collider bounds differently for up bomb walls
                    coll.colliderBounds = new ManualColliderBounds(coll, rect);
                }
            }

            coll.response = response;

        }

    }
}
