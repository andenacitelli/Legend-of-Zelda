using game_project.GameObjects.Items;

namespace game_project.StatePattern.ItemState
{
    class ItemState
    {
        protected ItemStatePattern pattern;

        public ItemState(ItemStatePattern pattern)
        {
            this.pattern = pattern;
        }
    }
}
