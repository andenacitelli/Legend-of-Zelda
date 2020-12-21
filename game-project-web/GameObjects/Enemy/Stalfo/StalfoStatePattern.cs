using game_project.StatePattern.EnemyState;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Enemy
{

    class StalfoStatePattern : EnemyStatePattern
    {
        public StalfoState state;
        public StalfoStatePattern(Stalfo enemy) : base(enemy) { }

        public override void Init()
        {
            state = new StalfoStateFaceLeft(this);
        }

        public override void Update(GameTime gameTime)
        {
            if (((Enemy)entity).frozen)
            {
                return;
            }

            state.HandleInput();
        }
    }
}