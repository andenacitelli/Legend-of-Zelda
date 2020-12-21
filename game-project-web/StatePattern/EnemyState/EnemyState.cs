using game_project.GameObjects.Enemy;

namespace game_project.StatePattern.EnemyState
{
    class EnemyState
    {
        protected EnemyStatePattern pattern;

        public EnemyState(EnemyStatePattern pattern)
        {
            this.pattern = pattern;
        }
    }
}
