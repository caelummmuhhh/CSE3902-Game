using MainGame.Enemies;
using MainGame.Projectiles;

namespace MainGame.Collision.CollisionHandlers
{
	public class EnemyPlayerProjectileCollisionHandler: ICollisionHandler
    {
        private readonly IEnemy enemy;
        private readonly IProjectile projectile;

        public EnemyPlayerProjectileCollisionHandler(IEnemy enemy, IProjectile projectile)
		{
            this.enemy = enemy;
            this.projectile = projectile;
		}

        public void HandleCollision()
        {
            projectile.Collide();
            if ((enemy is GoriyaEnemy || enemy is StalfosEnemy) && projectile is PlayerBoomerangProjectile)
            {
                enemy.Stun(100);
                return;
            }

            Direction playerSideDamaged = Utils.GetCardinalDirectionFrom(enemy.Position, projectile.Position);
            enemy.TakeDamage(playerSideDamaged);
        }
    }
}

