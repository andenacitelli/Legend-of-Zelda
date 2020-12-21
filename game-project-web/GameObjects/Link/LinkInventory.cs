using game_project.Content.Sprites.SpriteFactories;
using game_project.ECS;
using game_project.ECS.Components;
using game_project.GameObjects.Items;
using game_project.GameObjects.Projectiles;
using game_project.Sounds;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using static game_project.GameObjects.Items.ItemInventory;

namespace game_project.GameObjects.Link
{
    // TODO: remove from Link and make more global

    class LinkInventory : BehaviorScript
    {
        public List<UseableItems> useInventory;
        public List<PassiveItems> passiveInventory;
        public List<DungeonItems> dungeonInventory;
        private UseInventory currentB = UseInventory.BOMB;
        private WeaponTypes currentWeapon = WeaponTypes.WOODEN_SWORD;
        private BoomerangTypes currentBoomerang = BoomerangTypes.WOODEN_BOOMERANG;

        // bomb / item usage
        private Vector2 bombAdd = new Vector2(0, 0);

        public LinkInventory()
        {
            useInventory = new List<UseableItems>()
            {
                new UseableItems(UseableItems.Types.BOOMERANG, new Amount(1, 1)),
                new UseableItems(UseableItems.Types.BOMB, new Amount(8, 8)),
                new UseableItems(UseableItems.Types.BOW, new Amount(0, 1)),
                new UseableItems(UseableItems.Types.RED_CANDLE, new Amount(0, 1)),
                new UseableItems(UseableItems.Types.FLUTE, new Amount(0, 1)),
                new UseableItems(UseableItems.Types.FOOD, new Amount(0, 1)),
                new UseableItems(UseableItems.Types.LETTER, new Amount(0, 1)),
                new UseableItems(UseableItems.Types.MAGIC_ROD, new Amount(0, 1))
            };
            passiveInventory = new List<PassiveItems>()
            {
                new PassiveItems(PassiveItems.Types.RUPEES, new Amount(0,20)),
                new PassiveItems(PassiveItems.Types.RAFT, new Amount(0,1)),
                new PassiveItems(PassiveItems.Types.RED_RING, new Amount(0,1)),
                new PassiveItems(PassiveItems.Types.LADDER, new Amount(0,1)),
                new PassiveItems(PassiveItems.Types.POWER_BAND, new Amount(0,1)),
                new PassiveItems(PassiveItems.Types.ARROWS, new Amount(0,8)),
                new PassiveItems(PassiveItems.Types.TRIFORCE, new Amount(0,9))
            };
            dungeonInventory = new List<DungeonItems>()
            {
                new DungeonItems(DungeonItems.Types.COMPASS, new Amount(0, 1)),
                new DungeonItems(DungeonItems.Types.MAP, new Amount(0, 1)),
                new DungeonItems(DungeonItems.Types.KEY, new Amount(0, 6)),
                new DungeonItems(DungeonItems.Types.BOSS_KEY, new Amount(0, 1)),
            };
        }

        public UseInventory GetBKey()
        {
            return currentB;
        }

        public void UpdateBKey(UseInventory selected)
        {
            currentB = selected;
        }

        public WeaponTypes GetCurrentWeapon()
        {
            return currentWeapon;
        }

        public void UpdateCurrentWeapon(WeaponTypes selected)
        {
            currentWeapon = selected;
        }

        public BoomerangTypes GetCurrentBoomerang()
        {
            return currentBoomerang;
        }

        public void UpdateCurrentBoomerang(BoomerangTypes selected)
        {
            currentBoomerang = selected;
        }

        public void LinkUseBItem()
        {
            switch (GetBKey())
            {
                case UseInventory.BOMB:
                    if (useInventory[(int)UseInventory.BOMB].amount.current > 0)
                    {
                        Sound.PlaySound(Sound.SoundEffects.Bomb_Drop, entity, !Sound.SOUND_LOOPS); // No way to tell if it's a bomb from item class, so we play it from here
                        Item bomb = new Item(ItemSpriteFactory.Instance.CreateBomb(), entity.GetComponent<Transform>().WorldPosition + bombAdd);
                        bomb.AddComponent(new BombBehaviorScript());
                        Scene.Add(bomb);
                        useInventory[(int)UseInventory.BOMB].amount.AddCurrent(-1);

                        // Console.WriteLine("Bomb Amount = " + inventory.useInventory[(int)LinkInventory.UseInventory.BOMB].amount);
                    }
                    break;
                case UseInventory.BOOMERANG:
                    if (useInventory[(int)UseInventory.BOOMERANG].amount.current > 0)
                    {
                        new Boomerang(LinkBehavior.linkDirection, entity);
                        useInventory[(int)UseInventory.BOOMERANG].amount.AddCurrent(-1);

                        // Console.WriteLine("Bomb Amount = " + inventory.useInventory[(int)LinkInventory.UseInventory.BOMB].amount);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Inventory BKey or item behavior not implemented.");
                    break;
            }
        }

        public void AddBombs()
        {
            useInventory[(int)UseInventory.BOMB].amount.AddCurrent(Constants.BOMB_PICKUP_COUNT);
        }

        public void AddUseableItem(int itemIndex)
        {
            useInventory[itemIndex].amount.AddCurrent(1);
        }

        public void AddPassiveItem(int itemIndex, int count = 1)
        {
            passiveInventory[itemIndex].amount.AddCurrent(count);
        }

        public void AddDungeonItem(int itemIndex)
        {
            dungeonInventory[itemIndex].amount.AddCurrent(1);
        }

        public int GetUseableItemCount(int itemIndex)
        {
            return useInventory[itemIndex].amount.current;
        }

        public int GetPassiveItemCount(int itemIndex)
        {
            return passiveInventory[itemIndex].amount.current;
        }
        public int GetDungeonItemCount(int itemIndex)
        {
            return dungeonInventory[itemIndex].amount.current;
        }

        public void SetBombPos(Vector2 bombPos)
        {
            bombAdd = bombPos;
        }
    }
}
