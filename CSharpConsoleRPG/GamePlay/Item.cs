using System;

namespace CSharpConsoleRPG.GamePlay
{
    public class Item
    {
        // Private fields
        private string name;
        private int buyValue;
        private int sellValue;

        // Constructor
        public Item()
        {
            name = "NONE";
            buyValue = 0;
            sellValue = 0;
        }

        // Destructor (not needed in C# due to garbage collection)
        // No need to define a destructor unless handling unmanaged resources

        // Copy method
        public Item Clone()
        {
            return new Item
            {
                name = this.name,
                buyValue = this.buyValue,
                sellValue = this.sellValue
            };
        }

        // Methods
        public string DebugPrint()
        {
            return name;
        }

        // Properties (optional, if you need to access these fields)
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int BuyValue
        {
            get { return buyValue; }
            set { buyValue = value; }
        }

        public int SellValue
        {
            get { return sellValue; }
            set { sellValue = value; }
        }
    }
}
