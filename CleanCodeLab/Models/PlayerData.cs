using System;

namespace CleanCodeLab.Models
{
	public class PlayerData
	{
		public string Name { get; private set; }
		public int GameRoundsPlayed { get; private set; }
		int TotalGuessCount;


		public PlayerData(string name, int guesses)
		{
			this.Name = name;
			GameRoundsPlayed = 1;
			TotalGuessCount = guesses;
		}

		public void Update(int guesses)
		{
			TotalGuessCount += guesses;
			GameRoundsPlayed++;
		}

		public double Average()
		{
			return (double)TotalGuessCount / GameRoundsPlayed;
		}


		public override bool Equals(Object p)
		{
			return Name.Equals(((PlayerData)p).Name);
		}


		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}
	}
}
