using game_project.CollisionResponse;
using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.Sprites.Sprites;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Link
{
    public class Link : Entity
    {
        public Link(Vector2 pos)
        {

            // ToDo: move to an appropriate place in this constructor
            AddComponent(new LinkLevelBehavior());

            this.name = "Link";

            // don't do any logic here, just add Components that do the logic
            Transform transform = GetComponent<Transform>();
            transform.position = pos;

            BasicSprite imageSprite = LinkSpriteFactory.Instance.CreateLinkWalkingUp();
            Sprite sprite = new Sprite(imageSprite);
            sprite.SetAnimate(false);
            AddComponent(sprite);

            var sword = new Sword();
            transform.AddChild(sword);
            BehaviorScript script = new LinkBehavior(sword);
            AddComponent(script);

            BehaviorScript inventory = new LinkInventory();
            AddComponent(inventory);

            BehaviorScript healthManagement = new LinkHealthManagement();
            AddComponent(healthManagement);

            Collider coll = new Collider(new RectangleF(2.5f, 40, 48, 12));
            AddComponent(coll);
            coll.response = new LinkCollisionResponse(this);



            Constants.SetLayerDepth(this, Constants.LayerDepth.Player);


            //transform.AddChild(new TransformTest());


        }

    }
}
