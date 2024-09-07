using System;
using CSharpConsoleRPG.GamePlay;

namespace CSharpConsoleRPG.States
{
    public class Game
    {
        // Fields
        private int choice;
        private bool playing;

        // Character related
        private Character character;

        // Constructor
        public Game()
        {
            choice = 0;
            playing = true;
            character = new Character(); // Ensure the Character instance is created
        }

        // Destructor (Not necessary in C#, handled by garbage collection)
        //~Game() { }

        // Functions
        public void InitGame()
        {
            Console.Write("Enter name of character: ");
            string? name = Console.ReadLine();  // ReadLine() can return null

            // Check if name is null or empty and handle it
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Invalid input. Name cannot be empty.");
                // You can handle this by either retrying or setting a default name
                name = "Arin";  // Assign a default name if needed
            }

            character.Initialize(name);  // Safe to pass since name won't be null
        }


        // Main Menu Function
        public void MainMenu()
        {
            Console.WriteLine("= Main Menu =\n");
            Console.WriteLine("0: Quit");
            Console.WriteLine("1: Travel");
            Console.WriteLine("2: Shop");
            Console.WriteLine("3: Level up");
            Console.WriteLine("4: Rest");
            Console.WriteLine("5: Character sheet\n");

            Console.Write("Choice: ");
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine();
                switch (choice)
                {
                    case 0:
                        playing = false;
                        break;

                    case 1:
                        // Travel logic goes here
                        Console.WriteLine("Traveling...");
                        break;

                    case 2:
                        // Shop logic goes here
                        Console.WriteLine("Visiting the shop...");
                        break;

                    case 3:
                        // Level up logic goes here
                        character.LevelUp();
                        Console.WriteLine("Leveled up!");
                        break;

                    case 4:
                        // Rest logic goes here
                        Console.WriteLine("Resting...");
                        break;

                    case 5:
                        character.PrintStats();
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input, please enter a number.");
            }
        }

        // Accessors
        public bool GetPlaying()
        {
            return playing;
        }
    }
}
