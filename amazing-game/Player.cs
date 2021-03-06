using System;

namespace amazinggame
{
	/// <summary>
	/// Represents the player on the game board.
	/// Stores location, and direction the player is facing in.
	/// </summary>
	public class Player
	{
		/// <summary>
		/// X coordinate of the player (horizontal)
		/// </summary>
		/// 0 is leftmost space on the board
		public int x { get; set; }

		/// <summary>
		/// Y coordinate of the player (vertical)
		/// </summary>
		/// 0 is bottom space on the board
		public int y { get; set; }

		/// <summary>
		/// Which way the player is currently moving on the board.
		/// </summary>
		/// A move command will cause the player to move in the direction
		/// indicated here.
		public Direction Facing { get; internal set; }

		/// <summary>
		/// Allows the game to turn the player left, not for public consumption
		/// </summary>
		internal void TurnLeft ()
		{
			// We could do clever stuff here by converting to int,
			// using increment (++), and mod (%) to get the code simple,
			// but that would be harder for a human to follow, so we shalln't.
			switch (Facing)
			{
				// anti-clockwise, in order:
				case Direction.North:
					Facing = Direction.West;
					break;
				case Direction.West:
					Facing = Direction.South;
					break;
				case Direction.South:
					Facing = Direction.East;
					break;
				case Direction.East:
					Facing = Direction.North;
					break;
				default:
					// Throw invalid operation to reflect broken internal state.
					throw new InvalidOperationException(
						String.Format("Unexpected enum value encountered for Player.Facing: {0}", Facing));
			}
		}

		/// <summary>
		/// Allows the game to turn the player right, not for public consumption
		/// </summary>
		internal void TurnRight ()
		{
			switch (Facing)
			{
				// clockwise, in order:
				case Direction.North:
					Facing = Direction.East;
					break;
				case Direction.East:
					Facing = Direction.South;
					break;
				case Direction.South:
					Facing = Direction.West;
					break;
				case Direction.West:
					Facing = Direction.North;
					break;
				default:
					// Throw invalid operation to reflect broken internal state.
					throw new InvalidOperationException(
						String.Format("Unexpected enum value encountered for Player.Facing: {0}", Facing));
			}
		}

		public override string ToString ()
		{
			return string.Format ("[Player: x={0}, y={1}, Facing={2}]", x, y, Facing);
		}
	}
}
