using Microsoft.VisualStudio.TestTools.UnitTesting;
using CleanCodeLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab.Tests
{
	[TestClass()]
	public class GameLogicTests
	{
		[TestMethod()]
		public void CheckPlayerGuess_CorrectGuess_ReturnsBulls()
		{
			// Arrange
			string goal = "1234";
			string guess = "1234";

			// Act
			string result = GameLogic.CheckPlayerGuess(goal, guess);

			// Assert
			Assert.AreEqual("BBBB,", result);
		}

		[TestMethod()]
		public void CheckPlayerGuess_EntirelyIncorrectGuess_ReturnsComma()
		{
			// Arrange
			string goal = "1234";
			string guess = "5555";

			// Act
			string result = GameLogic.CheckPlayerGuess(goal, guess);

			// Assert
			Assert.AreEqual(",", result);
		}

		[TestMethod()]
		public void CheckPlayerGuess_CorrectGuessWithJumbledOrder_ReturnsCows()
		{
			// Arrange
			string goal = "1234";
			string guess = "4321";

			// Act
			string result = GameLogic.CheckPlayerGuess(goal, guess);

			// Assert
			Assert.AreEqual(",CCCC", result);
		}

		[TestMethod()]
		public void CheckPlayerGuess_HalfCorrectHalfWrongGuess_ReturnsBullsAndCows()
		{
			// Arrange
			string goal = "1234";
			string guess = "1289";

			// Act
			string result = GameLogic.CheckPlayerGuess(goal, guess);

			// Assert
			Assert.AreEqual("BB,", result);
		}

		[TestMethod()]
		public void MakeGoal_GenerateGoal_Generates4UniqueNumbers()
		{
			//Act
			string goal = GameLogic.MakeGoal();

			//Assert
			Assert.AreEqual(4, goal.Length);
			Assert.AreEqual(4, goal.Distinct().Count());
			Assert.IsTrue(goal.All(char.IsDigit));
		}
	}
}