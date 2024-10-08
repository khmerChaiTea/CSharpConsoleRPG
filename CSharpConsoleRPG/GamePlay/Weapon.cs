﻿using System;

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

        // Clone method (deep copy)
        public override Weapon Clone()
        {
            return new Weapon(this.damageMin, this.damageMax, this.GetName(), this.GetLevel(), this.GetBuyValue(), this.GetSellValue(), this.GetRarity());
        }

        // Override ToString method to return string representation of Weapon
        public override string ToString()
        {
            return $"Weapon: {this.GetName()}, Min Damage: {this.damageMin}, Max Damage: {this.damageMax}, Level: {this.GetLevel()}, Rarity: {this.GetRarity()}";
        }

        // Accessors
        public int DamageMin
        {
            get { return this.damageMin; }
        }

        public int DamageMax
        {
            get { return this.damageMax; }
        }

        // Modifiers (can be added if needed)
    }

}
