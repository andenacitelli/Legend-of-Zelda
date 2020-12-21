using game_project.ECS.Components;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Enemy
{
    class EnemyFreeze : BehaviorScript
    {
        private float time = 0;
        public bool startTimer = false;

        public EnemyFreeze()
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (time < Constants.ENEMY_FREEZE_TIME)
            {
                Transform transform = entity.GetComponent<Transform>();
                transform.position = transform.lastPosition;
                time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                ((Enemy)entity).frozen = true;
                entity.GetComponent<Sprite>().SetAnimate(false);
            }
            else
            {
                ((Enemy)entity).frozen = false;
                entity.GetComponent<Sprite>().SetAnimate(true);
            }
        }
    }
}
