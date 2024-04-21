using System;
using Microsoft.Xna.Framework;
using MainGame.Players;

namespace MainGame.Projectiles
{
	public static class ProjectileFactory
	{
		public static IProjectile GetArrowProjectile(Vector2 position, Direction direction)
            => new ArrowProjectile(position, direction);

        public static IProjectile GetBombProjectile(Vector2 position, Direction direction)
            => new BombProjectile(position, direction);

        public static IProjectile GetBoomerangProjectile(Vector2 position, Direction direction)
            => new BoomerangProjectile(position, direction);

        public static IProjectile GetFireProjectile(Vector2 position, Direction direction)
            => new FireBallProjectile(position, direction);

        public static IProjectile GetPlayerBoomerangProjectile(IPlayer player, Direction direction)
            => new PlayerBoomerangProjectile(player, direction);

        public static IProjectile GetSwordBeamProjectile(Vector2 position, Direction direction)
            => new SwordBeamProjectile(position, direction);
    }
}

