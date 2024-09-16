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

        // Enemies
        private List<Enemy> enemies;

        // Constructor
        public Game()
        {
            this.choice = 0;
            this.playing = true;
            this.activeCharacter = 0;
            this.fileName = "characters.txt";
            this.characters = new List<Character>();
            this.enemies = new List<Enemy>();
        }

        // Destructor (Not necessary in C#, handled by garbage collection)
        //~Game() { }

        // Accessors
        public bool IsPlaying => this.playing;

        // Functions
        public void InitGame()
        {
            CreateNewCharacter();
        }

        // Main Menu Function
        public void MainMenu()
        {
            Console.WriteLine("ENTER to continue...");
            Console.ReadLine();
            Console.Clear();

            if (this.characters[activeCharacter].Exp >= this.characters[activeCharacter].ExpNext)
            {
                Console.WriteLine("LEVEL UP AVAILABLE!\n");
            }

            Console.WriteLine("= Main Menu =\n");

            Console.WriteLine($"= Active character: {this.characters[activeCharacter].Name}, Nr: {this.activeCharacter + 1}/{this.characters.Count} =\n");

            Console.WriteLine("0: Quit");
            Console.WriteLine("1: Travel");
            Console.WriteLine("2: Shop");
            Console.WriteLine("3: Level up");
            Console.WriteLine("4: Rest");
            Console.WriteLine("5: Character sheet");
            Console.WriteLine("6: Create new character");
            Console.WriteLine("7: Select character");
            Console.WriteLine("8: Save characters");
            Console.WriteLine("9: Load characters");


            Console.WriteLine();

            Console.Write("Choice: ");
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Faulty input!");
                Console.Write("Choice: ");
            }

            Console.WriteLine();

            switch (choice)
            {
                case 0: // Quit
                    playing = false;
                    break;

                case 1: // Travel
                    Travel();
                    break;

                case 2: // Shop
                        // Shop logic
                    break;

                case 3: // Level Up
                    LevelUpCharacter();
                    break;

                case 4: // Rest
                        // Rest logic
                    break;

                case 5: // Character sheet
                    characters[activeCharacter].PrintStats();
                    break;

                case 6: // Create character
                    CreateNewCharacter();
                    SaveCharacter();
                    break;

                case 7:
                    SelectCharacter();
                    break;

                case 8: // Save character
                    SaveCharacter();
                    Console.WriteLine("Character saved successfully.");
                    break;

                case 9: // Load character
                    LoadCharacter();
                    break;



                default:
                    Console.WriteLine("Invalid input. Please choose from the following choices.\n");
                    break;
            }
        }

        public void CreateNewCharacter()
        {
            string name = "";
            Console.Write("Character name: ");
            name = Console.ReadLine();

            while (characters.Exists(c => c.Name == name))
            {
                Console.WriteLine("Error! Character already exists!");
                Console.Write("Character name: ");
                name = Console.ReadLine();
            }

            Character newCharacter = new Character();
            newCharacter.Initialize(name);
            characters.Add(newCharacter);
            activeCharacter = characters.Count - 1;
        }

        public void LevelUpCharacter()
        {
            characters[activeCharacter].LevelUp();

            if (characters[activeCharacter].StatPoints > 0)
            {
                Console.WriteLine("You have stat points to allocate!\n");
                Console.WriteLine("Stat to upgrade:");
                Console.WriteLine("0: Strength");
                Console.WriteLine("1: Vitality");
                Console.WriteLine("2: Dexterity");
                Console.WriteLine("3: Intelligence");

                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 3)
                {
                    Console.WriteLine("Faulty input!");
                    Console.Write("Stat to upgrade: ");
                }

                switch (this.choice)
                {
                    case 0:
                        characters[activeCharacter].AddToStat(0, 1);
                        break;
                    case 1:
                        characters[activeCharacter].AddToStat(1, 1);
                        break;
                    case 2:
                        characters[activeCharacter].AddToStat(2, 1);
                        break;
                    case 3:
                        characters[activeCharacter].AddToStat(3, 1);
                        break;
                    default:
                        break;
                }
            }
        }

        public void SaveCharacter()
        {
            try
            {
                using (StreamWriter outFile = new StreamWriter(fileName))
                {
                    foreach (var character in characters)
                    {
                        outFile.WriteLine(character.GetAsString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving characters: " + ex.Message);
            }
        }

        public void LoadCharacter()
        {
            SaveCharacter();

            characters.Clear();

            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);

                foreach (string line in lines)
                {
                    string[] data = line.Split(' ');
                    string name = data[0];
                    int distanceTraveled = int.Parse(data[1]);
                    int gold = int.Parse(data[2]);
                    int level = int.Parse(data[3]);
                    int exp = int.Parse(data[4]);
                    int strength = int.Parse(data[5]);
                    int vitality = int.Parse(data[6]);
                    int dexterity = int.Parse(data[7]);
                    int intelligence = int.Parse(data[8]);
                    int hp = int.Parse(data[9]);
                    int stamina = int.Parse(data[10]);
                    int statPoints = int.Parse(data[11]);

                    Character temp = new Character(name, distanceTraveled, gold, level, exp, strength, vitality, dexterity, intelligence, hp, stamina, statPoints);
                    characters.Add(temp);

                    Console.WriteLine($"Character {name} loaded!");
                }

                if (characters.Count == 0)
                {
                    throw new Exception("ERROR! NO CHARACTER LOADED! OR EMPTY FILE!");
                }
            }
            else
            {
                Console.WriteLine("Unable to open file!");
            }
        }

        public void SelectCharacter()
        {
            Console.WriteLine("Select character:\n");
            for (int i = 0; i < characters.Count; i++)
            {
                Console.WriteLine($"Index: {i} = {characters[i].Name}, Level: {characters[i].Level}");
            }

            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice >= characters.Count)
            {
                Console.WriteLine("Faulty input!");
                Console.Write("Select character: ");
            }

            activeCharacter = choice;
            Console.WriteLine($"{characters[activeCharacter].Name} is SELECTED!\n");
        }

        public void Travel()
        {
            characters[activeCharacter].Travel();

            Event ev = new Event();
            ev.GenerateEvent(characters[activeCharacter], enemies);
        }
    }
}
