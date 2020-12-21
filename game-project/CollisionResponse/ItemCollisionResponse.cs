using System;
using game_project.ECS;
using game_project.GameObjects.Enemy;
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

                // logic for adding items to HUD depending on type
                Link link = (Link)other.entity;
                LinkInventory inventory = link.GetComponent<LinkInventory>();

                // update item inventory numbers
                switch (currentItem.GetItemType())
                {
                    case "heart":
                        Sound.PlaySound(Sound.SoundEffects.Get_Heart, entity, !Sound.SOUND_LOOPS);
                        link.GetComponent<LinkHealthManagement>().IncreaseHealth(Constants.LINK_HEALTH_PER_HEART);
                        break;
                    case "fairy":
                        // increment health by an amount
                        break;
                    case "bomb":
                        Sound.PlaySound(Sound.SoundEffects.Fanfare, entity, !Sound.SOUND_LOOPS);
                        inventory.AddBombs();
                        // Console.WriteLine("Bombs = " + inventory.GetUseableItemCount((int)ItemInventory.UseInventory.BOMB));
                        break;
                    case "arrow":
                        Sound.PlaySound(Sound.SoundEffects.Fanfare, entity, !Sound.SOUND_LOOPS);
                        inventory.AddPassiveItem((int)ItemInventory.PassiveIventory.ARROWS);
                        // Console.WriteLine("Arrows = " + inventory.GetPassiveItemCount((int)ItemInventory.PassiveIventory.ARROWS));
                        break;
                    case "regularkey":
                        Sound.PlaySound(Sound.SoundEffects.Fanfare, entity, !Sound.SOUND_LOOPS);
                        inventory.AddDungeonItem((int)ItemInventory.DungeonInventory.KEYS);
                        // Console.WriteLine("Keys = " + inventory.GetDungeonItemCount((int)ItemInventory.DungeonInventory.KEYS));
                        break;
                    case "bosskey":
                        Sound.PlaySound(Sound.SoundEffects.Fanfare, entity, !Sound.SOUND_LOOPS);
                        inventory.AddDungeonItem((int)ItemInventory.DungeonInventory.BOSS_KEY);
                        // Console.WriteLine("Boss Key = " + inventory.GetDungeonItemCount((int)ItemInventory.DungeonInventory.BOSS_KEY));
                        break;
                    case "clock":
                        // freeze enemies for a time
                        LevelManager.FreezeAllEnemies();
                        break;
                    case "compass":
                        Sound.PlaySound(Sound.SoundEffects.Fanfare, entity, !Sound.SOUND_LOOPS);
                        inventory.AddDungeonItem((int)ItemInventory.DungeonInventory.COMPASS);
                        // Console.WriteLine("Compass = " + inventory.GetDungeonItemCount((int)ItemInventory.DungeonInventory.COMPASS));
                        break;
                    case "yellowmap":
                    case "bluemap":
                        Sound.PlaySound(Sound.SoundEffects.Fanfare, entity, !Sound.SOUND_LOOPS);
                        inventory.AddDungeonItem((int)ItemInventory.DungeonInventory.MAP);
                        // Console.WriteLine("Map = " + inventory.GetDungeonItemCount((int)ItemInventory.DungeonInventory.MAP));
                        break;
                    case "rupee":
                        inventory.AddPassiveItem((int)ItemInventory.PassiveIventory.RUPEES, currentItem.value);
                        // Console.WriteLine("Rupees = " + inventory.GetPassiveItemCount((int)ItemInventory.PassiveIventory.RUPEES));
                        Sound.PlaySound(Sound.SoundEffects.Get_Rupee, !Sound.SOUND_LOOPS);
                        break;
                    default:

                        break;
                }

                Entity.Destroy(entity);
            }
        }

    }
}
