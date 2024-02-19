using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Players
{
	public class Player
	{
		public ISprite Sprite;
		public Vector2 Position;
        public float VerticalSpeed = 5f;
		public float HorizontalSpeed = 4f;

		private readonly Game game;
		private bool movingLeft;
		private bool movingDown;

		public bool VerticalMotionOn;
		public bool HorizontalMotionOn;

        public Player(Vector2 position, ISprite sprite, Game game)
		{
			Position = position;
			Sprite = sprite;
			this.game = game;

			movingLeft = false;
			movingDown = false;
			VerticalMotionOn = false;
			HorizontalMotionOn = false;
        }

		public void Update()
		{
			Sprite.Update();

			if (VerticalMotionOn) { InfiniteFall(); }
			if (HorizontalMotionOn) { HorizontalBounce(); }
		}

		public void Draw()
		{
			Sprite.Draw(Position.X, Position.Y, Color.White, game.GraphicsDevice.Viewport.Width - 27, game.GraphicsDevice.Viewport.Height + 14);
		}

		public void MoveUp()
		{
			Position = new Vector2(Position.X, Position.Y - VerticalSpeed);
		}

		public void MoveDown()
		{
            Position = new Vector2(Position.X, Position.Y + VerticalSpeed);
        }

		public void MoveLeft()
        {
            Position = new Vector2(Position.X - HorizontalSpeed, Position.Y);
        }

        public void MoveRight()
        {
            Position = new Vector2(Position.X + HorizontalSpeed, Position.Y);
        }

		public void HorizontalBounce()
		{
            if (Position.X < 27)
            {
                movingLeft = false;
            }
            else if (Position.X > game.GraphicsDevice.Viewport.Width - 27)
            {
                movingLeft = true;
            }

            if (movingLeft) { MoveLeft(); }
            else { MoveRight(); }
		}

        public void InfiniteFall()
		{
			movingDown = true;
            MoveDown();
            if (Position.Y > game.GraphicsDevice.Viewport.Height + 14)
            {
                Position = new Vector2(Position.X, 0);
            }
        }
    }
}

