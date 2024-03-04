using Microsoft.Xna.Framework;

namespace MainGame.Projectiles
{
	public interface IProjectile
	{
		public Vector2 Position { get; }
		public bool IsActive { get; }
		public void Update();
		public void Draw();
	}
}

