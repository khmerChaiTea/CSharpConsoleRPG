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
        public Item(string name = "NONE", int level = 0, int buyValue = 0, int sellValue = 0, int rarity = 0)
        {
            this.name = name;
            this.level = level;
            this.buyValue = buyValue;
            this.sellValue = sellValue;
            this.rarity = rarity;
        }

        // Destructor (not needed in C# due to garbage collection)
        // No need to define a destructor unless handling unmanaged resources

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
    }
}
