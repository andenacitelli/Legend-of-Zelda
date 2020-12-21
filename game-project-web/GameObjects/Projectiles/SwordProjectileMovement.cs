using game_project.ECS.Components;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Projectiles
{
    class SwordProjectileMovement : BehaviorScript
    {
        private Constants.Direction direction;
        private const float speed = Constants.SWORD_BEAM_SPEED;
        public SwordProjectileMovement(Constants.Direction direction)
        {
            this.direction = direction;
        }

        public override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            switch (direction)
            {
                case Constants.Direction.UP:
                    entity.GetComponent<Transform>().position.Y -= delta * speed;
                    break;
                case Constants.Direction.RIGHT:
                    entity.GetComponent<Transform>().position.X += delta * speed;
                    break;
                case Constants.Direction.DOWN:
                    entity.GetComponent<Transform>().position.Y += delta * speed;
                    break;
                case Constants.Direction.LEFT:
                    entity.GetComponent<Transform>().position.X -= delta * speed;
                    break;
            }
        }
    }
}
