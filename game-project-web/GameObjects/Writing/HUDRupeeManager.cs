using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Items;
using game_project.GameObjects.Link;
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
            linkInventory = Scene.Find("Link").GetComponent<LinkInventory>();
            entity.GetComponent<Text>().CurrentString = "X" + linkInventory.passiveInventory[(int)ItemInventory.PassiveIventory.RUPEES].amount;
        }
    }
}
