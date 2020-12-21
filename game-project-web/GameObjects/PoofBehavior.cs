using game_project.ECS;
using game_project.ECS.Components;
using game_project.Levels;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Enemy
{
    class PoofBehavior : BehaviorScript
    {
        private Entity child;
        private int currentUpdate;
        private int updateFrame;

        public PoofBehavior(Entity givenEntity)
        {
            child = givenEntity;
            child.State = EntityStates.Disabled; // disable child before poof
            updateFrame = 0;
            currentUpdate = 0;
        }

        public override void Update(GameTime gameTime)
        {
            // if updateFrame not set
            if (updateFrame == 0)
            {
                entity.GetComponent<Sprite>().SetUpdateFrameSpeed(Constants.POOF_UPDATE_FRAME_SPEED);
                updateFrame = (int)entity.GetComponent<Sprite>().sprite.updatesPerFrame * entity.GetComponent<Sprite>().sprite.frames.Count;
            }

            currentUpdate++;
            if (currentUpdate == updateFrame)
            {
                child.State = EntityStates.Playing; // enable child after poof
                entity.State = EntityStates.Disabled;
            }
        }
    }
}
