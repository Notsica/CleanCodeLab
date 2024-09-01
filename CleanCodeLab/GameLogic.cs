using System;

namespace CleanCodeLab
{
	public class GameLogic
	{
		private readonly IGameStatistics _gameStatistics;
		private readonly GameUI _gameUI;

		public GameLogic(IGameStatistics gameStatistics, GameUI gameUI)
		{
			_gameStatistics = gameStatistics;
			_gameUI = gameUI;
		}


		public void Start()
		{
			bool playOn = true;
			string playerName = _gameUI.GetUserName();

			while (playOn)
			{
				string goal = MakeGoal();

				_gameUI.ShowNewGameText(goal);
				string playerGuess = _gameUI.GetPlayerGuess();

				int guessCount = 1;
				string bullsAndCows = CheckPlayerGuess(goal, playerGuess);
				_gameUI.ShowPlayerBullsAndCows(bullsAndCows);
				while (bullsAndCows != "BBBB,")
				{
					guessCount++;
					playerGuess = _gameUI.GetPlayerGuess();
					_gameUI.ShowPlayerGuess(playerGuess);
					bullsAndCows = CheckPlayerGuess(goal, playerGuess);
					_gameUI.ShowPlayerBullsAndCows(bullsAndCows);
				}

				_gameStatistics.SaveGameResult(playerName, guessCount);
				var topResults = _gameStatistics.GetGameTopResults();
				_gameUI.ShowTopResults(topResults);

				playOn = _gameUI.AskToContinueGame(guessCount);

			}
		}
		public static string MakeGoal()
		{
			Random randomGenerator = new Random();
			string goal = "";
			for (int i = 0; i < 4; i++)
			{
				int random = randomGenerator.Next(10);
				string randomDigit = "" + random;
				while (goal.Contains(randomDigit))
				{
					random = randomGenerator.Next(10);
					randomDigit = "" + random;
				}
				goal += randomDigit;
			}
			return goal;
		}

		public static string CheckPlayerGuess(string goal, string guess)
		{
			int cows = 0, bulls = 0;
			guess += "    ";     // if player entered less than 4 chars
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					if (goal[i] == guess[j])
					{
						if (i == j)
						{
							bulls++;
						}
						else
						{
							cows++;
						}
					}
				}
			}
			return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
		}
	}
}
