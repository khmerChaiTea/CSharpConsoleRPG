using System;
using System.Collections.Generic;

namespace CSharpConsoleRPG.GamePlay
{
    public class Event
    {
        private int nrOfEvents;

        public Event()
        {
            this.nrOfEvents = 2; // Number of possible events
        }

        // Destructor (not needed)

        // Generate a random event for the character
        public void GenerateEvent(Character character, List<Enemy> enemies)
        {
            Random rand = new Random();
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
        private void EnemyEncounter(Character character, List<Enemy> enemies)
        {
            Random rand = new Random();
            bool playerTurn = false;

            // Coin toss for turn
            playerTurn = rand.Next(2) == 0;

            bool escape = false;
            bool playerDefeated = false;
            bool enemiesDefeated = false;

            int nrOfEnemies = rand.Next(5);

            for (int i = 0; i < nrOfEnemies; i++)
            {
                enemies.Add(new Enemy(character.Level));
            }

            while (!escape && !playerDefeated && !enemiesDefeated)
            {
                if (playerTurn && !playerDefeated)
                {
                    // Menu
                    Console.Clear();
                    Console.WriteLine("= Battle Menu =\n");
                    Console.WriteLine("0: Escape");
                    Console.WriteLine("1: Attack");
                    Console.WriteLine("2: Defend");
                    Console.WriteLine("3: Use Item\n");

                    Console.Write("Choice: ");
                    int choice;
                    while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Faulty input!\n");
                        Console.WriteLine("= Battle Menu =\n");
                        Console.WriteLine("0: Escape");
                        Console.WriteLine("1: Attack");
                        Console.WriteLine("2: Defend");
                        Console.WriteLine("3: Use Item\n");
                        Console.Write("Choice: ");
                    }

                    // Handle choice
                    switch (choice)
                    {
                        case 0:
                            escape = true;
                            break;

                        case 1:
                            // Attack logic
                            break;

                        case 2:
                            // Defend logic
                            break;

                        case 3:
                            // Use item logic
                            break;

                        default:
                            break;
                    }

                    // End turn
                    playerTurn = false;
                }
                else if (!playerTurn && !escape && !enemiesDefeated)
                {
                    // Enemy attack logic
                    foreach (var enemy in enemies)
                    {
                        // Handle enemy actions
                    }

                    // End turn
                    playerTurn = true;
                }

                // Check conditions
                if (!character.IsAlive)
                {
                    playerDefeated = true;
                }

                if (enemies.Count == 0)
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
            Random random = new Random();
            int gainExp = chances * character.Level * random.Next(1, 11);

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
    }
}
