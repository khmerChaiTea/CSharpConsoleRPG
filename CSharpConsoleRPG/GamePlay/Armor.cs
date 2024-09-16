using System;

namespace CSharpConsoleRPG.GamePlay
{
    public enum ArmorType { HEAD = 0, CHEST, ARMS, LEGS }
    public class Armor : Item
    {
        private int type;
        private int defense;

        // Constructor
        public Armor(int type = 0, int defence = 0, string name = "NONE", int level = 0, int buyValue = 0, int sellValue = 0, int rarity = 0)
            : base(name, level, buyValue, sellValue, rarity)
        {
            this.type = type;
            this.defense = defence;
        }

        // Clone method (deep copy)
        public override Armor Clone()
        {
            return new Armor(this.type, this.defense, this.GetName(), this.GetLevel(), this.GetBuyValue(), this.GetSellValue(), this.GetRarity());
        }

        // Override ToString method to return string representation of Armor
        public override string ToString()
        {
            return $"Armor: {this.GetName()}, Type: {this.type}, Defense: {this.defense}, Level: {this.GetLevel()}, Rarity: {this.GetRarity()}";
        }

        // Accessors
        public int Defense
        {
            get { return this.defense; }
        }

        public int Type
        {
            get { return this.type; }
        }

        // Modifiers (can be added if needed)
    }
}
