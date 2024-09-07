using System;
using CSharpConsoleRPG.States;

namespace CSharpConsoleRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            // Seed the random number generator if needed
            // C#'s Random class is already seeded unless specified otherwise
            // If you need to seed it similarly to C++'s srand(time(NULL)), you can do so with a specific seed
            // For example:
            // Random random = new Random();

            Game game = new Game();
            game.InitGame();

            while (game.GetPlaying())
            {
                game.MainMenu();
            }

            Console.WriteLine("Thank you for playing!");
        }
    }
}