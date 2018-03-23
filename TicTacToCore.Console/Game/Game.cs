using System;
using System.Threading.Tasks;

namespace TicTacToCore.Console
{
	public static class Game
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
			} while (!GameOver(gameBoard, () => turnCounter++));

			if (turnCounter % 2 == 0)
			{
				System.Console.WriteLine("Player wins!");
			}
			else
			{
				System.Console.WriteLine("AI wins!");
			}
		}

		private static bool GameOver(IGameBoard gameBoard, Action nextTurnAction)
		{
			if (WinHelper.IsWinningMove(gameBoard))
			{
				return true;
			}

			nextTurnAction?.Invoke();
			return false;
		}
	}
}
