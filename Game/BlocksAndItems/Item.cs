using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Items
{
	public class Item 
	{
		public ISprite Sprite;
		public Vector2 Position;
		private readonly Game game;

        public Item(Vector2 position, ISprite sprite, Game game)
		{
			Position = position;
			Sprite = sprite;
			this.game = game;

        }

		public void Update()
		{
			Sprite.Update();

		}

		public void Draw()
		{
			Sprite.Draw(Position.X, Position.Y, Color.White, TODO, TODO);
		}

    }
}
