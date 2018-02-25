using System.Collections.Generic;
using System.Linq;
using System;

namespace TicTacToCore.Console
{
	public sealed class GameBoard
	{
		private readonly Mark?[] marks;

		public GameBoard()
		{
			this.marks = Enumerable.Range(0, 9)
				.Select(_ => (Mark?)null)
				.ToArray<Mark?>();
		}

		public void PlaceChoice(Mark mark, int location)
		{
			if (marks[location] != null)
			{
				throw new ArgumentException(nameof(location));
			}

			this.marks[location] = mark;
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