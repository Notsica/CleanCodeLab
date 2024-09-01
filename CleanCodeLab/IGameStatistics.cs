using CleanCodeLab.Models;
using System.Collections.Generic;

namespace CleanCodeLab
{
	public interface IGameStatistics
	{
		void SaveGameResult(string playerName, int guessCount);
		List<PlayerData> GetGameTopResults();
	}
}
