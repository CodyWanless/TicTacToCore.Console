using System;
using System.Threading.Tasks;
using System.Data;

namespace TicTacToCore.Console
{
	public class AIStrategy : IStrategy
	{
		private Mark aiMark;
		private const int winValue = 10;
		private const int loseValue = -10;

		public Task PlayTurn(IGameBoard gameBoard, Mark mark)
		{
			// todo: this feels weird
			this.aiMark = mark;

			int bestMoveVal = int.MaxValue;
			int bestMoveLocation = -1;

			foreach (var openLocation in gameBoard.GetOpenLocations())
			{
				// try the move
				gameBoard.PlaceChoice(mark, openLocation);

				var moveValue = Minimax(gameBoard, mark.GetOpposite());

				if (moveValue < bestMoveVal)
				{
					bestMoveVal = moveValue;
					bestMoveLocation = openLocation;
				}

				gameBoard.RemoveChoice(mark, openLocation);
			}

			gameBoard.PlaceChoice(mark, bestMoveLocation);

			return Task.FromResult(0);
		}

		internal int Minimax(IGameBoard gameBoard, Mark currentMark)
		{
			var score = EvaluateMove(gameBoard, currentMark);

			if (score == winValue || score == loseValue)
				return score;

			if (!gameBoard.HasMovesLeft)
				return 0;

			int best;
			if (currentMark == aiMark)
			{
				best = int.MinValue;
				foreach (var openLocation in gameBoard.GetOpenLocations())
				{
					// try the location
					gameBoard.PlaceChoice(currentMark, openLocation);

					best = Math.Max(best,
									this.Minimax(gameBoard, currentMark.GetOpposite()));

					// clean up after our dirty self
					gameBoard.RemoveChoice(currentMark, openLocation);
				}
			}
			else
			{
				best = int.MaxValue;
				foreach (var openLocation in gameBoard.GetOpenLocations())
				{
					// try the location
					gameBoard.PlaceChoice(currentMark, openLocation);

					best = Math.Min(best,
									this.Minimax(gameBoard, currentMark.GetOpposite()));

					// clean up after our dirty self
					gameBoard.RemoveChoice(currentMark, openLocation);
				}
			}

			return best;
		}

		internal int EvaluateMove(IGameBoard gameBoard, Mark currentMark)
		{
			if (WinHelper.IsWinningMove(gameBoard))
			{
				return aiMark == currentMark ? winValue : loseValue;
			}

			return 0;
		}
	}
}
