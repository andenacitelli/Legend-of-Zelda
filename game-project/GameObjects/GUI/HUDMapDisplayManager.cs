using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Items;
using game_project.GameObjects.Link;
using game_project.Levels;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.GUI
{
    class HUDMapDisplayManager : BehaviorScript
    {
        private LinkInventory linkInventory;
        private bool visible = false;

        public HUDMapDisplayManager()
        {
        }

        public override void Update(GameTime gameTime)
        {
            linkInventory = LevelManager.link.GetComponent<LinkInventory>();
            if (!visible)
            {
                if (linkInventory.GetDungeonItemCount((int)ItemInventory.DungeonInventory.MAP) > 0)
                {
                    entity.GetComponent<Sprite>().SetVisible(true);
                    visible = true;

                    LevelManager.backdrop.Minimap.GetComponent<MinimapDisplay>().MinimapVisible();
                }
            }
        }
    }
}
