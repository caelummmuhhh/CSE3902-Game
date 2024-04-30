using MainGame.Audio;
using MainGame.Enemies;
using MainGame.Projectiles;

namespace MainGame.Collision.CollisionHandlers
{
	public class EnemyPlayerProjectileCollisionHandler : ICollisionHandler
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
            if (enemy is AquamentusEnemy && projectile is PlayerBoomerangProjectile)
            {
                AudioManager.PlaySFX("Projectile_Deflect", 0);
                return;
            } 
            else if (!(enemy is GelEnemy || enemy is KeeseEnemy) && projectile is PlayerBoomerangProjectile)
            {
                enemy.Stun(100);
                return;
            }

            Direction playerSideDamaged = Utils.GetCardinalDirectionFrom(enemy.Position, projectile.Position);
            enemy.TakeDamage(playerSideDamaged, 2);
        }
    }
}

