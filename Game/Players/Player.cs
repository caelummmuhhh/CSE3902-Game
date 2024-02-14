using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Commands;
using System.Diagnostics;

namespace MainGame.Players
{
	public enum MovementDirection
	{
		UP, DOWN, LEFT, RIGHT, NONE
	}

	public class Player
	{
		public ISprite Sprite;
		public Vector2 Position;
        public float VerticalSpeed = 5f;
		public float HorizontalSpeed = 4f;

		private readonly Game game;
        public bool usingSword;
        public MovementDirection direction;
		
        public Player(Vector2 position, ISprite sprite, Game game)
		{
			Position = position;
			Sprite = sprite;
			this.game = game;

			direction = MovementDirection.NONE; 
            usingSword = false;
        }

		public void Update()
		{
			if (direction != MovementDirection.NONE) // If link isn't currently moving dont update sprite
			{
                Sprite.Update();
            }
			switch (direction)
			{
				case MovementDirection.UP: MoveUp(); break;
				case MovementDirection.DOWN: MoveDown(); break;
				case MovementDirection.LEFT: MoveLeft(); break;
				case MovementDirection.RIGHT: MoveRight(); break;
				default: break;
			}
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

