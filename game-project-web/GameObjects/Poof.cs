using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Enemy
{
    class Poof : Entity
    {

        public Poof(Vector2 pos, Entity entity)
        {
            GetComponent<Transform>().position = pos;
            Constants.SetLayerDepth(this, Constants.LayerDepth.Enemy);

            BasicSprite spriteImage = LinkItemSpriteFactory.Instance.CreateExplosion();
            Sprite sprite = new Sprite(spriteImage);
            AddComponent(sprite);
            sprite.SetAnimate(true);

            BehaviorScript behavior = new PoofBehavior(entity);
            AddComponent(behavior);

        }

    }
}
