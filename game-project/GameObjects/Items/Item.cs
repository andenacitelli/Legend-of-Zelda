using game_project.CollisionResponse;
using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.Levels;
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

        public static void ItemDrop(Vector2 position)
        {
            if (Constants.GetRandomIntMinMax(0, 3) == 0)
            {
                int rand = Constants.GetRandomIntMinMax(0, 5);
                string type;
                BasicSprite sprite;
                if (rand == 0)
                {
                    type = "clock";
                    sprite = ItemSpriteFactory.Instance.CreateClock();
                } else if (rand <= 2)
                {
                    type = "heart";
                    sprite = ItemSpriteFactory.Instance.CreateHeartFull();
                } else
                {
                    type = "rupee";
                    sprite = ItemSpriteFactory.Instance.CreateRupee();
                }

                Item item = new Item(sprite, position);
                Collider coll = new Collider();
                coll.response = new ItemCollisionResponse(item);
                item.AddComponent(coll);
                item.SetItemType(type);
                LevelManager.currentLevel.Root.GetComponent<Transform>().AddChild(item);
            }
        }

        public static void CreateKey(Vector2 pos)
        {
            Item item = new Item(ItemSpriteFactory.Instance.CreateRegularKey(), pos);
            Collider coll = new Collider();
            coll.response = new ItemCollisionResponse(item);
            item.AddComponent(coll);
            item.SetItemType("regularkey");
            LevelManager.currentLevel.Root.GetComponent<Transform>().AddChild(item);
        }
    }
}
