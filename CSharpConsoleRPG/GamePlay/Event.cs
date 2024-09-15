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
            int coinToss = rand.Next(1,3);

            playerTurn = coinToss == 1;

            // End conditions
            bool escape = false;
            bool playerDefeated = false;
            bool enemiesDefeated = false;

            // Enemies
            int nrOfEnemies = rand.Next(1,6);

            for (int i = 0; i < nrOfEnemies; i++)
            {
                enemies.Add(new Enemy(character.Level + rand.Next(1,4)));
            }

            // Battle variables
            int damage = 0;
            int gainExp = 0;
            int playerTotal = 0;
            int enemyTotal = 0;
            int combatTotal = 0;
            int combatRollPlayer = 0;
            int combatRollEnemy = 0;

            while (!escape && !playerDefeated && !enemiesDefeated)
            {
                if (playerTurn && !playerDefeated)
                {
                    // Battle menu
                    Console.WriteLine("= Battle Menu =\n");
                    Console.WriteLine("0: Escape");
                    Console.WriteLine("1: Attack");
                    Console.WriteLine("2: Defend");
                    Console.WriteLine("3: Use Item");
                    Console.WriteLine("\nChoice: ");

                    string input = Console.ReadLine();

                    // Validating user input
                    while (!int.TryParse(input, out choice) || choice < 0 || choice > 3)
                    {
                        Console.WriteLine("Invalid input!");
                        Console.WriteLine("= Battle Menu =\n");
                        Console.WriteLine("0: Escape");
                        Console.WriteLine("1: Attack");
                        Console.WriteLine("2: Defend");
                        Console.WriteLine("3: Use Item");
                        Console.WriteLine("\nChoice: ");
                        input = Console.ReadLine();
                    }

                    // Moves
                    switch (choice)
                    {
                        case 0: // Escape
                            escape = true;
                            break;

                        case 1: // Attack
                                // Select enemy
                            Console.WriteLine("Select enemy:\n");
                            for (int i = 0; i < enemies.Count; i++)
                            {
                                Console.WriteLine($"{i}: Level: {enemies[i].GetLevel()} - Hp: {enemies[i].GetHp()}/{enemies[i].GetHpMax()} - Defense: {enemies[i].GetDefense()} - Accuracy: {enemies[i].GetAccuracy()}\n");
                            }

                            Console.WriteLine("Choice: ");
                            choice = int.Parse(Console.ReadLine());

                            while (choice < 0 || choice >= enemies.Count)
                            {
                                Console.WriteLine("Invalid input!\n");
                                Console.WriteLine("Choice: ");
                                choice = int.Parse(Console.ReadLine());
                            }

                            // Attack roll
                            combatTotal = enemies[choice].GetDefense() + character.Accuracy;
                            enemyTotal = (int)(enemies[choice].GetDefense()/ (double)combatTotal * 100);
                            playerTotal = (int)(character.Accuracy / (double)combatTotal * 100);
                            combatRollPlayer = rand.Next(playerTotal) + 1;
                            combatRollEnemy = rand.Next(enemyTotal) + 1;

                            Console.WriteLine($"Player roll: {combatRollPlayer}\n");
                            Console.WriteLine($"Enemy roll: {combatRollEnemy}\n");

                            if (combatRollPlayer > combatRollEnemy) // Hit
                            {
                                Console.WriteLine("HIT!\n");
                                damage = character.Damage;
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
                            else
                            {
                                Console.WriteLine("MISSED!\n");
                            }

                            break;

                        case 2: // Defend
                                // Defend logic
                            break;

                        case 3: // Use Item
                                // Item logic
                            break;

                        default:
                            break;
                    }

                    // End turn
                    playerTurn = false;
                }
                else if (!playerTurn && !escape && !enemiesDefeated)
                {
                    // Enemy attack
                    foreach (var enemy in enemies)
                    {
                        // Enemy attack logic here
                    }

                    // End turn
                    playerTurn = true;
                }

                // Check conditions
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
