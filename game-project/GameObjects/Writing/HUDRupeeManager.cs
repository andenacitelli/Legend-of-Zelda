using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Items;
using game_project.GameObjects.Link;
using game_project.Levels;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Writing
{
    class HUDRupeeManager : BehaviorScript
    {
        private LinkInventory linkInventory;

        public HUDRupeeManager()
        {

        }

        public override void Update(GameTime gameTime)
        {
            linkInventory = LevelManager.link.GetComponent<LinkInventory>();
            entity.GetComponent<Text>().CurrentString = "X" + linkInventory.GetPassiveItemCount((int)ItemInventory.PassiveIventory.RUPEES);
        }
    }
}
