using System.Collections.Generic;
using System.Linq;
using System;

namespace TicTacToCore.Console
{
	internal sealed class GameBoard : IGameBoard
	{
		private readonly Mark?[] marks;
		public IEnumerable<Mark?> Marks => marks;
		public bool HasMovesLeft => this.marks.Any(m => !m.HasValue);

		public GameBoard()
		{
			this.marks = Enumerable.Range(0, 9)
				.Select(_ => (Mark?)null)
				.ToArray();
		}

		public IReadOnlyList<int> GetOpenLocations()
		{
			return this.marks.Select((m, i) =>
				  new
				  {
					  IsEmpty = !m.HasValue,
					  Index = i
				  }).Where(x => x.IsEmpty).Select(x => x.Index).ToList();
		}

		public void PlaceChoice(Mark mark, int location)
		{
			if (marks[location] != null)
			{
				throw new ArgumentException(nameof(location));
			}

			this.marks[location] = mark;
		}

		public void RemoveChoice(Mark mark, int location)
		{
			if (marks[location] != mark)
			{
				throw new ArgumentException(nameof(location));
			}

			this.marks[location] = null;
		}

		public void Draw()
		{
			for (int i = 0; i < 9; i++)
			{
				System.Console.Write($"  {GetTextForIndex(i)}{((i + 1) % 3 != 0 ? " |" : string.Empty)}");
				if (i < 7 && (i + 1) % 3 == 0)
				{
					System.Console.WriteLine();
					System.Console.WriteLine("-------------");
				}
			}

			System.Console.WriteLine();
			System.Console.WriteLine();
		}

		private string GetTextForIndex(int index)
		{
			return this.marks[index] == null ? index.ToString() : this.marks[index].ToString();
		}
	}
}