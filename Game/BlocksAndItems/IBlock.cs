using Microsoft.Xna.Framework;

namespace MainGame.BlocksAndItems
{
	public interface IBlock
	{
		public Vector2 Position { get; }
		public Rectangle HitBox { get; }
		public void Update();
		public void Draw();
	}
}

