using System;

namespace CSharpConsoleRPG.GamePlay
{
    public class Character
    {
        // Fields
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
            this.xPos = 0.0;
            this.yPos = 0.0;

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
            this.defence = 0;
            this.luck = 0;

            this.statPoints = 0;
            this.skillPoints = 0;
        }

        // Destructor is not needed in C# due to garbage collection

        // Functions
        public void Initialize(string name)
        {
            this.xPos = 0.0;
            this.yPos = 0.0;

            this.name = name;
            this.level = 1;
            this.exp = 0;
            this.expNext = (int)((50 / 3.0) * (Math.Pow(level, 3) - 6 * Math.Pow(level, 3) + (17 * level) - 11));

            this.strength = 5;
            this.vitality = 5;
            this.dexterity = 5;
            this.intelligence = 5;

            this.hp = 10;
            this.hpMax = 10;
            this.stamina = 10;
            this.staminaMax = 10;
            this.damageMin = 1;
            this.damageMax = 4;
            this.defence = 1;
            this.luck = 1;

            this.statPoints = 0;
            this.skillPoints = 0;
        }

        public void PrintStats()
        {
            Console.WriteLine("= Character Sheet =\n");
            Console.WriteLine("= Name: " + this.name);
            Console.WriteLine("= Level: " + this.level);
            Console.WriteLine("= Exp: " + this.exp);
            Console.WriteLine("= Exp to next level: " + this.expNext);
            Console.WriteLine();
            Console.WriteLine("= Strength: " + this.strength);
            Console.WriteLine("= Vitality: " + this.vitality);
            Console.WriteLine("= Dexterity: " + this.dexterity);
            Console.WriteLine("= Intelligence: " + this.intelligence);
            Console.WriteLine();
            Console.WriteLine("= HP: " + this.hp + " / " + this.hpMax);
            Console.WriteLine("= Stamina: " + this.stamina + " / " + this.staminaMax);
            Console.WriteLine("= Damage: " + this.damageMin + " - " + this.damageMax);
            Console.WriteLine("= Defence: " + this.defence);
            Console.WriteLine("= Luck: " + this.luck);
            Console.WriteLine();
        }

        public void LevelUp()
        {
            while (this.exp >= this.expNext)
            {
                this.exp -= this.expNext;
                this.level++;
                this.expNext = (int)((50 / 3.0) * (Math.Pow(this.level, 3) - 6 * Math.Pow(this.level, 3) + (17 * this.level) - 11));

                this.statPoints++;
                this.skillPoints++;
            }
        }

        // Accessors (Properties in C#)
        public double XPos => xPos;
        public double YPos => yPos;
        public string Name => name;
        public int Level => level;
        public int Exp => exp;
        public int ExpNext => expNext;
        public int Hp => hp;
        public int HpMax => hpMax;
        public int Stamina => stamina;
        public int DamageMin => damageMin;
        public int DamageMax => damageMax;
        public int Defence => defence;
        public int Luck => luck;

        // If you need access to statPoints and skillPoints, you can add properties for them as well
        public int StatPoints => statPoints;
        public int SkillPoints => skillPoints;
    }

}
