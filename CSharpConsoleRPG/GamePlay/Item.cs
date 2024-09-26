using System;

namespace CSharpConsoleRPG.GamePlay
{
    public abstract class Item
    {
        // Private fields
        private string name;
        private int level;
        private int buyValue;
        private int sellValue;
        private int rarity;

        // Constructor
        public Item(int level)
        {
            this.name = "NONE";
            Random random = new Random();
            this.level = random.Next(level);
            this.rarity = random.Next(5);
            this.buyValue = level * this.rarity * 10;
            this.sellValue = this.buyValue / 2;
        }

        public Item(string name = "NONE", int level = 0, int buyValue = 0, int sellValue = 0, int rarity = 0)
        {
            this.name = name;
            this.level = level;
            this.buyValue = buyValue;
            this.sellValue = sellValue;
            this.rarity = rarity;
        }

        // Methods
        public string DebugPrint()
        {
            return name;
        }

        // Clone method to be implemented by derived classes
        public abstract Item Clone();

        // Accessor methods
        public string GetName() { return this.name; }
        public int GetLevel() { return this.level; }
        public int GetBuyValue() { return this.buyValue; }
        public int GetSellValue() { return this.sellValue; }
        public int GetRarity() { return this.rarity; }

        //public string Name => this.name;
        //public int Level => this.level;
        //public int BuyValue => this.buyValue;
        //public int SellValue => this.sellValue;
        //public int Rarity => this.rarity;
    }

    // Rarity Enum
    public enum Rarity
    {
        COMMON = 0,
        UNCOMMON,
        RARE,
        LEGENDARY,
        MYTHIC
    }
}
