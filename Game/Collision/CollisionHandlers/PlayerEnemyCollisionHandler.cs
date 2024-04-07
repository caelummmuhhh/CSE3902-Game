using System;
using Microsoft.Xna.Framework;
using MainGame.Enemies;
using MainGame.Players;

namespace MainGame.Collision.CollisionHandlers
{
	public class PlayerEnemyCollisionHandler : ICollisionHandler
	{
		private readonly IPlayer player;

		public PlayerEnemyCollisionHandler(IPlayer player, IEnemy enemy)
		{
			this.player = player;
		}

        public void HandleCollision()
        {
			player.TakeDamage();
        }
    }
}

