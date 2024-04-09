using System;
using Microsoft.Xna.Framework;
using MainGame.Projectiles;

namespace MainGame.Collision.CollisionHandlers
{
	public class ProjectileBorderCollisionHandler : ICollisionHandler
	{
        private readonly IProjectile projectile;

		public ProjectileBorderCollisionHandler(IProjectile projectile, Rectangle border)
		{
            this.projectile = projectile;
		}

        public void HandleCollision()
        {
            projectile.Collide();
        }
    }
}

