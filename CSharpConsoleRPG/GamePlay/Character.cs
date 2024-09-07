using System;

namespace CSharpConsoleRPG.GamePlay
{
    public class Character
    {
        // Private fields
        private double xPos;
        private double yPos;

        private string name;
        private int level;
        private int exp;
        private int expNext;

        private int strength;
        private int vitality;
        private int dexterity;
        private int intelligence;

        private int hp;
        private int hpMax;
        private int stamina;
        private int staminaMax;
        private int damageMin;
        private int damageMax;
        private int defence;
        private int luck;

        private int statPoints;
        private int skillPoints;

        // Constructor
        public Character()
        {
            xPos = 0.0;
            yPos = 0.0;

            name = "";
            level = 0;
            exp = 0;
            expNext = 0;

            strength = 0;
            vitality = 0;
            dexterity = 0;
            intelligence = 0;

            hp = 0;
            hpMax = 0;
            stamina = 0;
            staminaMax = 0;
            damageMin = 0;
            damageMax = 0;
            defence = 0;
            luck = 0;

            statPoints = 0;
            skillPoints = 0;
        }

        // Functions
        public void Initialize(string name)
        {
            xPos = 0.0;
            yPos = 0.0;

            this.name = name;
            level = 1;
            exp = 0;
            expNext = (int)((50.0 / 3.0) * (Math.Pow(level, 3) - 6 * Math.Pow(level, 2) + 17 * level - 12)) + 100;

            strength = 5;
            vitality = 5;
            dexterity = 5;
            intelligence = 5;

            hp = 10;
            hpMax = 10;
            stamina = 10;
            staminaMax = 10;
            damageMin = 1;
            damageMax = 4;
            defence = 1;
            luck = 1;

            statPoints = 0;
            skillPoints = 0;
        }

        public void PrintStats()
        {
            Console.WriteLine("= Character Sheet =");
            Console.WriteLine();
            Console.WriteLine($"= Name: {name}");
            Console.WriteLine($"= Level: {level}");
            Console.WriteLine($"= Exp: {exp}");
            Console.WriteLine($"= Exp to next level: {expNext}");
            Console.WriteLine();
            Console.WriteLine($"= Strength: {strength}");
            Console.WriteLine($"= Vitality: {vitality}");
            Console.WriteLine($"= Dexterity: {dexterity}");
            Console.WriteLine($"= Intelligence: {intelligence}");
            Console.WriteLine();
            Console.WriteLine($"= HP: {hp} / {hpMax}");
            Console.WriteLine($"= Stamina: {stamina} / {staminaMax}");
            Console.WriteLine($"= Damage: {damageMin} - {damageMax}");
            Console.WriteLine($"= Defence: {defence}");
            Console.WriteLine($"= Luck: {luck}");
            Console.WriteLine();
        }

        public void LevelUp()
        {
            while (exp >= expNext)
            {
                exp -= expNext;
                level++;
                expNext = (int)((50.0 / 3.0) * (Math.Pow(level, 3) - 6 * Math.Pow(level, 2) + 17 * level - 12)) + 100;

                statPoints++;
                skillPoints++;
            }
        }

        // Properties
        public double X { get { return xPos; } }
        public double Y { get { return yPos; } }
        public string Name { get { return name; } }
        public int Level { get { return level; } }
        public int Exp { get { return exp; } }
        public int ExpNext { get { return expNext; } }
        public int Hp { get { return hp; } }
        public int HpMax { get { return hpMax; } }
        public int Stamina { get { return stamina; } }
        public int DamageMin { get { return damageMin; } }
        public int DamageMax { get { return damageMax; } }
        public int Defence { get { return defence; } }
    }
}
