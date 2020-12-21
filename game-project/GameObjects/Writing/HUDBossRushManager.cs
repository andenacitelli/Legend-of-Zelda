using game_project.ECS.Components;
using game_project.Levels;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Writing
{
    class HUDBossRushManager : BehaviorScript
    {

        public HUDBossRushManager()
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (Game1.inBossRush)
            {
                var text = entity.GetComponent<Text>();
                text.Visible = true;
                text.CurrentString = "STAGE " + BossRush.CurrentLevel;
            }
        }
    }
}
