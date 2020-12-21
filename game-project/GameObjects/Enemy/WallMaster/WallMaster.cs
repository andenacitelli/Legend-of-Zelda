using game_project.CollisionResponse;
using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS.Components;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Enemy
{
    class WallMaster : Enemy
    {

        public WallMaster(Vector2 pos, Constants.Direction startingDirection)
        {
            GetComponent<Transform>().position = pos;

            BasicSprite spriteImage = EnemySpriteFactory.Instance.CreateWallMasterRight();
            Sprite sprite = new Sprite(spriteImage);
            AddComponent(sprite);
            sprite.SetAnimate(true);

            BehaviorScript state = new WallMasterMovement(startingDirection);
            AddComponent(state);

            var coll = new Collider();
            coll.response = new EnemyCollisionResponse(this, Constants.STALFO_CONTACT_DAMAGE);
            AddComponent(coll);
            Constants.SetLayerDepth(this, Constants.LayerDepth.Enemy);

            BehaviorScript health = new EnemyHealthManagement(Constants.WALLMASTER_HEALTH);
            AddComponent(health);
        }
    }
}
