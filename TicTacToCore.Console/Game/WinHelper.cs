using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToCore.Console
{
	public sealed class WinHelper
	{
		public static bool IsWinningMove(IGameBoard gameBoard)
		{
			var marks = gameBoard.Marks.ToArray();

			return HasHorizontalWin(marks)
				|| HasVerticalWin(marks)
				|| HasDiagonalWin(marks);
		}

		private static bool HasHorizontalWin(Mark?[] marks)
		{
			var rows = marks.Select((val, i) => new { Value = val, Index = i })
							.GroupBy(item => item.Index / 3, item => item.Value);

			foreach (var row in rows)
			{
				if (ValidateRow(row))
				{
					return true;
				}
			}

			return false;
		}

		private static bool HasVerticalWin(Mark?[] marks)
		{
			var columns = marks.Select((val, i) => new { Value = val, Index = i })
							   .GroupBy(item => item.Index % 3, item => item.Value);
			foreach (var column in columns)
			{
				if (ValidateRow(column))
				{
					return true;
				}
			}

			return false;
		}

		private static bool HasDiagonalWin(Mark?[] marks)
		{
			var diagonals = new[]
			{
				new[] { marks[0], marks[4], marks[8] },
				new[] { marks[2], marks[4], marks[6] }
			};

			foreach (var diagonal in diagonals)
			{
				if (ValidateRow(diagonal))
				{
					return true;
				}
			}

			return false;
		}

		private static bool ValidateRow(IEnumerable<Mark?> group)
		{
			if (group.Any(x => x == null))
			{
				return false;
			}

			return group.Distinct().Count() == 1;
		}
	}
}
