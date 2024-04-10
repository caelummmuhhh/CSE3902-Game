using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Projectiles
{
	public class BoomerangProjectile : IProjectile
	{
		public Vector2 Position { get => position; }
		public bool IsActive { get => isActive; }
        public Direction MovingDirection { get => direction; }
		public bool Returning { get => returning;  }
        public Rectangle HitBox
        {
            get
            {
                Rectangle destRect = sprite.DestinationRectangle;
                Rectangle resized = new((int)Position.X, (int)Position.Y, destRect.Width / GameConstants.BoomerangProjectileHitBoxDivisor, destRect.Height / GameConstants.BoomerangProjectileHitBoxDivisor);
                return Utils.CentralizeRectangle(resized.X, resized.Y, resized);
            }
        }

        private readonly ISprite sprite;
		private readonly ISprite collideEffect;
		private Vector2 collidePosition;
		private int collideSpriteDuration = GameConstants.BoomerangProjectileCollideSpriteDuration;
		private bool showCollideSprite = GameConstants.BoomerangProjectileInitialShowCollideSprite;
		private Vector2 position;
		private Vector2 startingPosition;
		private bool isActive = GameConstants.BoomerangProjectileInitialIsActive;
        private bool returning = GameConstants.BoomerangProjectileInitialReturning;
        private readonly float acceleration = GameConstants.BoomerangProjectileAcceleration;
        private float speed;
        private int timer = GameConstants.BoomerangProjectileInitialTimer;
        private Direction direction;

		public BoomerangProjectile(Vector2 entityPosition, Direction direction)
		{
			startingPosition = entityPosition;
            position = startingPosition;
			sprite = SpriteFactory.CreateWoodenBoomerangSprite();
			collideEffect = SpriteFactory.CreateArrowProjectileHitSprite();

            this.direction = direction;
			speed = GameConstants.BoomerangProjectileInitialSpeed;
        }

		public void Update()
		{			
			sprite.Update();
			Move();

			if (showCollideSprite)
			{
				collideSpriteDuration--;
				showCollideSprite = collideSpriteDuration > 0;
			}

			if (returning && Vector2.Distance(position, startingPosition) < GameConstants.BoomerangProjectileReturnDistance)
			{
				isActive = false;
			}

			timer++;
		}

		public void Draw()
		{
			sprite.Draw(Position.X, Position.Y, Color.White);
			if (showCollideSprite && collideSpriteDuration > 0)
			{
				collideEffect.Draw(collidePosition.X, collidePosition.Y, Color.White);
			}
		}

		public void Collide()
		{
			if (!returning)
			{
				showCollideSprite = true;
				returning = true;
                direction = Utils.OppositeDirection(direction);
				collidePosition = position;
            }
		}

		private void Move()
		{
			if (!returning)
			{
				speed -= acceleration * timer;
                if (speed < 0)
                {
                    returning = true;
                    direction = Utils.OppositeDirection(direction);
                }
            }
            else
			{
				speed += acceleration * timer;
            }
            position = Utils.DirectionalMove(position, direction, speed);
        }
	}
}