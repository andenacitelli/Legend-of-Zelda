using System;
using game_project.ECS;
using game_project.ECS.Components;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Projectiles
{
    public class FireballMovement : BehaviorScript
    {
        private readonly float angle; // Exact angle fired. Uses unit circle coordinate frame, which is right = 0deg, positive is CCW.

        public FireballMovement(float angle)
        {
            this.angle = angle;
        }

        float time = 0; // ms
        public override void Update(GameTime gameTime)
        {
            // Translate by the angle for the given amount of time 
            float delta = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            entity.GetComponent<Transform>().position += new Vector2((float) Math.Cos(angle) * delta * Constants.FIREBALL_SPEED, (float) Math.Sin(angle) * delta * Constants.FIREBALL_SPEED); 

            // Destroy if it's been around for long enough 
            time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (time > Constants.FIREBALL_LIFETIME_MS)
            {
                Entity.Destroy(entity);
            }
        }
    }
}
