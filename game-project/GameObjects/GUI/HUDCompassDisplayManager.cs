using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Items;
using game_project.GameObjects.Link;
using game_project.Levels;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.GUI
{
    class HUDCompassDisplayManager : BehaviorScript
    {
        private LinkInventory linkInventory;
        private bool visible = false;

        public HUDCompassDisplayManager()
        {
        }

        public override void Update(GameTime gameTime)
        {
            linkInventory = LevelManager.link.GetComponent<LinkInventory>();
            if (!visible)
            {
                if (linkInventory.GetDungeonItemCount((int)ItemInventory.DungeonInventory.COMPASS) > 0)
                {
                    entity.GetComponent<Sprite>().SetVisible(true);
                    visible = true;

                    LevelManager.backdrop.Minimap.GetComponent<MinimapDisplay>().BossRoomVisible();
                }
            }
        }
    }
}
