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
		public Player Player { get; private set; }

		public Game()
		{
			Player = new Player();
		}
	}
}
