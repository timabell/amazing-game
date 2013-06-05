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
			Assert.AreEqual(4, game.MaxX, "incorrect board size on X-axis");
			Assert.AreEqual(4, game.MaxY, "incorrect board size on Y-axis");
		}

		[Test()]
		public void TestPattern1_Move1()
		{
			// check first move puts player in position 0,1 (because facing North)
			var game = new Game();
			game.ExecutePlayerCommand(PlayerCommand.Move);
			Assert.AreEqual(0, game.Player.x, "Unexpected X axis movement");
			Assert.AreEqual(1, game.Player.y, "Player failed to move one position to the North");
		}
	}
}

