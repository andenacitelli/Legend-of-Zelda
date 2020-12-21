using game_project.ECS.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace game_project.GameObjects.Enemy
{

    class StalfoMovement : BehaviorScript
    {
        private float turnTime;
        private float turnTimer = 0;

        public StalfoMovement()
        {
            turnTime = Constants.GetRandomIntMinMax(300, 1500);
        }

        Vector2 direction = Vector2.UnitX;
        List<Vector2> directions = new List<Vector2>
        {
            Vector2.UnitX,
            -Vector2.UnitY,
            -Vector2.UnitX,
            Vector2.UnitY,
        };

        private static readonly Random random = new Random();

        public bool itemHeld = false;

        public override void Update(GameTime gameTime)
        {
            if (((Enemy)entity).frozen)
            {
                return;
            } 
            float delta = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            turnTimer += delta;
            if (turnTimer > turnTime)
            {
                turnTimer = 0;
                turnTime = Constants.GetRandomIntMinMax(300, 1500);
                ChangeDirection();
            }
            var transform = entity.GetComponent<Transform>();
            transform.position += direction * delta * Constants.STALFO_MOVEMENT_SPEED;
        }

        private void ChangeDirection()
        {
            int r = random.Next(0, directions.Count);
            direction = directions[r];
        }

        public void SetItemHeldTrue()
        {
            itemHeld = true;
        }
    }
}
