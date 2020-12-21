using game_project.CollisionResponse;
using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS.Components;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Enemy
{
    class Stalfo : Enemy
    {

        public Stalfo(Vector2 pos)
        {
            GetComponent<Transform>().position = pos;

            BasicSprite spriteImage = EnemySpriteFactory.Instance.CreateStalfo();
            Sprite sprite = new Sprite(spriteImage);
            AddComponent(sprite);
            sprite.SetAnimate(false);

            BehaviorScript state = new StalfoStatePattern(this);
            AddComponent(state);

            BehaviorScript movement = new StalfoMovement();
            AddComponent(movement);

            var coll = new Collider();
            coll.response = new EnemyCollisionResponse(this, Constants.STALFO_CONTACT_DAMAGE);
            AddComponent(coll);
            Constants.SetLayerDepth(this, Constants.LayerDepth.Enemy);

            BehaviorScript health = new StalfoHealthManagement(Constants.STALFO_HEALTH);
            AddComponent(health);
        }
    }
}
