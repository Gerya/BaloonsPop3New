﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Zirconium
{
    public static class TopScore
    {
        private const int MAX_TOP_SCORE_COUNT = 5;
        private static readonly List<Player> TopScoreList = new List<Player>();

        public static bool IsTopScore(Player person)
        {
            if (TopScoreList.Count >= MAX_TOP_SCORE_COUNT)
            {
                int lastTopScorePlayer = MAX_TOP_SCORE_COUNT - 1;
                TopScoreList.Sort();
                if (TopScoreList[lastTopScorePlayer] > person)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public static void AddToTopScoreList(Player person)
        {
            TopScoreList.Add(person);
            TopScoreList.Sort();
            while (TopScoreList.Count > 5)
            {
                TopScoreList.RemoveAt(5);
            }
        }

        public static void OpenTopScoreList()
        {

            using (StreamReader topScoreStreamReader = new StreamReader("..\\..\\TopScore.txt"))
            {
                string line = topScoreStreamReader.ReadLine();
                while (line != null)
                {
                    char[] separators = { ' ' };
                    string[] substrings = line.Split(separators);
                    int substringsCount = substrings.Count<string>();

                    if (substringsCount > 0)
                    {
                        Player player = new Player();
                        player.Name = substrings[1];
                        player.Score = int.Parse(substrings[substringsCount - 2]);
                        TopScoreList.Add(player);
                    }

                    line = topScoreStreamReader.ReadLine();
                }
            }
        }

        public static void SaveTopScoreList()
        {
            if (TopScoreList.Count > 0)
            {
                StringBuilder toWriteInFile = new StringBuilder();

                using (StreamWriter topScoreStreamReader = new StreamWriter("..\\..\\TopScore.txt"))
                {
                    for (int index = 0; index < TopScoreList.Count; index++)
                    {
                        toWriteInFile.AppendFormat("{0} . {1,-10}  --> {2,2} moves", index + 1, TopScoreList[index].Name, TopScoreList[index].Score);
                        toWriteInFile.AppendLine();
                    }

                    topScoreStreamReader.Write(toWriteInFile.ToString());
                }
            }
        }

        private static string Renderer()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Scoreboard:");
            if (TopScoreList.Count > 0)
            {
                for (int index = 0; index < TopScoreList.Count; index++)
                {
                    result.AppendLine(string.Format("{0} . {1,-10}  --> {2,2} moves",
                        index + 1, TopScoreList[index].Name, TopScoreList[index].Score));
                }
            }
            else
            {
                result.AppendLine("Scoreboard is empty");
            }

            return result.ToString();
        }

        public static void PrintScoreList()
        {
            Console.WriteLine(TopScore.Renderer());
        }
    }
}
