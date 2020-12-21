using game_project.ECS;
using game_project.ECS.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_project.GameObjects.Link
{
    class DragAndReset : BehaviorScript
    {
        private Entity other;
        private int frames = 0;
        public DragAndReset(Entity wallmaster)
        {
            this.other = wallmaster;
        }

        public override void Update(GameTime gameTime)
        {
            // If Link has been carried specified number of frames, reset 
            if (frames >= 180)
            {
                new Commands.CommandReset().Execute();
                return;
            }

            // Instead of setting positions equal, we reparent Link to the Wallmaster
            if (frames == 0)
            {
                other.GetComponent<Transform>().AddChild(entity);
            }

            entity.GetComponent<Transform>().position = new Vector2(0);

            // One more frame in the sequence 
            frames++;
        }
    }
}
