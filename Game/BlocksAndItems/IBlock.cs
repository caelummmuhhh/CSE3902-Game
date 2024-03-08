using Microsoft.Xna.Framework;

namespace MainGame.BlocksAndItems
{
	public interface IBlock
	{
		public Rectangle HitBox { get; }
		public void Update();
		public void Draw();
	}
}

