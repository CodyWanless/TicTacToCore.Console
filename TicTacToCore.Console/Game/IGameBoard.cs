using System.Collections.Generic;

namespace TicTacToCore.Console
{
	public interface IGameBoard
	{
		IEnumerable<Mark?> Marks { get; }

		void PlaceChoice(Mark mark, int location);
		void Draw();
	}
}
