using System;
using game_project.ECS;
using game_project.GameObjects.GUI;
using game_project.GameObjects.Items;
using game_project.GameObjects.Link;
using game_project.Levels;
using game_project.Sounds;

namespace game_project.CollisionResponse
{
    public class ItemCollisionResponse : ECS.Components.CollisionResponse
    {
        private bool collided = false;
        private Item currentItem;
        public ItemCollisionResponse(Item entity) : base(entity)
        {
            currentItem = entity;
        }

        public override void Visit(ECS.Components.CollisionResponse other)
        {
            other.ResolveCollision(this);
        }

        public override void ResolveCollision(LinkCollisionResponse other)
        {
            if (!collided)
            {
                collided = true;

                // Actual item pickup is the fanfare, selecting from inventory is Get_Item
                Sound.PlaySound(Sound.SoundEffects.Fanfare, entity, !Sound.SOUND_LOOPS);

                // logic for adding items to HUD depending on type
                Link link = (Link)other.entity;
                LinkInventory inventory = link.GetComponent<LinkInventory>();

                // update item inventory numbers
                switch (currentItem.GetItemType())
                {
                    case "fairy":
                        // increment health by an amount
                        break;
                    case "bomb":
                        inventory.AddBombs();
                        // Console.WriteLine("Bombs = " + inventory.GetUseableItemCount((int)ItemInventory.UseInventory.BOMB));
                        break;
                    case "arrow":
                        inventory.AddPassiveItem((int)ItemInventory.PassiveIventory.ARROWS);
                        // Console.WriteLine("Arrows = " + inventory.GetPassiveItemCount((int)ItemInventory.PassiveIventory.ARROWS));
                        break;
                    case "regularkey":
                        inventory.AddDungeonItem((int)ItemInventory.DungeonInventory.KEYS);
                        // Console.WriteLine("Keys = " + inventory.GetDungeonItemCount((int)ItemInventory.DungeonInventory.KEYS));
                        break;
                    case "bosskey":
                        inventory.AddDungeonItem((int)ItemInventory.DungeonInventory.BOSS_KEY);
                        // Console.WriteLine("Boss Key = " + inventory.GetDungeonItemCount((int)ItemInventory.DungeonInventory.BOSS_KEY));
                        break;
                    case "clock":
                        // freeze enemies for a time
                        break;
                    case "compass":
                        inventory.AddDungeonItem((int)ItemInventory.DungeonInventory.COMPASS);
                        // Console.WriteLine("Compass = " + inventory.GetDungeonItemCount((int)ItemInventory.DungeonInventory.COMPASS));
                        break;
                    case "yellowmap":
                    case "bluemap":
                        inventory.AddDungeonItem((int)ItemInventory.DungeonInventory.MAP);
                        // Console.WriteLine("Map = " + inventory.GetDungeonItemCount((int)ItemInventory.DungeonInventory.MAP));
                        break;
                    case "rupee":
                        inventory.AddPassiveItem((int)ItemInventory.PassiveIventory.RUPEES, currentItem.value);
                        // Console.WriteLine("Rupees = " + inventory.GetPassiveItemCount((int)ItemInventory.PassiveIventory.RUPEES));
                        Sound.PlaySound(Sound.SoundEffects.Get_Rupee, false);
                        break;
                    default:

                        break;
                }

                Entity.Destroy(entity);
            }
        }

    }
}
