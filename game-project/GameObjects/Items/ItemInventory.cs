using game_project.ECS.Components;

namespace game_project.GameObjects.Items
{
    class ItemInventory : BehaviorScript
    {
        public enum UseInventory
        {
            BOOMERANG = 0,
            BOMB,
            BOW,
            CANDLE,
            FLUTE,
            FOOD,
            LETTER,
            MAGIC_ROD
        }

        public enum PassiveIventory
        {
            RUPEES = 0,
            RAFT,
            RING,
            LADDER,
            POWER_BAND,
            ARROWS,
            TRIFORCE
        }

        public enum DungeonInventory
        {
            COMPASS,
            MAP,
            KEYS,
            BOSS_KEY
        }

        public enum WeaponTypes
        {
            WOODEN_SWORD,
            MAGIC_SWORD
        }

        public enum BoomerangTypes
        {
            WOODEN_BOOMERANG,
            MAGIC_BOOMERANG
        }
    }

    public class UseableItems
    {
        public enum Types
        {
            BOOMERANG = 0,
            MAGIC_BOOMERANG,
            BOMB,
            BOW,
            BOW_ARROWS,
            RED_CANDLE,
            BLUE_CANDLE,
            FLUTE,
            FOOD,
            LETTER,
            MAGIC_ROD
        }
        public Types type;
        public Amount amount;
        
        // default
        public UseableItems() { }
        // set type and amount
        public UseableItems(Types type, Amount amount)
        {
            this.type = type;
            this.amount = amount;
        }
    }

    public class PassiveItems
    {
        public enum Types
        {
            RUPEES = 0,
            RAFT,
            XXX, // unsure
            RED_RING,
            BLUE_RING,
            LADDER,
            YYY, // unsure
            POWER_BAND,
            ARROWS,
            TRIFORCE
        }
        public Types type;
        public Amount amount;

        // default
        public PassiveItems() { }
        // set type and amount
        public PassiveItems(Types type, Amount amount)
        {
            this.type = type;
            this.amount = amount;
        }
    }

    public class DungeonItems
    {
        public enum Types
        {
            COMPASS = 0,
            MAP,
            KEY,
            BOSS_KEY
        }
        public Types type;
        public Amount amount;

        // default
        public DungeonItems() { }
        // set type and amount
        public DungeonItems(Types type, Amount amount)
        {
            this.type = type;
            this.amount = amount;
        }
    }

    public class Amount
    {
        // current amount of what we have
        public int current = 0;
        // max amount we can carry
        public int max;

        public void AddCurrent(int value)
        {
            current += value;
            // check you don't have more than you can hold
            if (current > max)
            {
                current = max;
            }
        }
        
        // update max if you never need to (like inventory upgrades)
        public void SetMax(int value)
        {
            max = value;
        }

        // default constructor
        public Amount() { }
        // constructor that sets [current] and [max]
        public Amount(int current, int max)
        {
            this.max = max;
            this.AddCurrent(current);
        }

        public override string ToString()
        {
            return this.current.ToString();
        }

    }
}
