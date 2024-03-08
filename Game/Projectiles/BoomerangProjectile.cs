using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Projectiles
{
	public class BoomerangProjectile : IProjectile
	{
		public Vector2 Position { get => position; }
		public bool IsActive { get => isActive; }
        public Rectangle HitBox
        {
            get
            {
                Rectangle destRect = sprite.DestinationRectangle;
                Rectangle resized = new(destRect.X, destRect.Y, destRect.Width / 2, destRect.Height / 2);
                return Utils.CentralizeRectangle(destRect.X, destRect.Y, resized);
            }
        }

        private readonly ISprite sprite;
		private Vector2 position;
		private Vector2 startingPosition;
		private bool isActive = true;
        private int timeLeft = 0;
		private readonly float maxTravelDistance = 20f;
		private readonly CardinalDirections direction;

		public BoomerangProjectile(Vector2 entityPosition, CardinalDirections direction)
		{
			startingPosition = entityPosition;
            position = startingPosition;
			sprite = SpriteFactory.CreateWoodenBoomerangSprite();
			this.direction = direction;
		}

		public void Update()
		{
			float changeX = 0f;
			float changeY = 0f;
			switch (direction)
			{
				case CardinalDirections.North:
					changeY = -1f * CurrentMovementSpeed();
                    break;
				case CardinalDirections.South:
                    changeY = CurrentMovementSpeed();
                    break;
				case CardinalDirections.East:
					changeX = CurrentMovementSpeed();
					break;
				case CardinalDirections.West:
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

