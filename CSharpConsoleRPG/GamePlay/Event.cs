using System;

namespace CSharpConsoleRPG.GamePlay
{
    public class Event
    {
        private int nrOfEvents;

        public Event()
        {
            nrOfEvents = 2;
        }

        public void GenerateEvent(Character character)
        {
            Random random = new Random();
            int i = random.Next(nrOfEvents);

            switch (i)
            {
                case 0:
                    // Enemy encounter
                    EnemyEncounter(character);
                    break;

                case 1:
                    // Puzzle
                    PuzzleEncounter(character);
                    break;

                default:
                    break;
            }
        }

        // Method for enemy encounter
        public void EnemyEncounter(Character character)
        {
            // Implementation here
        }

        // Method for puzzle encounter
        public void PuzzleEncounter(Character character)
        {
            // Implementation here
        }
    }
}
