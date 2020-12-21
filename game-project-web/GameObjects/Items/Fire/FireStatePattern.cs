using game_project.GameObjects.Items;
using game_project.StatePattern.ItemState;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Items
{

    class FireStatePattern : ItemStatePattern
    {
        public FireState state;
        public FireStatePattern(Item fire) : base(fire)
        {
        }

        public override void Init()
        {
            state = new FireStateFaceLeft(this);

        }

        public override void Update(GameTime gameTime)
        {
            state.HandleInput();
        }
    }
}