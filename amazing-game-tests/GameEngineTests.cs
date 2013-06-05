using System;
using NUnit.Framework;
using amazinggame;

namespace amazinggametests
{
	[TestFixture()]
	public class GameEngineTests
	{
		[Test()]
		public void IntialState_PlayerAtOrigin()
		{
			var game = new Game();
			Assert.AreEqual(0, game.Player.x);
			Assert.AreEqual(0, game.Player.y);
		}

		[Test()]
		public void IntialState_PlayerFacingNorth()
		{
			var game = new Game();
			Assert.AreEqual(Direction.North, game.Player.Facing);
		}

		[Test()]
		public void IntialState_BoardSize()
		{
			var game = new Game();
			Assert.AreEqual(4, game.MaxX);
			Assert.AreEqual(4, game.MaxY);
		}
	}
}

