using game_project.ECS.Components;
using game_project.Sprites.Sprites;
using game_project.StatePattern.ItemState;

namespace game_project.GameObjects.Items
{
    class ItemStatePattern : BehaviorScript
    {
        public Item item;

        public ItemStatePattern(Item item)
        {
            this.item = item;
        }

        public void SetSprite(BasicSprite sprite, bool animate)
        {
            item.GetComponent<Sprite>().SetSprite(sprite);
            item.GetComponent<Sprite>().SetAnimate(animate);
        }

    }   
}
