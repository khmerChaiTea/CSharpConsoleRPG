using System;

namespace CSharpConsoleRPG.GamePlay
{
    public class Game
    {
        // Fields
        private int choice;
        private bool playing;

        // Constructor
        public Game()
        {
            choice = 0;
            playing = true;
        }

        // Destructor (Not necessary in C#, handled by garbage collection)
        //~Game() { }

        // Properties (Accessor)
        public bool IsPlaying
        {
            get { return playing; }
        }

        // Main Menu Function
        public void MainMenu()
        {
            Console.WriteLine("Main Menu\n");
            Console.WriteLine("0: Quit");
            Console.WriteLine("1: Travel");
            Console.WriteLine("2: Shop");
            Console.WriteLine("3: Level up");
            Console.WriteLine("4: Rest");

            Console.Write("\nChoice: ");
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 0:
                        playing = false;
                        break;
                    case 1:
                        // Travel logic
                        break;
                    case 2:
                        // Shop logic
                        break;
                    case 3:
                        // Level up logic
                        break;
                    case 4:
                        // Rest logic
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input, please enter a number.");
            }
        }
    }
}
