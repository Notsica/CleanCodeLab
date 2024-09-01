namespace CleanCodeLab
{
	class Program
	{
		static void Main(string[] args)
		{
			IGameStatistics gameStatistics = new GameStatistics();
			GameUI gameUI = new GameUI();

			GameLogic game = new GameLogic(gameStatistics, gameUI);
			game.Start();
		}
	}
}