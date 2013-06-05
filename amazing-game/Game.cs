using System;
using System.Text;

// TODO: move this to its own class library to enable re-use.
//  - I'd probably add a User Story reference to this TODO for a real project

// TODO: There's a dilemma here as to whether the game or the player
//  should control the movement of a player. Currently the game controls
//  the moves as this requires knowledge of the edge of the board, but the
//  player can be told to turn left or right and will update its state.
//  This probably needs a bit more thought as it smells a bit funny.
//  Hopefully the correct approach will become clear as requirements are
//  added; and the unit tests will keep us safe from [most] mistakes.

namespace amazinggame
{
	/// <summary>
	/// This is the engine for the game,
	/// encapsulating all the rules of play
	/// and the interactions the player can use.
	/// </summary>
	/// The player object keeps the state information for the player
	/// as this is a separate concern to the engine of the game.
	/// The game engine (this class) 'instructs' the player to update its
	/// state, and the player performs the change and can report its new
	/// location and orientation.
	public class Game
	{
		private const int BOARD_SIZE = 5;

		public Player Player { get; private set; }

		// TODO: investigate use of a point class instead of separate ints.
		//   there's one in System.Windows.Point which might be the right one.
		public int MaxX { get; private set; }
		public int MaxY { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="amazinggame.Game"/> class.
		/// Sets up the board and Player ready for play to begin. Have fun!!
		/// </summary>
		public Game()
		{
			MaxX = BOARD_SIZE - 1; // offset for zero-based index vs. one-based size information
			MaxY = BOARD_SIZE - 1;

			Player = new Player();

			// Start the player facing North:
			// (Although this is the default value for the enum
			// it is set explicitly anyway to avoid confusion
			// due to use of magic)
			Player.Facing = Direction.North;
		}

		public void ExecutePlayerCommand(PlayerCommand command)
		{
			switch (command)
			{
				case PlayerCommand.Move:
					MovePlayer();
					break;
				case PlayerCommand.Left:
					Player.TurnLeft();
					break;
				case PlayerCommand.Right:
					Player.TurnRight();
					break;
				default: // here be dragons
					// Where did that come from? Bad programmer, you didn't finish your refactoring, as a prize you get this exception:
					throw new NotSupportedException(
						String.Format("Unexpected enum value encountered for PlayerCommand: {0}", command));
			}
		}

		/// <summary>
		/// Moves the player one step in the direction they are facing.
		/// </summary>
		private void MovePlayer ()
		{
			// Move the player unless already at a board edge (that's what the spec asks for)
			switch (Player.Facing)
			{
				case Direction.North:
					if (Player.y < MaxY) {
						Player.y++;
					}
					break;
				case Direction.East:
					if (Player.x < MaxX) {
						Player.x++;
					}
					break;
				case Direction.South:
					if (Player.y > 0) {
						Player.y--;
					}
					break;
				case Direction.West:
					if (Player.x > 0) {
						Player.x--;
					}
					break;
				default:
					// Throw invalid operation to reflect broken internal state.
					throw new InvalidOperationException(
						String.Format("Unexpected enum value encountered for Player.Facing: {0}", Player.Facing));
			}
		}

		public override string ToString ()
		{
			var sb = new StringBuilder();
			sb.AppendFormat("[Game: Player={0}, MaxX={1}, MaxY={2}]", Player, MaxX, MaxY);

			// diy curses! TODO: find a better way of doing this

			/* Output:
				 ------------
				4| X X X X X |
				3| X X X X X |
				2| X X X X X |
				1| @ X X X X |
				 ------------
				   0 1 2 3 4
			 **/
			sb.AppendLine();
			// top border
			sb.Append(' ');
			sb.Append('-', MaxX * 2 + 5); // double spacing, plus 2 side borders
			sb.AppendLine();
			for (int y = MaxY; y >= 0; y--) {
				sb.Append(y);
				sb.Append("|");
				for (int x = 0; x <= MaxX; x++) {
					if (x == Player.x && y == Player.y) {
						switch (Player.Facing)
						{
							// clockwise, in order:
							case Direction.North:
								sb.Append(" ^");
								break;
							case Direction.East:
								sb.Append(" >");
								break;
							case Direction.South:
								sb.Append(" v");
								break;
							case Direction.West:
								sb.Append(" <");
								break;
							default:
								// Throw invalid operation to reflect broken internal state.
								throw new InvalidOperationException(
									String.Format("Unexpected enum value encountered for Player.Facing: {0}", Player.Facing));
						}
					} else {
						sb.Append(" X");
					}
				}
				sb.AppendLine(" |");
			}
			// bottom border
			sb.Append(' ');
			sb.Append('-', MaxX * 2 + 5); // double spacing, plus 2 char side border
			sb.AppendLine();
			sb.Append("  ");
			for (int x = 0; x <= MaxX; x++) {
				sb.Append(' ');
				sb.Append(x);
			}
			sb.AppendLine();
			return sb.ToString();
		}
	}
}
