using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToCore.Console.Test
{
	public class TestableGameBoard : Console.IGameBoard
	{
		private Mark?[] marks;
		public IEnumerable<Mark?> Marks
		{
			get => marks;
			set
			{
				if (marks.Count() != 9)
				{
					throw new Exception("Invalid array");
				}
				marks = value.ToArray();
			}
		}

		public bool HasMovesLeft => throw new NotImplementedException();

		public TestableGameBoard()
		{
			this.marks = Enumerable.Range(0, 9).Select(_ => (Mark?)null).ToArray();
		}

		public void Draw()
		{

		}

		public void PlaceChoice(Mark mark, int location)
		{
			marks[location] = mark;
		}

		public void RemoveChoice(Mark mark, int location)
		{
			throw new NotImplementedException();
		}

		public IReadOnlyList<int> GetOpenLocations()
		{
			throw new NotImplementedException();
		}
	}
}
