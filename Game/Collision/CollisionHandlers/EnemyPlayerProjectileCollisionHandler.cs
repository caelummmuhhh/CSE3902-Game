using System;
using Microsoft.Xna.Framework;
using MainGame.Enemies;
using MainGame.Projectiles;

namespace MainGame.Collision.CollisionHandlers
{
	public class EnemyPlayerProjectileCollisionHandler: ICollisionHandler
    {
		public EnemyPlayerProjectileCollisionHandler(IEnemy enemy, IProjectile projectile, Rectangle overlap)
		{
		}

        public void HandleCollision()
        {
            throw new NotImplementedException();
        }
    }
}

