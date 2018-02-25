using System;
using System.Threading.Tasks;
using Common.Model;

namespace TicTacToCore.Console
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Game.StartGame().Wait();
		}
	}
}
