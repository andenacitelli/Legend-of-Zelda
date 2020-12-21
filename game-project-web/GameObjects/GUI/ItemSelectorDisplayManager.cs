using game_project.Controllers;
using game_project.ECS.Components;
using game_project.GameObjects.Link;
using game_project.GameObjects.Items;
using game_project.Levels;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.GUI
{
    class ItemSelectorDisplayManager : BehaviorScript
    {
        public ItemSelectorDisplayManager()
        {
        }

        public override void Update(GameTime gameTime)
        {
            if (GameStateManager.State == GameStates.ItemSelection)
            {
                if (Input.Down(Input.Inputs.SELECT_ITEM_LEFT))
                {
                    UpdateItemIndex(1);
                }
                else if (Input.Down(Input.Inputs.SELECT_ITEM_RIGHT))
                {
                    UpdateItemIndex(-1);
                }
                else if (Input.Down(Input.Inputs.SELECT_ITEM_UP) && LevelManager.backdrop.CurrentMaxItemCount > 4)
                {
                    UpdateItemIndex(-4);
                }
                else if (Input.Down(Input.Inputs.SELECT_ITEM_DOWN) && LevelManager.backdrop.CurrentMaxItemCount > 4)
                {
                    UpdateItemIndex(4);
                }
                else if (Input.Down(Input.Inputs.SELECT_ITEM_SELECT)) // item selection
                {
                    LevelManager.link.GetComponent<LinkInventory>().UpdateBKey((ItemInventory.UseInventory)LevelManager.backdrop.CurrentItemSelectorIndex);
                }

                entity.GetComponent<Transform>().position = LevelManager.backdrop.ItemSelectorPositions[LevelManager.backdrop.CurrentItemSelectorIndex];
            }
        }

        private void UpdateItemIndex(int amount)
        {
            LevelManager.backdrop.CurrentItemSelectorIndex += amount;
            if (LevelManager.backdrop.CurrentItemSelectorIndex >= LevelManager.backdrop.CurrentMaxItemCount) LevelManager.backdrop.CurrentItemSelectorIndex -= LevelManager.backdrop.CurrentMaxItemCount;
            if (LevelManager.backdrop.CurrentItemSelectorIndex <= -1) LevelManager.backdrop.CurrentItemSelectorIndex += LevelManager.backdrop.CurrentMaxItemCount;
        }
    }
}
