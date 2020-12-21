using game_project.CollisionResponse;
using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS.Components;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Enemy
{
    class Aquamentus : Enemy
    {

        public Aquamentus(Vector2 pos)
        {
            GetComponent<Transform>().position = pos;
            Constants.SetLayerDepth(this, Constants.LayerDepth.Enemy);

            BasicSprite spriteImage = BossSpriteFactory.Instance.CreateAquamentus();
            Sprite sprite = new Sprite(spriteImage);
            AddComponent(sprite);
            sprite.SetAnimate(true);

            BehaviorScript attack = new AquamentusAttack();
            AddComponent(attack);

            BehaviorScript movement = new AquamentusMovement();
            AddComponent(movement);

            Collider coll = new Collider();
            AddComponent(coll);
            // ToDo: what is Aquamentus' damage?
            coll.response = new EnemyCollisionResponse(this, Constants.STALFO_CONTACT_DAMAGE);

            BehaviorScript health = new AquamentusHealthManagement(Constants.AQUAMENTUS_HEALTH);
            AddComponent(health);
        }
    }
}
