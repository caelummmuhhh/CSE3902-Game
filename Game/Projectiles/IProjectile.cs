using Microsoft.Xna.Framework;

namespace MainGame.Projectiles
{
	public interface IProjectile
	{
		public Vector2 Position { get; }
		public Rectangle HitBox { get; }
		public Direction MovingDirection { get; }
		public bool IsActive { get; }
		public void Update();
		public void Draw();
	}
}

