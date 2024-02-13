using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Commands;
using System.Diagnostics;

namespace MainGame.Players
{
	public class Player
	{
		public ISprite Sprite;
		public Vector2 Position;
        public float VerticalSpeed = 5f;
		public float HorizontalSpeed = 4f;

		private readonly Game game;
		public bool movingUp;
		public bool movingDown;
		public bool movingLeft;
		public bool movingRight;
		public bool usingSword;

        public Player(Vector2 position, ISprite sprite, Game game)
		{
			Position = position;
			Sprite = sprite;
			this.game = game;

			movingLeft = false;
			movingRight = false;
			movingUp = false;
			movingDown = false;
			usingSword = false;
        }

		public void Update()
		{
			if (movingLeft || movingDown || movingRight || movingUp) // If link isn't currently moving dont update sprite
			{
                Sprite.Update();
            }
			if(movingLeft) { MoveLeft(); }
			if(movingRight) { MoveRight(); }
			if(movingUp) { MoveUp(); }
			if(movingDown) { MoveDown(); }
		}

		public void Draw()
		{
			Sprite.Draw(Position.X, Position.Y, Color.White);
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
    }
}

