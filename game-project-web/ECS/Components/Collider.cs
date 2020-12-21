using game_project.CollisionDetection;
using game_project.ECS.Systems;
using game_project.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Color = Microsoft.Xna.Framework.Color;

namespace game_project.ECS.Components
{
    class Collider : Component
    {
        // Set a collider to static to only test against other collision objects (not yet implemented)
        public bool Dynamic = true;

        public HashSet<Collider> Collisions { get { return collisions; } }
        private HashSet<Collider> collisions = new HashSet<Collider>();

        public bool HasCollisions { get { return Collisions.Count > 0; } }

        public CollisionResponse response; // TODO: should this be allowed to change on the fly?
        public IColliderBounds colliderBounds;

        public bool CollidingWithRigid = false;


        public Collider()
        {
            response = new BaseCollisionResponse(entity);
            ColliderSystem.Register(this);

            colliderBounds = new SpriteColliderBounds(this);
        }

        public Collider(RectangleF bounds) : this()
        {
            this.colliderBounds = new ManualColliderBounds(this, bounds);
        }


        public bool TestCollision(Collider other)
        {
            return colliderBounds.bounds.Intersects(other.colliderBounds.bounds);
        }

        public override void Update(GameTime gameTime)
        {
            CollidingWithRigid = false;

            // update bounding box
            colliderBounds.Update();

            // clear reported collisions from previous frame
            collisions.Clear();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Color col = Color.Green;
            if (response.enabled)
            {
                col = Color.Red;
            }
            var t = new Texture2D(Game1.graphics.GraphicsDevice, 1, 1);
            t.SetData(new[] { col });

            var c = colliderBounds.bounds;
            var r = new Microsoft.Xna.Framework.Rectangle((int)c.X, (int)c.Y, (int)c.Width, (int)c.Height);

            Raster.DrawRectangle(spriteBatch, r, Color.Red, 2);
        }


        public void Check()
        {
            // check collisions
            for (int i = 0; i < ColliderSystem.Colliders.Count; i++)
            {
                var collider = ColliderSystem.Colliders[i];
                if (collider != this)
                {
                    if (TestCollision(collider))
                    {
                        collisions.Add(collider);

                        // respond to the collision
                        response.Visit(collider.response);
                    }
                }
            }

        }
    }
}
