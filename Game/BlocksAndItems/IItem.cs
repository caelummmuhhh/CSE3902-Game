using Microsoft.Xna.Framework;

namespace MainGame.BlocksAndItems
{
	public interface IItem
	{
        public Rectangle HitBox { get; }
        public void Update();
        public void Draw();
    }
}

