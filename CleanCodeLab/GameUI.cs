using CleanCodeLab.Models;
using System;
using System.Collections.Generic;

namespace CleanCodeLab
{
	public class GameUI
	{
		public string GetUserName() {
			Console.WriteLine("Enter your user name:\n");
			string playerName = Console.ReadLine();
			return playerName;
		}

		public void ShowNewGameText(string goal)
		{
			Console.WriteLine("New game:\n");
			//comment out or remove next line to play real games!
			Console.WriteLine("For practice, number is: " + goal + "\n");
		}

		public string GetPlayerGuess()
		{
			return Console.ReadLine();
		}

		public void ShowPlayerBullsAndCows(string bullsAndCows)
		{
			Console.WriteLine($"{bullsAndCows}\n");
		}

		public void ShowPlayerGuess(string playerGuess)
		{
			Console.WriteLine(playerGuess + "\n");
		}

		public void ShowTopResults(List<PlayerData> results)
		{
			Console.WriteLine("Player   games average");
			foreach (PlayerData p in results)
			{
				Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.GameRoundsPlayed, p.Average()));
			}
		}

		public bool AskToContinueGame(int guessCount)
		{
			Console.WriteLine($"Correct, it took {guessCount} guesses.\nDo you want to continue? (Type 'no' to end the game)");
			string answer = Console.ReadLine();
			if (!String.IsNullOrEmpty(answer) && answer.ToLower().StartsWith("n"))
			{
				return false;
			};
			return true; 
		}

	}
}
