using System;
using Microsoft.Xna.Framework;
using MainGame.Enemies;
using MainGame.Players;
using MainGame.Projectiles;

namespace MainGame.Collision.CollisionHandlers
{
	public class PlayerEnemyCollisionHandler : ICollisionHandler
	{
		private readonly IPlayer player;
		private readonly IEnemy enemy;

		public PlayerEnemyCollisionHandler(IPlayer player, IEnemy enemy)
		{
			this.player = player;
			this.enemy = enemy;
		}

        public void HandleCollision()
        {
            Direction playerSideDamaged = Utils.GetCardinalDirectionFrom(player.Position, enemy.Position);
            player.TakeDamage(playerSideDamaged);
        }
    }
}

