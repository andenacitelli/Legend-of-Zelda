using Bridge.Utils;
using game_project.ECS;
using game_project.ECS.Components;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace game_project.GameObjects.Writing
{
    public class TextShadowEntity : Entity
    {
        public TextShadowEntity(Vector2 pos, string stringToWrite, Color? color = null, float scale = 1f, bool animate = false)
        {

            name = "TextShadowEntity{'" + stringToWrite + "'}";

            //Console.Log("loading TextShadowEntity");
            TextEntity top = new TextEntity(pos, stringToWrite, color, scale);
            TextEntity shadow = new TextEntity(pos + new Vector2(5, 5), stringToWrite, Color.Black, scale);
            //Console.Log("loaded TextShadowEntity");

            Constants.SetLayerDepth(top, Constants.LayerDepth.Text);
            Constants.SetLayerDepth(shadow, Constants.LayerDepth.Backdrop);

            var transform = GetComponent<Transform>();
            transform.AddChild(top);
            transform.AddChild(shadow);

        }

    }
}
