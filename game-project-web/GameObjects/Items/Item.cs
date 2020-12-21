using game_project.ECS;
using game_project.ECS.Components;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Items
{
    public class Item : Entity
    {
        private string itemType;
        public int value { get; set; } = 1; // mostly for rupees
        public Item(BasicSprite sprite, Vector2 position)
        {

            // don't do any logic here, just add Components that do the logic
            GetComponent<Transform>().position = position;

            Constants.SetLayerDepth(this, Constants.LayerDepth.Item);

            Sprite spriteComponent = new Sprite(sprite);
            AddComponent(spriteComponent);
        }

        public string GetItemType()
        {
            return itemType;
        }
        public void SetItemType(string givenItemType)
        {
            itemType = givenItemType;
        }
    }
}
