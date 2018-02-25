using System;
using System.Threading.Tasks;

namespace TicTacToCore.Console
{
	public class Game
	{
		public static async Task StartGame()
		{
			var playerX = new Player(Mark.X, new PlayerStrategy());
			var aiPlayer = new Player(Mark.O, new AIStrategy());
			var gameBoard = new GameBoard();

			var turnCounter = 0;
			do
			{
				gameBoard.Draw();
				Player currentPlayer = null;
				if (turnCounter % 2 == 0)
				{
					currentPlayer = playerX;
				}
				else
				{
					currentPlayer = aiPlayer;
				}

				await currentPlayer.PlayTurn(gameBoard);
				turnCounter++;
			} while (!GameOver(gameBoard));
		}

		private static bool GameOver(IGameBoard gameBoard) =>
			WinHelper.IsWinningMove(gameBoard);
	}
}
