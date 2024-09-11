using System;
using System.IO;

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
            Random random = new Random();
            int gainExp = chances * character.Level * random.Next(1, 11);

            // Load a puzzle from file
            Puzzle puzzle = new Puzzle("Puzzles/1.txt");

            while (!completed && chances > 0)
            {
                Console.WriteLine($"Chances: {chances}\n");
                chances--;
                Console.WriteLine(puzzle.GetAsString());

                Console.Write("\nYour Answer: ");
                while (!int.TryParse(Console.ReadLine(), out userAns))
                {
                    Console.WriteLine("Faulty input!");
                    Console.Write("\nYour Answer: ");
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
