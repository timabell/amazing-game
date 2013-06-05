using System;

namespace amazinggame
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.Clear();
			var game = new Game();
			Console.Out.WriteLine("Amazing Game!! 2013, Tim Abell");
			Console.Out.WriteLine("Controls: M - move, L - turn left, R - turn right, Q - quit.");
			Console.Out.WriteLine();
			Console.Out.WriteLine(game);
		}
	}
}
