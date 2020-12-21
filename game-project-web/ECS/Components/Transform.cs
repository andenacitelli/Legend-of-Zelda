using game_project.ECS.Systems;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace game_project.ECS.Components
{
    public class Transform : Component
    {
        public Transform Parent = null;
        public List<Transform> Children { get; } = new List<Transform>();
        public Vector2 position = Vector2.Zero;
        public Vector2 lastPosition = Vector2.Zero;
        public Vector2 WorldPosition
        {
            get { return GetWorldPosition(); }
        }
        public float layerDepth = 0f;
        public Vector2 scale = Vector2.Zero;
        public float rotation = 0;
        public Matrix LocalMatrix { get { return localMatrix; } }
        public Matrix WorldMatrix { get { return GetWorldMatrix(); } }

        // Matrices
        private Vector2 worldPosition = Vector2.Zero;
        private Matrix worldMatrix = Matrix.Identity;
        private Matrix localMatrix = Matrix.Identity;

        public Transform()
        {
            TransformSystem.Register(this);
        }

        public Transform(Vector2 position, float rotation = 0, float layerDepth = 0)
        {
            this.position = position;
            this.rotation = rotation;
            this.layerDepth = layerDepth;
        }

        public void AddChild(Entity child)
        {
            Children.Add(child.GetComponent<Transform>());
            child.GetComponent<Transform>().Parent = this;
        }


        public void Translate(Vector2 pos)
        {
            position += pos;
        }

        public void Rotate(float degrees)
        {
            rotation += degrees;
        }

        // Recursively combine parent transform matrices
        private Matrix GetWorldMatrix()
        {
            Matrix totalMatrix = localMatrix;
            if (Parent != null)
            {
                totalMatrix = totalMatrix * Parent.GetWorldMatrix();
            }
            return totalMatrix;
            // TODO: perhaps optimize this so GetWorldMatrix only runs
            // on the TransformSystem.Update(), instead of on every
            // call of Transform.WorldPosition;
        }

        private Vector2 GetWorldPosition()
        {
            // Reset the local transformation matrix
            localMatrix = Matrix.Identity;
            // Create local transformation matrix from set position and rotation values.
            float rad = MathHelper.ToRadians(rotation);
            localMatrix *= Matrix.CreateTranslation(position.X, position.Y, 0f);
            //localMatrix *= Matrix.CreateRotationZ(rad);
            // Apply transformation matrix to Zero vector to get world position.
            worldPosition = Vector2.Transform(Vector2.Zero, GetWorldMatrix());
            return worldPosition;
        }


        public override void Update(GameTime gameTime)
        {
            GetWorldPosition();
            lastPosition = position;
        }
    }

}
