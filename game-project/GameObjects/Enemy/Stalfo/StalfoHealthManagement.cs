using game_project.CollisionResponse;
using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Items;
using game_project.GameObjects.Link;
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
            LevelManager.EnemyKilled();

            bool itemHeld = entity.GetComponent<StalfoMovement>().itemHeld;

            // drop an item
            if (itemHeld != true)
            {
                Item.ItemDrop(entity.GetComponent<Transform>().position);
            }
            else // drop regular key
            {
                Item.CreateKey(entity.GetComponent<Transform>().position);
            }

            Scene.Find("link").GetComponent<LinkXPManager>().EnemyKill_XPIncrease();
            Entity.Destroy(entity);

            // POTENTIAL TO DO: implement star burst if we can find the sprite or end up making it
        }

    }
}
