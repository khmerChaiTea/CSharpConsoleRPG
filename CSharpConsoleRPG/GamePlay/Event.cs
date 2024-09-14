using System;
using System.Collections.Generic;

namespace CSharpConsoleRPG.GamePlay
{
    public class Event
    {
        private int nrOfEvents;
        private Random rand = new Random();

        public Event()
        {
            this.nrOfEvents = 2; // Number of possible events
        }

        // Destructor (not needed)

        // Generate a random event for the character
        public void GenerateEvent(Character character, List<Enemy> enemies)
        {
            int i = rand.Next(0, this.nrOfEvents);

            switch (i)
            {
                case 0:
                    // Enemy encounter
                    EnemyEncounter(character, enemies);
                    break;

                case 1:
                    // Puzzle encounter
                    PuzzleEncounter(character);
                    break;

                default:
                    break;
            }
        }

        // Events
        public void EnemyEncounter(Character character, List<Enemy> enemies)
        {
            bool playerTurn = false;
            int choice = 0;

            // Coin toss for turn
            int coinToss = rand.Next(1, 3);

            playerTurn = coinToss == 1;

            // End conditions
            bool escape = false;
            bool playerDefeated = false;
            bool enemiesDefeated = false;

            // Enemies
            int nrOfEnemies = rand.Next(1, 6);
            for (int i = 0; i < nrOfEnemies; i++)
            {
                enemies.Add(new Enemy(character.Level));
            }

            // Battle variables
            int attackRoll = 0;
            int defendRoll = 0;
            int damage = 0;
            int gainExp = 0;

            while (!escape && !playerDefeated && !enemiesDefeated)
            {
                if (playerTurn && !playerDefeated)
                {
                    // Menu
                    Console.WriteLine("= Battle Menu =\n");
                    Console.WriteLine("0: Escape");
                    Console.WriteLine("1: Attack");
                    Console.WriteLine("2: Defend");
                    Console.WriteLine("3: Use Item");
                    Console.WriteLine();
                    Console.Write("Choice: ");

                    choice = GetValidInput(0, 3);

                    // Moves
                    switch (choice)
                    {
                        case 0: // Escape
                            escape = true;
                            break;
                        case 1: // Attack
                                // Select Enemy
                            Console.WriteLine("Select enemy:\n");
                            for (int i = 0; i < enemies.Count; i++)
                            {
                                Console.WriteLine($"{i}: Level: {enemies[i].GetLevel()} - Hp: {enemies[i].GetHp()} / {enemies[i].GetHpMax()}");
                            }
                            Console.WriteLine();
                            Console.Write("Choice: ");

                            choice = GetValidInput(0, enemies.Count - 1);

                            attackRoll = rand.Next(1, 101);
                            if (attackRoll > 50) // Hit
                            {
                                Console.WriteLine("HIT!\n");

                                damage = character.GetDamage();
                                enemies[choice].TakeDamage(damage);
                                Console.WriteLine($"Damage: {damage}!\n");

                                if (!enemies[choice].IsAlive())
                                {
                                    Console.WriteLine("ENEMY DEFEATED!\n");
                                    gainExp = enemies[choice].GetExp();
                                    character.GainExp(gainExp);
                                    Console.WriteLine($"EXP GAINED: {gainExp}\n");
                                    enemies.RemoveAt(choice);
                                }
                            }
                            else // Miss
                            {
                                Console.WriteLine("MISSED!\n");
                            }
                            break;
                        case 2: // Defend
                                // Implement defend logic here
                            break;
                        case 3: // Item
                                // Implement item usage here
                            break;
                        default:
                            break;
                    }

                    // End turn
                    playerTurn = false;
                }
                else if (!playerTurn && !escape && !enemiesDefeated)
                {
                    // Enemy attack (can be expanded to include enemy attack logic)
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        // Implement enemy attack logic here
                    }

                    // End turn
                    playerTurn = true;
                }

                // Conditions
                if (!character.IsAlive)
                {
                    playerDefeated = true;
                }

                if (enemies.Count <= 0)
                {
                    enemiesDefeated = true;
                }
            }
        }

        // Puzzle encounter event
        public void PuzzleEncounter(Character character)
        {
            bool completed = false;
            int userAns = 0;
            int chances = 3;
            int gainExp = chances * character.Level * rand.Next(1, 11);

            // Load a puzzle from file
            Puzzle puzzle = new Puzzle("Puzzles/1.txt");

            while (!completed && chances > 0)
            {
                Console.WriteLine($"Chances: {chances}\n");
                chances--;
                Console.WriteLine(puzzle.GetAsString());

                Console.Write("Your Answer: ");
                while (!int.TryParse(Console.ReadLine(), out userAns))
                {
                    Console.WriteLine("Faulty input!");
                    Console.Write("Your Answer: ");
                }

                if (puzzle.CorrectAnswer == userAns)
                {
                    completed = true;

                    // Give user experience points or rewards
                    character.GainExp(gainExp);
                    Console.WriteLine($"YOU GAIN {gainExp} EXP!\n");
                }
                else
                {
                    Console.WriteLine("Wrong Try again!\n");
                }
            }

            if (completed)
            {
                Console.WriteLine("Congrats! Puzzle is solved!\n");
            }
            else
            {
                Console.WriteLine("Failed!\n");
            }
        }

        private int GetValidInput(int min = int.MinValue, int max = int.MaxValue)
        {
            int input;
            while (!int.TryParse(Console.ReadLine(), out input) || input < min || input > max)
            {
                Console.WriteLine("Invalid input, please try again:");
            }
            return input;
        }
    }
}
