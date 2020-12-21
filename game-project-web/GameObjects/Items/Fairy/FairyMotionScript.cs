using System;
using game_project.ECS.Components;
using game_project.Levels;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Items
{
    class FairyMotionScript : BehaviorScript
    {
        float step = 20;
        int distance = 3;
        int frame = 0;
        public override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            float time = (float)gameTime.TotalGameTime.TotalMilliseconds;

            var transform = entity.GetComponent<Transform>();
            if (entity.State == EntityStates.Playing)
            {
                frame++;
                float offset = transform.position.Y + (float)Math.Sin((float)frame / step) * distance;
                transform.position.Y = offset;
            }
        }
    }
}
