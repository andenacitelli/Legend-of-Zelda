using System;
using game_project.CollisionResponse;
using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Items;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Enemy
{
    class AquamentusMovement : BehaviorScript
    {
        private float msToMove;
        private float ms = 0;
        private int direction;
        private int position = 0;
        private Transform transform;
        private Random rand;

        private int health;
        public AquamentusMovement()
        {
            rand = new Random();
            direction = -1; // start with moving towards link
            position += direction;
            msToMove = Constants.GetRandomIntMinMax(1500, 2000);
            health = Constants.AQUAMENTUS_HEALTH;
        }

        public override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            ms += delta;
            transform = entity.GetComponent<Transform>();

            if (ms > msToMove)
            {
                // Get 1 or -1 for direction
                direction = rand.Next(2);
                if (direction == 0) direction = -1;
                position += direction;

                if (Math.Abs(position) > 5) direction *= -1; // allowed to move 5 times in the same direction

                ms = 0;
                msToMove = Constants.GetRandomIntMinMax(1500, 2000);
            } else
            {
                transform.position.X += direction * Constants.AQUAMENTUS_MOVEMENT_SPEED * delta;
                ms++;
            }

        }
    }
}
