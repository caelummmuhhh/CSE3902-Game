using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Blocks
{
	public class Block : IBlock
	{
        public Vector2 Position { get; set; }
        public Rectangle HitBox
		{
			get
			{
                if (collidable)
				{
					return sprite.DestinationRectangle;
                }
				return new();
            }
		}

        private readonly ISprite sprite;
        private readonly bool collidable;

        public Block(Vector2 position, ISprite sprite, bool collidable = true)
		{
			Position = position;
			this.sprite = sprite;
			this.collidable = collidable;
        }

		public void Update()
		{
			sprite.Update();
		}

		public void Draw()
		{
			sprite.Draw(Position.X, Position.Y, Color.White);
		}

    }
}
