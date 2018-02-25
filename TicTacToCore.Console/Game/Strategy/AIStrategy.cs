using System;
using System.Threading.Tasks;

namespace TicTacToCore.Console
{
	public class AIStrategy : IStrategy
	{
		public AIStrategy()
		{
		}

		public Task PlayTurn(IGameBoard gameBoard, Mark mark) => Task.FromResult(0);
	}
}
