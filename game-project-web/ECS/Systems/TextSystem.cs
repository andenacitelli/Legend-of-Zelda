using game_project.ECS.Components;
using game_project.Levels;
using Microsoft.Xna.Framework.Graphics;

namespace game_project.ECS.Systems
{
    class TextSystem : BaseSystem<Text>
    {
        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (Text component in components)
            {
                if (!component.setForDeletion && component.entity.State != EntityStates.Disabled)
                {
                    component.Draw(spriteBatch);
                }
            }
        }
    }
}
