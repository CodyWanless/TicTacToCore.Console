using System;
namespace TicTacToCore.Console
{
	public static class MarkExtensions
	{
		public static Mark GetOpposite(this Mark mark)
		{
			return mark == Mark.O ? Mark.X : Mark.O;
		}
	}
}
