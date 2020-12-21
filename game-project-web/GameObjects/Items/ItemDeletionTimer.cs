using game_project.ECS;
using game_project.ECS.Components;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Items
{
    class ItemDeletionTimer : BehaviorScript
    {
        private float time = 0;
        public bool startTimer = false;

        public override void Update(GameTime gameTime)
        {
            // set currentTime upon first call
            if (startTimer)
            {
                time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (time >= Constants.ITEM_DELETION_TIME_MS)
                {
                    Entity.Destroy(entity);
                }
            }
        }
    }
}
