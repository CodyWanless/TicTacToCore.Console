using System;
using Xunit;

namespace TicTacToCore.Console.Test
{
	public class WinHelperTest
	{
		[Fact]
		public void ValidateNoWin()
		{
			var gameBoard = new TestableGameBoard();

			Assert.False(WinHelper.IsWinningMove(gameBoard));
		}

		[Fact]
		public void ValidateVerticalWin()
		{
			var gameBoard = new TestableGameBoard
			{
				Marks = new Mark?[] { Mark.X, null, null, Mark.X, null, null, Mark.X, null, null }
			};

			Assert.True(WinHelper.IsWinningMove(gameBoard));
		}

		[Fact]
		public void ValidateHorizontalWin()
		{
			var gameBoard = new TestableGameBoard
			{
				Marks = new Mark?[] { Mark.X, Mark.X, Mark.X, null, null, null, null, null, null }
			};

			Assert.True(WinHelper.IsWinningMove(gameBoard));
		}

		[Fact]
		public void ValidateDiagonalWin()
		{
			var gameBoard = new TestableGameBoard
			{
				Marks = new Mark?[] { Mark.X, null, null, null, Mark.X, null, null, null, Mark.X }
			};

			Assert.True(WinHelper.IsWinningMove(gameBoard));
		}

		[Fact]
		public void ValidateOtherDiagonalWin()
		{
			var gameBoard = new TestableGameBoard
			{
				Marks = new Mark?[] { null, null, Mark.X, null, Mark.X, null, Mark.X, null, null }
			};

			Assert.True(WinHelper.IsWinningMove(gameBoard));
		}
	}
}
