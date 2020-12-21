using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Items;
using game_project.GameObjects.Link;
using game_project.Levels;
using Microsoft.Xna.Framework;
using System;

namespace game_project.GameObjects.Projectiles
{
    public class BoomerangMovement : BehaviorScript
    {
        private float speed = Constants.BOOMERANG_INITIAL_SPEED;
        float returnSpeed = Constants.BOOMERANG_INITIAL_RETURN_SPEED;
        private readonly Constants.Direction direction;
        float t = 0;

        enum BoomerangState
        {
            Firing = 0,
            Returning,
            Dead
        }

        private BoomerangState state = BoomerangState.Firing;

        private Entity thrower;
        float currentX = 0;
        float currentY = 0;

        public BoomerangMovement(Entity thrower, Constants.Direction direction)
        {
            this.thrower = thrower;
            this.direction = direction;
        }

        public override void Update(GameTime gameTime)
        {
            var transform = entity.GetComponent<Transform>();
            float delta = (float)gameTime.ElapsedGameTime.TotalMilliseconds;


            if (state == BoomerangState.Firing)
            {

                speed -= Constants.BOOMERANG_ACCEL; // Gets slower and slower then goes into the negatives to go back to where it started
                switch (direction)
                {
                    case Constants.Direction.UP:
                        transform.position.Y -= speed * delta;
                        break;
                    case Constants.Direction.RIGHT:
                        transform.position.X += speed * delta;
                        break;
                    case Constants.Direction.DOWN:
                        transform.position.Y += speed * delta;
                        break;
                    case Constants.Direction.LEFT:
                        transform.position.X -= speed * delta;
                        break;
                    default:
                        Console.WriteLine("BoomerangMovement @ Update: Invalid direction!");
                        break;
                }
                if (speed <= 0)
                {
                    state = BoomerangState.Returning;
                    currentX = transform.position.X;
                    currentY = transform.position.Y;
                }
            }
            else if (state == BoomerangState.Returning)
            {
                var goal = thrower.GetComponent<Transform>().position;
                float goalX = goal.X;
                float goalY = goal.Y;


                float newX = lerp(currentX, goalX, t);
                float newY = lerp(currentY, goalY, t);

                transform.position.X = newX;
                transform.position.Y = newY;

                t += returnSpeed;
                returnSpeed *= 1.01f;


                if (t > 1)
                {
                    state = BoomerangState.Dead;
                }
            }
            else if (state == BoomerangState.Dead)
            {
                entity.State = EntityStates.Disabled;
                Scene.Find("link").GetComponent<LinkInventory>().AddUseableItem((int)ItemInventory.UseInventory.BOOMERANG); // add boomerang back to use
                Entity.Destroy(entity);
            }

        }

        float lerp(float start, float end, float t)
        {
            return start * (1 - t) + end * t;
        }
    }
}

