using System.IO;
using System.Collections.Generic;
using System;
using CleanCodeLab.Models;

namespace CleanCodeLab
{
	public class GameStatistics : IGameStatistics
	{

        public void SaveGameResult(string playerName, int guessCount)
		{
			using (StreamWriter output = new StreamWriter("result.txt", append: true))
			{
				output.WriteLine($"{playerName}#&#{guessCount}");
			}
		}

		//clean up
		public List<PlayerData> GetGameTopResults()
		{
			List<PlayerData> results = new List<PlayerData>();
			using (StreamReader input = new StreamReader("result.txt"))
			{
				string line;
				while ((line = input.ReadLine()) != null)
				{
					string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
					string name = nameAndScore[0];
					int guesses = Convert.ToInt32(nameAndScore[1]);
					PlayerData pd = new PlayerData(name, guesses);
					int pos = results.IndexOf(pd);
					if (pos < 0)
					{
						results.Add(pd);
					}
					else
					{
						results[pos].Update(guesses);
					}
				}
				results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
				return results;
			}
		}
	}
}
