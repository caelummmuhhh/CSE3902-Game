using System;
using MainGame.Players;
using MainGame.Projectiles;

namespace MainGame.Collision.CollisionHandlers
{
    public class PlayerEnemyProjectileCollisionHandler : ICollisionHandler
    {
        private readonly IPlayer player;
        private readonly IProjectile projectile;

		public PlayerEnemyProjectileCollisionHandler(IPlayer player, IProjectile projectile)
		{
            this.player = player;
            this.projectile = projectile;
		}

        public void HandleCollision()
        {
            player.TakeDamage();
            // TODO handle projectile
        }
    }
}

