using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Projectiles
{
	public class BoomerangProjectile : IProjectile
	{
		public Vector2 Position { get => position; }
		public bool IsActive { get => isActive; }
        public Direction MovingDirection { get => direction; }
        public Rectangle HitBox
        {
            get
            {
                Rectangle destRect = sprite.DestinationRectangle;
                Rectangle resized = new((int)Position.X, (int)Position.Y, destRect.Width / 2, destRect.Height / 2);
                return Utils.CentralizeRectangle(destRect.X, destRect.Y, resized);
            }
        }

        private readonly ISprite sprite;
		private readonly ISprite collideEffect;
		private Vector2 collidePosition;
		private int collideSpriteDuration = 3;
		private bool collided = false;
		private Vector2 position;
		private Vector2 startingPosition;
		private bool isActive = true;
        private bool returning = false;
        private readonly float acceleration = 0.02f;
        private float speed;
        private int timer = 0;
        private Direction direction;

		public BoomerangProjectile(Vector2 entityPosition, Direction direction)
		{
			startingPosition = entityPosition;
            position = startingPosition;
			sprite = SpriteFactory.CreateWoodenBoomerangSprite();
			collideEffect = SpriteFactory.CreateArrowProjectileHitSprite();

            this.direction = direction;
			speed = 10;
        }

		public void Update()
		{			
			sprite.Update();
			Move();

			if (collided)
			{
				collideSpriteDuration--;
				collided = collideSpriteDuration < 0;
			}

			if (returning && Vector2.Distance(position, startingPosition) < 10f)
			{
				isActive = false;
			}

			timer++;
		}

		public void Draw()
		{
			sprite.Draw(Position.X, Position.Y, Color.White);
			if (collided && collideSpriteDuration > 0)
			{
				collideEffect.Draw(collidePosition.X, collidePosition.Y, Color.White);
			}
		}

		public void Collide()
		{
			if (!returning)
			{
				collided = true;
				returning = true;
                direction = Utils.OppositeDirection(direction);
                speed *= -1;
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