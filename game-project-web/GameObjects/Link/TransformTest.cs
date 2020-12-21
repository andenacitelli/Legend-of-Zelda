using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Items;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Link
{
    public class TransformTest : Entity
    {
        public TransformTest()
        {
            Transform transform = GetComponent<Transform>();
            transform.Translate(new Vector2(50, 0));
            transform.Rotate(45);

            BasicSprite s = ItemSpriteFactory.Instance.CreateBlueArrow();
            AddComponent(new Sprite(s));

            TransformDebugger t = new TransformDebugger();
            AddComponent(t);

            // Add test child entity
            // Position purely arbitrary and just for testing
            Item child = new Item(EnemySpriteFactory.Instance.CreateBlueKeese(), new Vector2(200, 200));
            GetComponent<Transform>().AddChild(child);

            Transform childTransform = child.GetComponent<Transform>();
            childTransform.position = new Vector2(100, 10);

        }
    }

    public class TransformDebugger : BehaviorScript
    {
        int frame = 0;

        public override void Update(GameTime gameTime)
        {
            frame++;

            float delta = (float)gameTime.TotalGameTime.TotalMilliseconds;
            var transform = entity.GetComponent<Transform>();
            transform.Rotate(1.1f);

            if (frame % 30 == 0)
            {
                //transform.Rotate(10);

            }
        }
    }
}
