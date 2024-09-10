using System;
using System.Collections.Generic;
using System.IO;

namespace CSharpConsoleRPG.GamePlay
{
    public class Puzzle
    {
        private string question;
        private List<string> answers;
        private int correctAnswer;

        // Constructor to load a puzzle from a file
        public Puzzle(string fileName)
        {
            this.correctAnswer = 0;
            this.answers = new List<string>();

            try
            {
                using (StreamReader inFile = new StreamReader(fileName))
                {
                    this.question = inFile.ReadLine(); // Read question
                    int nrOfAns = int.Parse(inFile.ReadLine()); // Read number of answers

                    for (int i = 0; i < nrOfAns; i++)
                    {
                        this.answers.Add(inFile.ReadLine()); // Read each answer
                    }

                    this.correctAnswer = int.Parse(inFile.ReadLine()); // Read correct answer
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Could not open puzzle file!", ex);
            }
        }

        // Method to get puzzle as string
        public string GetAsString()
        {
            string answerList = "";

            for (int i = 0; i < this.answers.Count; i++)
            {
                answerList += $"{i}: {this.answers[i]}\n";
            }

            return $"{this.question}\n\n{answerList}\n";
        }

        // Property to get the correct answer
        public int CorrectAnswer
        {
            get { return this.correctAnswer; }
        }
    }
}
