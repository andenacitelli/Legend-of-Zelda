using game_project.Content.Sprites.SpriteFactories;
using game_project.GameObjects.Enemy;
using game_project.Sprites.Sprites;

namespace game_project.StatePattern.EnemyState
{
    abstract class StalfoState
    {
        protected StalfoStatePattern pattern;
        protected BasicSprite Stalfo = EnemySpriteFactory.Instance.CreateStalfo();
        protected BasicSprite StalfoFlipped = EnemySpriteFactory.Instance.CreateStalfoFlipped();

        protected int frames = Constants.STALFOS_ANIMATION_FRAMES;

        public StalfoState(StalfoStatePattern pattern)
        {
            this.pattern = pattern;
            SetSprite(Stalfo, false);
        }

        public void SetSprite(BasicSprite sprite, bool animate)
        {
            pattern.SetSprite(sprite, animate);
        }


        public abstract void HandleInput();
    }

    class StalfoStateFaceLeft : StalfoState
    {
        int frame = 0;
        public StalfoStateFaceLeft(StalfoStatePattern pattern) : base(pattern)
        {
            SetSprite(Stalfo, false);
        }

        public override void HandleInput()
        {
            frame++;
            if (frame >= frames)
            {
                pattern.state = new StalfoStateFaceRight(pattern);
            }
        }
    }

    class StalfoStateFaceRight : StalfoState
    {
        int frame = 0;
        public StalfoStateFaceRight(StalfoStatePattern pattern) : base(pattern)
        {
            SetSprite(StalfoFlipped, false);
        }

        public override void HandleInput()
        {
            frame++;
            if (frame >= frames)
            {
                pattern.state = new StalfoStateFaceLeft(pattern);
            }
        }
    }

}