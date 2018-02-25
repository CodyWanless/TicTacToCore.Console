using System;
namespace TicTacToCore.Console
{
	public sealed class WinHelper
	{
		public bool IsWinningMove(GameBoard gameBoard)
		{
			return false;
		}

		private bool HasHorizontalWin()
		{
			return false;
		}

		private bool HasVerticalWin()
		{
			return false;
		}

		private bool HasDiagonalWin()
		{
			return false;
		}
	}
}
