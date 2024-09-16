using System;
using System.Text;

namespace CSharpConsoleRPG.GamePlay
{
    public class Character
    {
        // Private fields
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

        // Constructor
        public Character()
        {
            this.distanceTraveled = 0;

            // Initialize objects
            this.weapon = new Weapon();        // Assuming Weapon has a default constructor
            this.armorHead = new Armor();     // Assuming Armor has a default constructor
            this.armorChest = new Armor();    // Assuming Armor has a default constructor
            this.armorArms = new Armor();     // Assuming Armor has a default constructor
            this.armorLegs = new Armor();     // Assuming Armor has a default constructor
            this.inventory = new Inventory();  // Assuming Inventory has a default constructor

            this.gold = 0;
            this.name = "";
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
        }

        public Character(string name, int distanceTraveled, int gold, int level, int exp, int strength,
                     int vitality, int dexterity, int intelligence, int hp, int stamina,
                     int statPoints)
        {
            this.distanceTraveled = distanceTraveled;

            // Initialize objects
            this.weapon = new Weapon();        // Assuming Weapon has a default constructor
            this.armorHead = new Armor();     // Assuming Armor has a default constructor
            this.armorChest = new Armor();    // Assuming Armor has a default constructor
            this.armorArms = new Armor();     // Assuming Armor has a default constructor
            this.armorLegs = new Armor();     // Assuming Armor has a default constructor
            this.inventory = new Inventory();  // Assuming Inventory has a default constructor

            this.gold = gold;
            this.name = name;
            this.level = level;
            this.exp = exp;
            this.expNext = 0;

            this.strength = strength;
            this.vitality = vitality;
            this.dexterity = dexterity;
            this.intelligence = intelligence;

            this.hp = hp;
            this.hpMax = 0;
            this.stamina = stamina;
            this.staminaMax = 0;
            this.damageMin = 0;
            this.damageMax = 0;
            this.defense = 0;
            this.accuracy = 0;
            this.luck = 0;

            this.statPoints = statPoints;

            this.UpdateStats();
        }

        // Functions
        public void Initialize(string name)
        {
            this.distanceTraveled = 0;
            this.gold = 100;
            this.name = name;
            this.level = 1;
            this.exp = 0;

            this.strength = 5;
            this.vitality = 5;
            this.dexterity = 5;
            this.intelligence = 5;

            this.statPoints = 0;

            this.UpdateStats();
        }

        public void PrintStats()
        {
            Console.WriteLine("= Character Sheet =");
            Console.WriteLine();
            Console.WriteLine($"= Name: {this.name}");
            Console.WriteLine($"= Level: {this.level}");
            Console.WriteLine($"= Exp: {this.exp}");
            Console.WriteLine($"= Exp to next level: {this.expNext}");
            Console.WriteLine("= Stat points: " + this.statPoints);
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
            Console.WriteLine($"= Distance Traveled: {this.distanceTraveled}");
            Console.WriteLine($"= Gold: {this.gold}");
            Console.WriteLine();
            Console.WriteLine("\n= Weapon: " + this.weapon.GetName() + " Lvl: " + this.weapon.GetLevel() + " Dam: " + this.weapon.DamageMin + " - " + this.weapon.DamageMax);
            Console.WriteLine("= Armor Head: " + this.armorHead.GetName() + " Lvl: " + this.armorHead.GetLevel() + " Def: " + this.armorHead.Defense);
            Console.WriteLine("= Armor Chest: " + this.armorChest.GetName() + " Lvl: " + this.armorChest.GetLevel() + " Def: " + this.armorChest.Defense);
            Console.WriteLine("= Armor Arms: " + this.armorArms.GetName() + " Lvl: " + this.armorArms.GetLevel() + " Def: " + this.armorArms.Defense);
            Console.WriteLine("= Armor Legs: " + this.armorLegs.GetName() + " Lvl: " + this.armorLegs.GetLevel() + " Def: " + this.armorLegs.Defense);
        }

        // Get character stats as string
        public string GetAsString()
        {
            return $"{name} {distanceTraveled} {gold} {level} {exp} {strength} {vitality} {dexterity} {intelligence} {hp} {stamina} {statPoints}";
        }

        public void LevelUp()
        {
            if (this.exp >= this.expNext)
            {
                this.exp -= this.expNext;
                this.level++;
                this.expNext = (int)((50.0 / 3.0) * ((Math.Pow(level, 3) - 6 * Math.Pow(level, 2)) + 17 * level - 12)) + 100;

                this.statPoints++;

                this.UpdateStats();

                Console.WriteLine($"YOU ARE NOW LEVEL {this.level}!\n");
            }
            else
            {
                Console.WriteLine("NOT ENOUGH EXP!\n");
            }
        }

        public void UpdateStats()
        {
            this.expNext = (int)(
                (50.0 / 3) * ((Math.Pow(level, 3)
                - 6 * Math.Pow(level, 2))
                + 17 * level - 12)) + 100;

            this.hpMax = (this.vitality * 2) + (this.strength / 2);
            this.hp = this.hpMax;
            this.staminaMax = (this.vitality) + (this.strength / 2) + (this.dexterity / 3);
            this.stamina = this.staminaMax;
            this.damageMin = this.strength;
            this.damageMax = this.strength + 2;
            this.defense = this.dexterity + (this.intelligence / 2);
            this.accuracy = (this.dexterity / 2) + this.intelligence;
            this.luck = this.intelligence;
        }

        public void AddToStat(int stat, int value)
        {
            if (this.statPoints < value)
            {
                Console.WriteLine("ERROR! NOT ENOUGH STATPOINTS!");
            }
            else
            {
                switch (stat)
                {
                    case 0:
                        this.strength += value;
                        Console.WriteLine("\nSTRENGTH INCREASED!\n");
                        break;

                    case 1:
                        this.vitality += value;
                        Console.WriteLine("\nVITALITY INCREASED!\n");
                        break;

                    case 2:
                        this.dexterity += value;
                        Console.WriteLine("\nDEXTERITY INCREASED!\n");
                        break;

                    case 3:
                        this.intelligence += value;
                        Console.WriteLine("\nINTELLIGENCE INCREASED!\n");
                        break;

                    default:
                        Console.WriteLine("NO SUCH STAT!");
                        break;
                }

                this.statPoints -= value;
            }
        }

        public void TakeDamage(int damage)
        {
            this.hp -= damage;

            if (this.hp < 0)
            {
                this.hp = 0;
            }
        }

        // Properties
        // Accessors
        public int DistanceTraveled => this.distanceTraveled;
        public string Name => this.name;
        public int Level => this.level;
        public int Exp => this.exp;
        public int ExpNext => this.expNext;
        public int StatPoints => this.statPoints;
        public int Hp => this.hp;
        public int HpMax => this.hpMax;
        public bool IsAlive => hp > 0;
        public int Stamina => this.stamina;
        public int DamageMin => this.damageMin;
        public int DamageMax => this.damageMax;
        public int Damage => new Random().Next(damageMin, damageMax);
        public int Defense => this.defense;
        public int Accuracy => this.accuracy;

        // Modifier (if needed)
        public void SetDistanceTraveled(int distance) => this.distanceTraveled = distance;
        public void Travel() => this.distanceTraveled++;
        public void GainExp(int exp) => this.exp += exp;
    }
}
