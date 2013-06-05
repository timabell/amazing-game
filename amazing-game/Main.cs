using System;
using System.Text;

namespace amazinggame
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var game = new Game();
			char command = ' ';
			var history = new StringBuilder();
			while (command != 'q' && command != 'Q') {
				// redraw
				// TODO: overwrite chars instead to avoid flickering.
				Console.Clear();
				Console.Out.WriteLine("Amazing Game!! 2013, Tim Abell");
				Console.Out.WriteLine("Controls: M - move, L - turn left, R - turn right, Q - quit.");
				Console.Out.WriteLine();
				Console.Out.WriteLine(game);
				Console.Out.WriteLine();

				// wait for user command
				Console.Out.Write("Enter command: ");
				Console.Out.Write(history);
				var key = Console.ReadKey();
				command = key.KeyChar;
				history.Append(command);

				// make a move, ignore irrelevant keystrokes
				// TODO: use CompareTo() to cope with international keys
				switch (command){
				case 'm':
				case 'M':
					game.ExecutePlayerCommand(PlayerCommand.Move);
					break;
				case 'l':
				case 'L':
					game.ExecutePlayerCommand(PlayerCommand.Left);
					break;
				case 'r':
				case 'R':
					game.ExecutePlayerCommand(PlayerCommand.Right);
					break;
				}
			}
		}
	}
}
