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

		[Test()]
		public void TestMovesToBoardEdge()
		{
			var game = new Game();
			for (int count = 1; count < 5; count++){
				game.ExecutePlayerCommand(PlayerCommand.Move);
			}
			Assert.AreEqual(0, game.Player.x, "Unexpected X axis movement");
			Assert.AreEqual(4, game.Player.y, "Player failed to move to North edge of the board");
		}

		[Test()]
		public void TestDoesntMovePastBoardEdge()
		{
			var game = new Game();
			for (int count = 1; count < 6; count++){
				game.ExecutePlayerCommand(PlayerCommand.Move);
			}
			Assert.AreEqual(0, game.Player.x, "Unexpected X axis movement");
			Assert.AreEqual(4, game.Player.y, "Player didn't stop at the North edge of the board");
		}

		/// <summary>
		/// Tests pattern1 end game.
		/// Moves: MRMLMRM
		/// End: 2, 2 E
		/// </summary>
		[Test()]
		public void TestPattern1_EndGame()
		{
			// initialise
			var game = new Game();

			// act
			game.ExecutePlayerCommand(PlayerCommand.Move);  // 0,1 N
			game.ExecutePlayerCommand(PlayerCommand.Right); // 0,1 E
			game.ExecutePlayerCommand(PlayerCommand.Move);  // 1,1 E
			game.ExecutePlayerCommand(PlayerCommand.Left);  // 1,1 N
			game.ExecutePlayerCommand(PlayerCommand.Move);  // 1,2 N
			game.ExecutePlayerCommand(PlayerCommand.Right); // 1,2 E
			game.ExecutePlayerCommand(PlayerCommand.Move);  // 2,2 E

			// assert
			Assert.AreEqual(2, game.Player.x, "Pattern 1 - player failed to end at x=2");
			Assert.AreEqual(2, game.Player.y, "Pattern 1 - player failed to end at y=2");
			Assert.AreEqual(Direction.East, game.Player.Facing, "Pattern 1 - player isn't facing the right way");
		}

		/// <summary>
		/// Tests pattern2 end game.
		/// Moves: RMMMLMM
		/// End: 3, 2 N
		/// </summary>
		[Test()]
		public void TestPattern2_EndGame()
		{
			// initialise
			var game = new Game();

			// act
			game.ExecutePlayerCommand(PlayerCommand.Right); // 0,0 E
			game.ExecutePlayerCommand(PlayerCommand.Move);  // 1,0 E
			game.ExecutePlayerCommand(PlayerCommand.Move);  // 2,0 E
			game.ExecutePlayerCommand(PlayerCommand.Move);  // 3,0 E
			game.ExecutePlayerCommand(PlayerCommand.Left);  // 3,0 N
			game.ExecutePlayerCommand(PlayerCommand.Move);  // 3,1 N
			game.ExecutePlayerCommand(PlayerCommand.Move);  // 3,2 N

			// assert
			Assert.AreEqual(3, game.Player.x, "Pattern 1 - player failed to end at x=2");
			Assert.AreEqual(2, game.Player.y, "Pattern 1 - player failed to end at y=2");
			Assert.AreEqual(Direction.North, game.Player.Facing, "Pattern 1 - player isn't facing the right way");
		}
	}
}

