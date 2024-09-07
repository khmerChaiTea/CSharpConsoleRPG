using System;

namespace CSharpConsoleRPG.GamePlay
{
    public class Weapon : Item
    {
        private int damageMin;
        private int damageMax;

        // Constructor
        public Weapon(int damageMin = 0, int damageMax = 0, string name = "NONE", int level = 0, int buyValue = 0, int sellValue = 0, int rarity = 0)
            : base(name, level, buyValue, sellValue, rarity)
        {
            this.damageMin = damageMin;
            this.damageMax = damageMax;
        }

        // Destructor (not needed in C#)
        ~Weapon() { }

        // Clone method (deep copy)
        public override Weapon Clone()
        {
            return new Weapon(this.damageMin, this.damageMax, this.GetName(), this.GetLevel(), this.GetBuyValue(), this.GetSellValue(), this.GetRarity());
        }

        // Override ToString method to return string representation of Weapon
        public override string ToString()
        {
            return $"{this.damageMin} - {this.damageMax}";
        }
    }

}
