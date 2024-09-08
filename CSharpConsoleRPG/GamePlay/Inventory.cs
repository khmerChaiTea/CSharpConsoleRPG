using System;
using System.Collections.Generic;

namespace CSharpConsoleRPG.GamePlay
{
    public class Inventory
    {
        private int cap;
        private int nrOfItems;
        private List<Item> itemArr;

        // Constructor
        public Inventory()
        {
            this.cap = 5;
            this.nrOfItems = 0;
            this.itemArr = new List<Item>(this.cap);
        }

        // Destructor (not needed in C# since it's handled by garbage collection)

        // Copy Constructor in C#
        public Inventory(Inventory other)
        {
            this.cap = other.cap;
            this.nrOfItems = other.nrOfItems;
            this.itemArr = new List<Item>(this.cap);

            for (int i = 0; i < other.nrOfItems; i++)
            {
                this.itemArr.Add(other.itemArr[i].Clone());
            }
        }

        public int Size => this.nrOfItems;

        public Item this[int index]
        {
            get
            {
                if (index < 0 || index >= this.nrOfItems)
                {
                    throw new IndexOutOfRangeException("BAD INDEX!");
                }
                return this.itemArr[index];
            }
        }

        // Functions
        // Method to expand inventory capacity (in C#, List automatically handles resizing, so this is not strictly needed)
        private void Expand()
        {
            this.cap *= 2;
            // No need to manually resize the array, as List<T> handles resizing internally.
        }

        // Method to add an item to the inventory
        public void AddItem(Item item)
        {
            if (this.nrOfItems >= this.cap)
            {
                Expand();
            }

            this.itemArr.Add(item.Clone());
            this.nrOfItems++;
        }

        // Method to remove an item from the inventory
        public void RemoveItem(int index)
        {
            if (index < 0 || index >= this.nrOfItems)
            {
                throw new IndexOutOfRangeException("BAD INDEX!");
            }

            this.itemArr.RemoveAt(index);
            this.nrOfItems--;
        }

        // Debug print method to print the inventory contents
        public void DebugPrint()
        {
            foreach (var item in this.itemArr)
            {
                Console.WriteLine(item.DebugPrint());
            }
        }
    }
}
