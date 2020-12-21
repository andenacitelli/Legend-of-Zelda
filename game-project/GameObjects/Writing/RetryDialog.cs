using game_project.Controllers;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace game_project.GameObjects.Writing
{
    public class RetryDialog : Entity
    {
        public TextShadowEntity text;
        public RetryDialog()
        {
            var transform = GetComponent<Transform>();

            var viewport = Game1.viewport.Bounds;
            var center = viewport.Width / 2;
            string message = "Press Enter to Retry";
            var position = new Vector2(center - GameContent.Font.hudFont.MeasureString(message).X / 8, 660);

            text = new TextShadowEntity(position, message, scale: .5f);

            foreach (var child in text.GetComponent<Transform>().Children)
            {
                child.entity.GetComponent<Text>().TextHorzAlign = Constants.TextHorizontal.CenterAligned;
            }

            text.State = EntityStates.Disabled;
            transform.AddChild(text);

            AddComponent(new RetryDialogBehavior(text));

        }

        public void Show()
        {
            var script = GetComponent<RetryDialogBehavior>();
            script.trigger = true;
        }

    }

    public class RetryDialogBehavior : BehaviorScript
    {
        public float t = 0f;
        public float total = 2000f;
        private TextShadowEntity text;
        public bool trigger = false;


        public RetryDialogBehavior(TextShadowEntity text)
        {
            this.text = text;
        }

        public override void Update(GameTime gameTime)
        {
            if (trigger)
            {
                if (t < total)
                {
                    t += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                }
                else
                {
                    text.State = EntityStates.Playing;

                    if (Input.KeyDown(Keys.Enter))
                    {
                        LevelManager.Reset();
                        trigger = false;
                    }
                }
            }

        }
    }
}
