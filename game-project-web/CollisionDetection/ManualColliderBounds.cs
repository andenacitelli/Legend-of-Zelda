using game_project.ECS.Components;

namespace game_project.CollisionDetection
{
    class ManualColliderBounds : IColliderBounds
    {
        public RectangleF bounds { get; set; } = new RectangleF();

        private RectangleF dimensions;

        private Collider collider;

        public ManualColliderBounds(Collider coll, RectangleF dimensions)
        {
            this.dimensions = dimensions;
            this.collider = coll;
        }

        public void Update()
        {
            // update bounding box
            Transform transform = collider.entity.GetComponent<Transform>();

            RectangleF b = bounds;
            b.X = transform.WorldPosition.X + dimensions.X;
            b.Y = transform.WorldPosition.Y + dimensions.Y;
            b.Width = dimensions.Width;
            b.Height = dimensions.Height;

            bounds = b;
        }

    }
}
