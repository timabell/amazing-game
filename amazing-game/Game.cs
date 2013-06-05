using System;
// TODO: move this to its own class library to enable re-use.
//  - I'd probably add a User Story reference to this TODO for a real project

namespace amazinggame
{
	/// <summary>
	/// This is the engine for the game,
	/// encapsulating all the rules of play
	/// and the interactions the player can use.
	/// </summary>
	public class Game
	{
		private const int BOARD_SIZE = 5;

		public Player Player { get; private set; }

		// TODO: investigate use of a point class instead of separate ints.
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
					return;
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
			switch (Player.Facing)
			{
				case Direction.North:
					Player.y++;
					break;
				case Direction.East:
					Player.y++;
					break;
				case Direction.South:
					Player.y++;
					break;
				case Direction.West:
					Player.y++;
					break;
				default:
					// Throw invalid operation to reflect broken internal state.
					throw new InvalidOperationException(
						String.Format("Unexpected enum value encountered for Player.Facing: {0}", Player.Facing));
			}
		}
	}
}
