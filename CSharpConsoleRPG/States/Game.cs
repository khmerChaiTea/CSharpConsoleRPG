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

        // Accessors
        // Property to access the playing status
        public bool Playing
        {
            get { return playing; }
            private set { playing = value; }
        }

        // Functions
        public void InitGame()
        {
            Console.Write("Enter name of character: ");
            string? name = Console.ReadLine();

            character.Initialize(name); // Assuming `Initialize` method exists in `Character`
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
            Console.WriteLine("5: Character sheet");
            Console.WriteLine();

            Console.Write("\nChoice: ");

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
                        character.PrintStats(); // Assuming `PrintStats` method exists in `Character`
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

            Console.WriteLine();
        }
    }
}
