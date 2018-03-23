using System.Collections.Generic;

namespace TicTacToCore.Console
{
	public interface IGameBoard
	{
		IEnumerable<Mark?> Marks { get; }
		bool HasMovesLeft { get; }

		void PlaceChoice(Mark mark, int location);
		void RemoveChoice(Mark mark, int location);
		IReadOnlyList<int> GetOpenLocations();
		void Draw();
	}
}
