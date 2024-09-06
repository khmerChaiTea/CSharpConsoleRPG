using System;
using CSharpConsoleRPG.GamePlay;

namespace CSharpConsoleRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Game game = new Game();

            while (game.IsPlaying)
            {
                game.MainMenu();
            }
        }
    }
}

/*
* C++ Code Conversion to C#:
* 1. The use of #include and C++ standard libraries like <iostream>,
* <ctime>, etc., is replaced by corresponding C# using directives.
* 2. cin and cout in C++ are replaced with Console.ReadLine() and Console.WriteLine() in C#.
* 3. The class and method syntax is largely similar between C++ and C#, but C# uses public,
* private, etc., without the need for virtual destructors.
* 4. The main() function in C++ maps to the Main() method in C#,
* which is enclosed in a Program class.
*/

/*
 * Explanation of Changes:
 * 1. Random Initialization: Replaced srand(time(NULL)); with Random rand = new Random(); in C#.
 * 2. Console Input/Output: cin >> is replaced by Console.ReadLine() with validation
 * using int.TryParse(). cout is replaced by Console.WriteLine().
 * 3. Game Loop: The while (game.getPlaying()) becomes while (game.IsPlaying), using a C# property.
 * 4. Destructor: C# relies on garbage collection, so explicit destructors
 * are typically unnecessary unless you are managing unmanaged resources.
 */