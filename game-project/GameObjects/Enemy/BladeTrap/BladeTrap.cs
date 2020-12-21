using game_project.CollisionResponse;
using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS.Components;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Enemy
{
    class BladeTrap : Enemy
    {
        public BladeTrap(Vector2 pos)
        {
            GetComponent<Transform>().position = pos;

            BasicSprite spriteImage = EnemySpriteFactory.Instance.CreateBladeTrap();
            Sprite sprite = new Sprite(spriteImage);
            AddComponent(sprite);
            sprite.SetAnimate(false);

            BehaviorScript movement = new BladeTrapMovement();
            AddComponent(movement);

            var coll = new Collider();
            coll.response = new BladeTrapCollisionResponse(this, Constants.BLADETRAP_CONTACT_DAMAGE); 
            AddComponent(coll);
            Constants.SetLayerDepth(this, Constants.LayerDepth.Enemy);

        }
    }
}
