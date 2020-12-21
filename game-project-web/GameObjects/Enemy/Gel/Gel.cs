using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS.Components;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;
using game_project.CollisionResponse;

namespace game_project.GameObjects.Enemy
{
    class Gel : Enemy
    {

        public Gel(Vector2 pos)
        {
            GetComponent<Transform>().position = pos;

            BasicSprite spriteImage = EnemySpriteFactory.Instance.CreateGelNavy();
            Sprite sprite = new Sprite(spriteImage);
            AddComponent(sprite);
            sprite.SetAnimate(true);

            BehaviorScript movement = new GelMovement();
            AddComponent(movement);

            var coll = new Collider();
            coll.response = new EnemyCollisionResponse(this, Constants.GEL_CONTACT_DAMAGE);
            AddComponent(coll);
            Constants.SetLayerDepth(this, Constants.LayerDepth.Enemy);

            BehaviorScript health = new EnemyHealthManagement(Constants.GEL_HEALTH);
            AddComponent(health);
        }
    }
}
