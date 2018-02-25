using System;
using System.Threading.Tasks;

namespace TicTacToCore.Console
{
	internal sealed class PlayerStrategy : IStrategy
	{
		public Task PlayTurn(IGameBoard gameBoard, Mark mark)
		{
			bool validChoice = false;
			do
			{
				try
				{
					System.Console.Write("Enter Selection: ");
					var choice = System.Console.ReadLine();
					if (int.TryParse(choice, out int location))
					{
						validChoice = true;
						gameBoard.PlaceChoice(mark, location);
					}
					else
					{
						System.Console.WriteLine("Invalid Selection");
					}
				}
				catch (Exception)
				{
					validChoice = false;
					System.Console.WriteLine("Invalid Selection");
				}
			} while (!validChoice);

			return Task.FromResult(0);
		}
	}
}
