using MainGame.Players;
using MainGame.Projectiles;

namespace MainGame.Collision.CollisionHandlers
{
    public class PlayerPlayerProjectileCollisionHandler : ICollisionHandler
    {
        private readonly IPlayer player;
        private readonly IProjectile projectile;

        public PlayerPlayerProjectileCollisionHandler(IPlayer player, IProjectile projectile)
        {
            this.player = player;
            this.projectile = projectile;
        }

        public void HandleCollision()
        {
            if (projectile is FireBallProjectile)
            {
                Direction playerSideDamaged = Utils.GetCardinalDirectionFrom(player.Position, projectile.Position);
                player.TakeDamage(playerSideDamaged);
            }
        }
    }
}

