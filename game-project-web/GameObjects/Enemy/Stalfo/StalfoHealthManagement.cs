using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Items;
using game_project.Content.Sprites.SpriteFactories;
using game_project.CollisionResponse;
using game_project.Levels;

namespace game_project.GameObjects.Enemy
{
    class StalfoHealthManagement : EnemyHealthManagement
    {
        public StalfoHealthManagement(int startingHealth) : base(startingHealth)
        {

        }

        public override void Die()
        {
            bool itemHeld = entity.GetComponent<StalfoMovement>().itemHeld;

            // drop an item
            if (itemHeld != true)
            {
                // drop random item ??
            }
            else // drop regular key
            {
                Item item = new Item(ItemSpriteFactory.Instance.CreateRegularKey(), entity.GetComponent<Transform>().position);
                Collider coll = new Collider();
                coll.response = new ItemCollisionResponse(item);
                item.AddComponent(coll);
                item.SetItemType("regularkey");
                LevelManager.currentLevel.Root.GetComponent<Transform>().AddChild(item);
                Scene.Add(item);
            }

            Entity.Destroy(entity);

            // POTENTIAL TO DO: implement star burst if we can find the sprite or end up making it
        }

    }
}
