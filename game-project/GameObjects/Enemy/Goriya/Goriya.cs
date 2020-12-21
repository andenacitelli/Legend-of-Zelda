using game_project.CollisionResponse;
using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS.Components;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Enemy
{
    public class Goriya : Enemy
    {
        public Goriya(Vector2 pos, string color = "red")
        {
            GetComponent<Transform>().position = pos;
            BasicSprite spriteImage;

            switch (color.ToLower())
            {
                case "red":
                    spriteImage = EnemySpriteFactory.Instance.CreateRedGoriyaRight();
                    break;

                case "blue":
                    spriteImage = EnemySpriteFactory.Instance.CreateBlueGoriyaRight();
                    break;

                default:
                    // Console.WriteLine("Goriya @ Goriya(string color): Unrecognized color! Defaulting to red.");
                    color = "red";
                    spriteImage = EnemySpriteFactory.Instance.CreateRedGoriyaRight();
                    break;
            }

            // add sprite component
            Sprite sprite = new Sprite(spriteImage);
            AddComponent(sprite);
            sprite.SetAnimate(true);

            // add behavior component
            BehaviorScript behavior = new GoriyaBehavior(color);
            AddComponent(behavior);

            var coll = new Collider();
            coll.response = new EnemyCollisionResponse(this, Constants.GORIYA_CONTACT_DAMAGE);
            AddComponent(coll);
            Constants.SetLayerDepth(this, Constants.LayerDepth.Enemy);

            BehaviorScript health = new EnemyHealthManagement(Constants.GORIYA_HEALTH);
            AddComponent(health);
        }

    }
}
