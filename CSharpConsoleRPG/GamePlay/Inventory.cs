using System;
using System.Collections.Generic;

namespace CSharpConsoleRPG.GamePlay
{
    public class Inventory
    {
        private int cap;
        private int nrOfItems;
        private List<Item> itemList;

        // Constructor
        public Inventory()
        {
            cap = 10;
            nrOfItems = 0;
            itemList = new List<Item>(cap);
        }

        // Functions
        private void Expand()
        {
            cap *= 2;
            // List automatically handles resizing, so no manual copying is required
        }

        public void AddItem(Item item)
        {
            if (nrOfItems >= cap)
            {
                Expand();
            }

            itemList.Add(item.Clone()); // Assumes Item class has a copy constructor
            nrOfItems++;
        }

        public void RemoveItem(int index)
        {
            if (index >= 0 && index < nrOfItems)
            {
                itemList.RemoveAt(index);
                nrOfItems--;
            }
        }

        public void DebugPrint()
        {
            foreach (var item in itemList)
            {
                Console.WriteLine(item.DebugPrint()); // Assumes Item class has DebugPrint method
            }
        }
    }
}
