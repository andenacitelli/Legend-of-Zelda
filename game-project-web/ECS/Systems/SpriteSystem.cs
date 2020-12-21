using Bridge.Utils;
using game_project.ECS.Components;
using game_project.Levels;
using Microsoft.Xna.Framework.Graphics;

namespace game_project.ECS.Systems
{
    class SpriteSystem : BaseSystem<Sprite>
    {
        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (Sprite component in components)
            {
                // Only components that are attached to an entity should draw
                if (component.entity != null)
                {
                    if (!component.setForDeletion && component.entity.State != EntityStates.Disabled)
                    {
                        component.Draw(spriteBatch);
                    }
                }
            }
        }
    }
}
