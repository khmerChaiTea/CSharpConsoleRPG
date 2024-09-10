using System;

namespace CSharpConsoleRPG.GamePlay
{
    public class Character
    {
        // Private fields
        private double xPos;
        private double yPos;

        private int distanceTraveled;

        private Inventory inventory;
        private Weapon weapon;
        private Armor armorHead;
        private Armor armorChest;
        private Armor armorArms;
        private Armor armorLegs;
        private int gold;

        private string name;
        private int level;
        private int exp;
        private int expNext;

        private int strength;
        private int vitality;
        private int dexterity;
        private int intelligence;

        private int hpMax;
        private int hp;
        private int staminaMax;
        private int stamina;
        private int damageMin;
        private int damageMax;
        private int defense;
        private int accuracy;
        private int luck;

        private int statPoints;
        private int skillPoints;

        // Constructor
        public Character()
        {
            this.xPos = 0.0;
            this.yPos = 0.0;
            this.distanceTraveled = 0;

            this.gold = 0;

            this.name = string.Empty;
            this.level = 0;
            this.exp = 0;
            this.expNext = 0;

            this.strength = 0;
            this.vitality = 0;
            this.dexterity = 0;
            this.intelligence = 0;

            this.hp = 0;
            this.hpMax = 0;
            this.stamina = 0;
            this.staminaMax = 0;
            this.damageMin = 0;
            this.damageMax = 0;
            this.defense = 0;
            this.accuracy = 0;
            this.luck = 0;

            this.statPoints = 0;
            this.skillPoints = 0;
        }

        // Functions
        public void Initialize(string name)
        {
            this.xPos = 0.0;
            this.yPos = 0.0;
            this.distanceTraveled = 0;

            this.gold = 100;

            this.name = name;
            this.level = 1;
            this.exp = 0;
            this.expNext = (int)((50.0 / 3.0) * ((Math.Pow(level, 3) - 6 * Math.Pow(level, 2)) + 17 * level - 12)) + 100;

            this.strength = 5;
            this.vitality = 5;
            this.dexterity = 5;
            this.intelligence = 5;

            this.hpMax = (this.vitality * 2) + (this.strength / 2);
            this.hp = this.hpMax;
            this.staminaMax = (this.vitality) + (this.strength / 2) + (this.dexterity / 3);
            this.stamina = this.staminaMax;
            this.damageMin = this.strength;
            this.damageMax = this.strength + 2;
            this.defense = this.dexterity + (this.intelligence / 2);
            this.accuracy = this.dexterity / 2;
            this.luck = this.intelligence;

            this.statPoints = 0;
            this.skillPoints = 0;
        }

        public void PrintStats()
        {
            Console.WriteLine("= Character Sheet =");
            Console.WriteLine();
            Console.WriteLine($"= Name: {this.name}");
            Console.WriteLine($"= Level: {this.level}");
            Console.WriteLine($"= Exp: {this.exp}");
            Console.WriteLine($"= Exp to next level: {this.expNext}");
            Console.WriteLine();
            Console.WriteLine($"= Strength: {this.strength}");
            Console.WriteLine($"= Vitality: {this.vitality}");
            Console.WriteLine($"= Dexterity: {this.dexterity}");
            Console.WriteLine($"= Intelligence: {this.intelligence}");
            Console.WriteLine();
            Console.WriteLine($"= HP: {this.hp} / {this.hpMax}");
            Console.WriteLine($"= Stamina: {this.stamina} / {this.staminaMax}");
            Console.WriteLine($"= Damage: {this.damageMin} - {this.damageMax}");
            Console.WriteLine($"= Defence: {this.defense}");
            Console.WriteLine($"= Luck: {this.luck}");
            Console.WriteLine();
        }

        public void LevelUp()
        {
            if (this.exp >= this.expNext)
            {
                this.exp -= this.expNext;
                this.level++;
                this.expNext = (int)((50.0 / 3.0) * ((Math.Pow(level, 3) - 6 * Math.Pow(level, 2)) + 17 * level - 12)) + 100;

                this.statPoints++;
                this.skillPoints++;

                Console.WriteLine($"YOU ARE NOW LEVEL {this.level}!\n");
            }
            else
            {
                Console.WriteLine("NOT ENOUGH EXP!\n");
            }
        }

        // Get character stats as string
        public string GetAsString()
        {
            return $"{xPos} {yPos} {name} {level} {exp} {strength} {vitality} {dexterity} {intelligence} {hp} {stamina} {statPoints} {skillPoints}";
        }

        // Properties
        // Accessors
        public double X => this.xPos;
        public double Y => this.yPos;
        public int DistanceTraveled => this.distanceTraveled;
        public string Name => this.name;
        public int Level => this.level;
        public int Exp => this.exp;
        public int ExpNext => this.expNext;
        public int Hp => this.hp;
        public int HpMax => this.hpMax;
        public int Stamina => this.stamina;
        public int DamageMin => this.damageMin;
        public int DamageMax => this.damageMax;
        public int Defense => this.defense;
        public int Accuracy => this.accuracy;

        // Modifier (if needed)
        public void SetDistanceTraveled(int distance)
        {
            this.distanceTraveled = distance;
        }
        public void Travel()
        {
            this.distanceTraveled++;
        }

        public void GainExp(int exp)
        {
            this.exp += exp;
        }

    }
}
