using game_project.ECS;
using game_project.ECS.Components;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Writing
{
    public class TextShadowEntity : Entity
    {
        public TextShadowEntity(Vector2 pos, string stringToWrite, Color? color = null, float scale = 1f, bool animate = false)
        {
            name = "TextShadowEntity{'" + stringToWrite + "'}";
            TextEntity top = new TextEntity(pos, stringToWrite, color, scale);
            TextEntity shadow = new TextEntity(pos + new Vector2(5, 5), stringToWrite, Color.Black, scale);

            Constants.SetLayerDepth(top, Constants.LayerDepth.Text);
            Constants.SetLayerDepth(shadow, Constants.LayerDepth.Backdrop);

            var transform = GetComponent<Transform>();
            transform.AddChild(top);
            transform.AddChild(shadow);

        }

    }
}
