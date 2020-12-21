using game_project.Content.Sprites.SpriteFactories;
using game_project.GameObjects.Enemy.Goriya.GoriyaStatePattern;
using game_project.Sprites.Sprites;

namespace game_project.StatePattern.EnemyState
{
    abstract class GoriyaState
    {
        protected GoriyaStatePattern pattern;
        protected BasicSprite Goriya = EnemySpriteFactory.Instance.CreateBlueGoriyaLeft();
        protected BasicSprite GoriyaFlipped = EnemySpriteFactory.Instance.CreateBlueGoriyaRight();

        protected int frames = 7;

        public GoriyaState(GoriyaStatePattern pattern)
        {
            this.pattern = pattern;
            SetSprite(Goriya, false);
        }

        public void SetSprite(BasicSprite sprite, bool animate)
        {
            pattern.SetSprite(sprite, animate);
        }


        public abstract void HandleInput();
    }

    class GoriyaStateFaceLeft : GoriyaState
    {
        int frame = 0;
        public GoriyaStateFaceLeft(GoriyaStatePattern pattern) : base(pattern)
        {
            SetSprite(Goriya, false);
        }


        public override void HandleInput()
        {
            frame++;
            if (frame >= frames)
            {
                pattern.state = new GoriyaStateFaceRight(pattern);
            }
        }
    }

    class GoriyaStateFaceRight : GoriyaState
    {
        int frame = 0;
        public GoriyaStateFaceRight(GoriyaStatePattern pattern) : base(pattern)
        {
            SetSprite(GoriyaFlipped, false);
        }


        public override void HandleInput()
        {
            frame++;
            if (frame >= frames)
            {
                pattern.state = new GoriyaStateFaceLeft(pattern);
            }
        }
    }

}