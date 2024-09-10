using System;

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
        public void GenerateEvent(Character character)
        {
            Random random = new Random();
            int i = random.Next(this.nrOfEvents);

            switch (i)
            {
                case 0:
                    // Enemy encounter
                    EnemyEncounter(character);
                    break;

                case 1:
                    // Puzzle encounter
                    PuzzleEncounter(character);
                    break;

                default:
                    break;
            }
        }

        // Enemy encounter event (to be implemented)
        public void EnemyEncounter(Character character)
        {
            // TODO: Implement enemy encounter logic
        }

        // Puzzle encounter event
        public void PuzzleEncounter(Character character)
        {
            bool completed = false;
            int userAns = 0;
            int chances = 3;

            // Load a puzzle from file
            Puzzle puzzle = new Puzzle("Puzzles/1.txt");

            while (!completed && chances > 0)
            {
                chances--;
                Console.WriteLine(puzzle.GetAsString());

                Console.WriteLine("\nYour Answer: ");
                bool isValidInput = int.TryParse(Console.ReadLine(), out userAns);

                if (!isValidInput || userAns > 2 || userAns < 0)
                {
                    Console.WriteLine("Invalid input, please enter one of the choices.");
                    continue;
                }

                if (puzzle.CorrectAnswer == userAns)
                {
                    completed = true;
                    // Give user experience points or rewards
                }
                else
                {
                    Console.WriteLine("Wrong Try again!\n");
                }
            }

            if (completed)
            {
                Console.WriteLine("Congrats! Puzzle is solved!");
            }
            else
            {
                Console.WriteLine("Failed!");
            }
        }
    }
}
