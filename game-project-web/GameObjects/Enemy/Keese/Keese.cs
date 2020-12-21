using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS.Components;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;
using game_project.CollisionResponse;

namespace game_project.GameObjects.Enemy
{
    class Keese : Enemy
    {

        public Keese(Vector2 pos)
        {
            GetComponent<Transform>().position = pos;

            BasicSprite spriteImage = EnemySpriteFactory.Instance.CreateBlueKeese();
            Sprite sprite = new Sprite(spriteImage);
            AddComponent(sprite);

            BehaviorScript movement = new KeeseMovement();
            AddComponent(movement);

            var coll = new Collider();
            coll.response = new KeeseCollisionResponse(this, Constants.KEESE_CONTACT_DAMAGE);
            AddComponent(coll);
            Constants.SetLayerDepth(this, Constants.LayerDepth.Enemy);

            BehaviorScript health = new EnemyHealthManagement(Constants.KEESE_HEALTH);
            AddComponent(health);
        }

    }
}
