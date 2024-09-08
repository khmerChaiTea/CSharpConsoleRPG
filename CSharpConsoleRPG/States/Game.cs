using System;
using CSharpConsoleRPG.GamePlay;
using System.Collections.Generic;
using System.IO;

namespace CSharpConsoleRPG.States
{
    public class Game
    {
        // Fields
        private int choice;
        private bool playing;

        // Character related
        private int activeCharacter;
        private List<Character> characters;
        private string fileName;

        // Constructor
        public Game()
        {
            choice = 0;
            playing = true;
            activeCharacter = 0;
            fileName = "characters.txt";
            characters = new List<Character>();
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
            Inventory inv = new Inventory(); // Initialize the inv object

            inv.AddItem(new Weapon(0, 0, "Wep1")); // Use 'new' to create the Weapon object
            inv.AddItem(new Weapon(0, 0, "Wep2"));
            inv.AddItem(new Weapon(0, 0, "Wep3"));
            inv.AddItem(new Armor(0, 0, "Arm1"));
            inv.AddItem(new Armor(0, 0, "Arm2"));
            inv.AddItem(new Armor(0, 0, "Arm3"));

            for (int i = 0; i < inv.Size; i++) // Size is in Inventory
            {
                Console.WriteLine(inv[i].DebugPrint());
            }

            CreateNewCharacter();
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
            Console.WriteLine("6: Create new character");
            Console.WriteLine("7: Save characters");
            Console.WriteLine("8: Load characters");
            Console.WriteLine();

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
                        Console.WriteLine("Leveled up!");
                        break;

                    case 4:
                        // Rest logic goes here
                        Console.WriteLine("Resting...");
                        break;

                    case 5:
                        characters[activeCharacter].PrintStats();
                        break;

                    case 6:
                        CreateNewCharacter();
                        SaveCharacter();
                        Console.WriteLine("Character created.");
                        break;

                    case 7:
                        SaveCharacter();
                        Console.WriteLine("Character saved.");
                        break;

                    case 8:
                        LoadCharacter();
                        Console.WriteLine("Character loaded.");
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

        public void CreateNewCharacter()
        {
            Console.Write("Character name: ");
            string? name = Console.ReadLine();

            // Ensure the name is not null or empty
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Invalid input. Name cannot be empty.");
                return; // Exit the method if the name is invalid
            }

            characters.Add(new Character());
            activeCharacter = characters.Count - 1;
            characters[activeCharacter].Initialize(name);
        }

        public void SaveCharacter()
        {
            using (StreamWriter outFile = new StreamWriter(fileName))
            {
                foreach (Character character in characters)
                {
                    outFile.WriteLine(character.GetAsString());
                }
            }
        }

        public void LoadCharacter()
        {
            // Load character logic here
        }
    }
}
