using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS.Components;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;
using game_project.CollisionResponse;

namespace game_project.GameObjects.Enemy
{
    class Rope : Enemy
    {

        public Rope(Vector2 pos)
        {
            GetComponent<Transform>().position = pos;

            BasicSprite spriteImage = EnemySpriteFactory.Instance.CreateRopeLeft();
            Sprite sprite = new Sprite(spriteImage);
            AddComponent(sprite);
            sprite.SetAnimate(true);

            //var coll = new Collider();
            //coll.response = new EnemyCollisionResponse(this, Constants.ROPE_CONTACT_DAMAGE); 
            //AddComponent(coll);
            //Constants.SetLayerDepth(this, Constants.LAYER_DEPTH_ENEMY);
        }
    }
}
