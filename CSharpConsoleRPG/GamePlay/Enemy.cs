using System;

namespace CSharpConsoleRPG.GamePlay
{
    public class Enemy
    {
        private int level;
        private int hp;
        private int hpMax;
        private int damageMin;
        private int damageMax;
        private float dropChance;
        private int defense;
        private int accuracy;

        public Enemy(int level = 0)
        {
            this.level = level;
            this.hpMax = level * 10;
            this.hp = this.hpMax;
            this.damageMin = this.level * 4;
            this.damageMax = this.level * 5;
            Random rand = new Random();
            this.dropChance = rand.Next(100);
            this.defense = rand.Next(100);
            this.accuracy = rand.Next(100);
        }

        public bool IsAlive()
        {
            return this.hp > 0;
        }

        public string GetAsString()
        {
            return $"Level: {this.level}\n" +
                   $"Hp: {this.hp} / {this.hpMax}\n" +
                   $"Damage: {this.damageMin} - {this.damageMax}\n" +
                   $"Defense: {this.defense}\n" +
                   $"Accuracy: {this.accuracy}\n" +
                   $"Drop chance: {this.dropChance}\n";
        }

        public void TakeDamage(int damage)
        {
            this.hp -= damage;

            if (this.hp < 0)
            {
                this.hp = 0;
            }
        }

        public int GetLevel()
        {
            return this.level;
        }

        public int GetDamage()
        {
            Random rand = new Random();
            return rand.Next(damageMin, damageMax);
        }

        public int GetExp()
        {
            return this.level * 100;
        }

        public int GetHp()
        {
            return this.hp;
        }

        public int GetHpMax()
        {
            return this.hpMax;
        }
    }
}
