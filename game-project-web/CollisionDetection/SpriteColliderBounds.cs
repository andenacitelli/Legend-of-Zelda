using game_project.ECS.Components;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace game_project.CollisionDetection
{
    class SpriteColliderBounds : IColliderBounds
    {
        public RectangleF bounds { get; set; } = new RectangleF();
        private Collider collider;

        public SpriteColliderBounds(Collider collider)
        {
            this.collider = collider;
        }

        public void Update()
        {
            // update bounding box
            Transform transform = collider.entity.GetComponent<Transform>();

            RectangleF b = bounds;
            b.X = transform.WorldPosition.X;
            b.Y = transform.WorldPosition.Y;
            Sprite sprite = collider.entity.GetComponent<Sprite>();
            Rectangle frame = sprite.sprite.frames[sprite.sprite.currentFrame];
            b.Width = frame.Width * sprite.sprite.scalar;
            b.Height = frame.Height * sprite.sprite.scalar;

            bounds = b;
        }


    }
}
