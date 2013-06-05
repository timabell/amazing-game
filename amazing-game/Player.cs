using System;

namespace amazinggame
{
	/// <summary>
	/// Represents the player on the game board
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
	}
}
