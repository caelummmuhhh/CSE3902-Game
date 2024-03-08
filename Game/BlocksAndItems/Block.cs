using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.BlocksAndItems
{
	public class Block : IBlock
	{
		public ISprite Sprite;
		public Vector2 Position;
		public Rectangle HitBox { get => Sprite.DestinationRectangle; }

        public Block(Vector2 position, ISprite sprite)
		{
			Position = position;
			Sprite = sprite;
        }

		public void Update()
		{
			Sprite.Update();
		}

		public void Draw()
		{
			Sprite.Draw(Position.X, Position.Y, Color.White);
		}

    }
}
