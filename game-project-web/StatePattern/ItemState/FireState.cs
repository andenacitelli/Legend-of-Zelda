using game_project.Content.Sprites.SpriteFactories;
using game_project.GameObjects.Items;
using game_project.Sprites.Sprites;

namespace game_project.StatePattern.ItemState
{
    abstract class FireState
    {
        protected FireStatePattern pattern;
        protected BasicSprite Fire = LinkItemSpriteFactory.Instance.CreateFire();
        protected BasicSprite FireFlipped = LinkItemSpriteFactory.Instance.CreateFireFlipped();

        protected int frames = Constants.FIRE_FRAMES;

        public FireState(FireStatePattern pattern)
        {
            this.pattern = pattern;
            SetSprite(Fire, false);
        }

        public void SetSprite(BasicSprite sprite, bool animate)
        {
            pattern.SetSprite(sprite, animate);
        }


        public abstract void HandleInput();
    }

    class FireStateFaceLeft : FireState
    {
        int frame = 0;
        public FireStateFaceLeft(FireStatePattern pattern) : base(pattern)
        {
            SetSprite(Fire, false);
        }


        public override void HandleInput()
        {
            frame++;
            if (frame >= frames)
            {
                pattern.state = new FireStateFaceRight(pattern);
            }
        }
    }

    class FireStateFaceRight : FireState
    {
        int frame = 0;
        public FireStateFaceRight(FireStatePattern pattern) : base(pattern)
        {
            SetSprite(FireFlipped, false);
        }


        public override void HandleInput()
        {
            frame++;
            if (frame >= frames)
            {
                pattern.state = new FireStateFaceLeft(pattern);
            }
        }
    }

}