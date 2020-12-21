using game_project.ECS.Components;
using game_project.Levels;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace game_project.ECS.Systems
{
    class ColliderSystem : BaseSystem<Collider>
    {
        public static List<Collider> Colliders { get { return components; } }

        // Draw colliders as boxes on top of sprites. Useful for debugging.
        public static bool DrawDebug = false;


        public static void Check()
        {
            for (int i = 0; i < Colliders.Count; i++)
            {
                var collider = Colliders[i];
                if (!collider.setForDeletion && collider.entity.State == EntityStates.Playing)
                {
                    collider.Check();
                }
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            if (DrawDebug)
            {
                foreach (Collider component in components)
                {
                    if (!component.setForDeletion && component.entity != null && component.entity.State != EntityStates.Disabled)
                    {
                        component.Draw(spriteBatch);
                    }
                }
            }
        }
    }
}
