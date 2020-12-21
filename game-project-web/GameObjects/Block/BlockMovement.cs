using game_project.CollisionResponse;
using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Block;
using game_project.GameObjects.Link;
using game_project.GameObjects.Projectiles;
using game_project.Sprites.Sprites;
using game_project.StatePattern.EnemyState;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace game_project.GameObjects.Enemy
{
    class BlockMovement : BehaviorScript
    {
        float ms = 0;
        private Transform transform;
        private Vector2 motion;
        private bool done = false;
        private bool linkIsSafe = false;
        private string door = null;

        public BlockMovement(Constants.Direction direction)
        {
            switch (direction)
            {
                case Constants.Direction.UP:
                    motion = new Vector2(0, -1);
                    break;
                case Constants.Direction.DOWN:
                    motion = new Vector2(0, 1);
                    break;
                case Constants.Direction.LEFT:
                    motion = new Vector2(-1, 0);
                    break;
                case Constants.Direction.RIGHT:
                    motion = new Vector2(1, 0);
                    break;
                default:
                    motion = new Vector2();
                    break;
            }
        }

        public BlockMovement(Constants.Direction direction, string door)
        {
            this.door = door;
            switch (direction)
            {
                case Constants.Direction.UP:
                    motion = new Vector2(0, -1);
                    break;
                case Constants.Direction.DOWN:
                    motion = new Vector2(0, 1);
                    break;
                case Constants.Direction.LEFT:
                    motion = new Vector2(-1, 0);
                    break;
                case Constants.Direction.RIGHT:
                    motion = new Vector2(1, 0);
                    break;
                default:
                    motion = new Vector2();
                    break;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (!done)
            {
                float delta = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                ms += delta;
                transform = entity.GetComponent<Transform>();
                Collider coll = entity.GetComponent<Collider>();



                Entity link = Scene.Find("link");
                if (coll.TestCollision(link.GetComponent<Collider>()))
                {
                    Transform linkTransform = link.GetComponent<Transform>();
                    Vector2 diff = linkTransform.WorldPosition - transform.position;
                    if (Math.Abs(diff.X) > Math.Abs(diff.Y))
                    {
                        linkTransform.position = linkTransform.lastPosition;
                    } else
                    {
                        if (diff.Y < 0)
                        {
                            linkTransform.position = linkTransform.lastPosition + motion * delta * Constants.BLOCK_MOVEMENT_SPEED;
                        } else
                        {
                            linkTransform.position = linkTransform.lastPosition;
                        }
                    }
                }

                if (ms < Constants.BLOCK_TIME_TO_MOVE_MS)
                {
                    transform.position += motion * delta * Constants.BLOCK_MOVEMENT_SPEED;
                }
                else
                {
                    coll.response = new RigidCollisionResponse(entity);
                    done = true;
                    if (door != null)
                    {
                        ((Door)Scene.Find("boss_door")).doorType = Door.Type.Open;
                    }
                }
            }
        }

    }
}
