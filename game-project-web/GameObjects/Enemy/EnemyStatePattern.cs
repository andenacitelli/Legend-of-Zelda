using game_project.ECS.Components;
using game_project.Sprites.Sprites;
using game_project.StatePattern.EnemyState;

namespace game_project.GameObjects.Enemy
{
    class EnemyStatePattern : BehaviorScript
    {
        public Enemy enemy;

        public EnemyStatePattern(Enemy enemy)
        {
            this.enemy = enemy;
        }

        public void SetSprite(BasicSprite sprite, bool animate)
        {
            enemy.GetComponent<Sprite>().SetSprite(sprite);
            SetAnimate(animate);
        }

        public void SetAnimate(bool animate)
        {
            enemy.GetComponent<Sprite>().SetAnimate(animate);
        }

    }
}
