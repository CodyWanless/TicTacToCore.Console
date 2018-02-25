using System;
using System.Threading.Tasks;

namespace TicTacToCore.Console
{
	public interface IStrategy
	{
		Task PlayTurn(GameBoard gameBoard, Mark mark);
	}
}
