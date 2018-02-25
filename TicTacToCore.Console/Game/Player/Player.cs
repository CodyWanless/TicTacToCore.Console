using System;
using System.Threading.Tasks;
namespace TicTacToCore.Console
{
	public sealed class Player
	{
		private readonly Mark mark;
		private readonly IStrategy strategy;

		public Player(Mark mark, IStrategy strategy)
		{
			this.mark = mark;
			this.strategy = strategy;
		}

		public Task PlayTurn(IGameBoard gameBoard)
		{
			return strategy.PlayTurn(gameBoard, this.mark);
		}
	}
}
