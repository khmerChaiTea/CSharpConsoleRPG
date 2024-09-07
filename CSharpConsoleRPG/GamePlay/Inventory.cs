using System;
using System.Collections.Generic;

namespace CSharpConsoleRPG.GamePlay
{
    public class Inventory
    {
        private int capacity;
        private int numberOfItems;
        private List<Item> itemArr;

        // Constructor
        public Inventory()
        {
            this.capacity = 10;
            this.numberOfItems = 0;
            this.itemArr = new List<Item>(this.capacity);
        }

        // Destructor (not needed in C# since it's handled by garbage collection)

        // Functions
        // Method to expand inventory capacity (in C#, List automatically handles resizing, so this is not strictly needed)
        private void Expand()
        {
            this.capacity *= 2;
            // In C#, List automatically expands, so no need to handle resizing manually.
        }

        // Method to add an item to the inventory
        public void AddItem(Item item)
        {
            if (this.numberOfItems >= this.capacity)
            {
                Expand();
            }

            // Clone the item (assuming Clone is implemented in derived classes of Item)
            this.itemArr.Add(item.Clone());
            this.numberOfItems++;
        }

        // Method to remove an item from the inventory
        public void RemoveItem(int index)
        {
            if (index >= 0 && index < this.numberOfItems)
            {
                itemArr.RemoveAt(index);
                this.numberOfItems--;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Index out of range.");
            }
        }

        // Debug print method to print the inventory contents
        public void DebugPrint()
        {
            foreach (var item in itemArr)
            {
                Console.WriteLine(item.DebugPrint());
            }
        }
    }
}
