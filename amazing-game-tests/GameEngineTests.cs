using System;
using NUnit.Framework;

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
	}
}

