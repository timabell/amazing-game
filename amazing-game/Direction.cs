using System;

namespace amazinggame
{
	/// <summary>
	/// Directions available on the board.
	/// </summary>
	public enum Direction
	{
		// I've commented these properly as this is the kind of
		// thing that causes confusion later on if it's not explicit.

		/// <summary>
		/// Up - away from 0 (zero) on the Y-axis
		/// </summary>
		North,

		/// <summary>
		/// Right - away from 0 (zero) on the X-axis
		/// </summary>
		East,

		/// <summary>
		/// Down - towards 0 (zero) on the Y-axis
		/// </summary>
		South,

		/// <summary>
		/// Left - towards 0 (zero) on the X-axis
		/// </summary>
		West
	}
}

