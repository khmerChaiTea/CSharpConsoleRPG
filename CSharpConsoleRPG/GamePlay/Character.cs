using System;
using System.Text;

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

        // Destructor is unnecessary in C# due to garbage collection

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
            Console.WriteLine("= Character Sheet =\n");
            Console.WriteLine($"= Name: {this.name}");
            Console.WriteLine($"= Level: {this.level}");
            Console.WriteLine($"= Exp: {this.exp}");
            Console.WriteLine($"= Exp to next level: {this.expNext}\n");
            Console.WriteLine($"= Strength: {this.strength}");
            Console.WriteLine($"= Vitality: {this.vitality}");
            Console.WriteLine($"= Dexterity: {this.dexterity}");
            Console.WriteLine($"= Intelligence: {this.intelligence}\n");
            Console.WriteLine($"= HP: {this.hp} / {this.hpMax}");
            Console.WriteLine($"= Stamina: {this.stamina} / {this.staminaMax}");
            Console.WriteLine($"= Damage: {this.damageMin} - {this.damageMax}");
            Console.WriteLine($"= Defence: {this.defence}");
            Console.WriteLine($"= Luck: {this.luck}\n");
        }

        public void LevelUp()
        {
            while (this.exp >= this.expNext)
            {
                this.exp -= this.expNext;
                this.level++;
                this.expNext = (int)((50.0 / 3.0) * (Math.Pow(level, 3) - 6 * Math.Pow(level, 2) + 17 * level - 12)) + 100;

                this.statPoints++;
                this.skillPoints++;
            }
        }

        public string GetAsString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.xPos} ");
            sb.Append($"{this.yPos} ");
            sb.Append($"{this.name} ");
            sb.Append($"{this.level} ");
            sb.Append($"{this.exp} ");
            sb.Append($"{this.strength} ");
            sb.Append($"{this.vitality} ");
            sb.Append($"{this.dexterity} ");
            sb.Append($"{this.intelligence} ");
            sb.Append($"{this.hp} ");
            sb.Append($"{this.stamina} ");
            sb.Append($"{this.statPoints} ");
            sb.Append($"{this.skillPoints}");

            return sb.ToString();
        }

        // Properties
        // Accessors
        public double GetX() => this.xPos;
        public double GetY() => this.yPos;
        public string GetName() => this.name;
        public int GetLevel() => this.level;
        public int GetExp() => this.exp;
        public int GetExpNext() => this.expNext;
        public int GetHp() => this.hp;
        public int GetHpMax() => this.hpMax;
        public int GetStamina() => this.stamina;
        public int GetDamageMin() => this.damageMin;
        public int GetDamageMax() => this.damageMax;
        public int GetDefence() => this.defence;

        // Modifier (if needed)
    }
}
