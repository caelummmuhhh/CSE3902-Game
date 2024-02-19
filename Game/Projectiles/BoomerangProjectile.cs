using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Projectiles
{
	public class BoomerangProjectile : IProjectile
	{
		public Vector2 Position { get => position; }
		public int Duration { get => existenceDuration; }
		public bool IsActive { get => isActive; }

		private ISprite sprite;
		private Vector2 position;
		private Vector2 startingPosition;
		private int existenceDuration;
		private bool isActive = true;
        private int timeLeft = 0;
		private float speed = 2f;
		private float maxTravelDistance = 20f;
		private Direction direction;

		public BoomerangProjectile(Vector2 startingPosition, Direction direction)
		{
			this.startingPosition = startingPosition;
            position = startingPosition;
			sprite = SpriteFactory.CreateWoodenBoomerangSprite();
			this.direction = direction;
			existenceDuration = 100;
		}

		public void Update()
		{
			float changeX = 0f;
			float changeY = 0f;
			switch (direction)
			{
				case Direction.Up:
					changeY = -1f * CurrentMovementSpeed();
                    break;
				case Direction.Down:
                    changeY = CurrentMovementSpeed();
                    break;
				case Direction.Right:
					changeX = CurrentMovementSpeed();
					break;
				case Direction.Left:
					changeX = -1f * CurrentMovementSpeed();
					break;
			}
			
			timeLeft++;
			sprite.Update();
			position = new(position.X + changeX, position.Y + changeY);

			if (position == startingPosition)
			{
				isActive = false;
			}
		}

		public void Draw()
		{
			sprite.Draw(Position.X, Position.Y, Color.White);
		}
		
		private float CurrentMovementSpeed()
		{
			// Movement is based on the d/dx of a concave down parabola (aka a downward slope)
			// f(x) = -x + maxTravelDistance
			return -1 * timeLeft + maxTravelDistance;
		}
	}
}

