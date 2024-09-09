using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSharpConsoleRPG.GamePlay
{
    public class Puzzle
    {
        public string Question { get; private set; }
        public List<string> Answers { get; private set; }
        public int CorrectAnswer { get; private set; }

        // Constructor
        public Puzzle(string fileName)
        {
            Answers = new List<string>();
            CorrectAnswer = 0;

            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    Question = reader.ReadLine();
                    int nrOfAns = int.Parse(reader.ReadLine().Trim());

                    for (int i = 0; i < nrOfAns; i++)
                    {
                        Answers.Add(reader.ReadLine());
                    }

                    CorrectAnswer = int.Parse(reader.ReadLine().Trim());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Could not open puzzle!", ex);
            }
        }

        public string GetAsString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Question);
            sb.AppendLine();

            for (int i = 0; i < Answers.Count; i++)
            {
                sb.AppendLine($"{i}: {Answers[i]}");
            }

            sb.AppendLine();
            sb.AppendLine(CorrectAnswer.ToString());

            return sb.ToString();
        }
    }
}
