using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Projectiles
{
	public class ArrowProjectile : IProjectile
	{
        public Vector2 Position { get => position; }
        public bool IsActive { get => isActive; }

		private ISprite sprite;
		private readonly float maxDistanceTravel = 250f;
        private readonly float speed = 15f;
        private int collisionTimer = 3;
        private bool isActive = true;
        private Vector2 position;
        private Vector2 startingPosition;
		private readonly Direction direction;


		public ArrowProjectile(Vector2 startingPosition, Direction direction)
		{
			this.direction = direction;
            this.startingPosition = startingPosition;
            position = startingPosition;
            switch (direction)
            {
                case Direction.Up:
                    sprite = SpriteFactory.CreateArrowUpProjectileSprite();
                    break;
                case Direction.Down:
                    sprite = SpriteFactory.CreateArrowDownProjectileSprite();
                    break;
                case Direction.Right:
                    sprite = SpriteFactory.CreateArrowRightProjectileSprite();
                    break;
                case Direction.Left:
                    sprite = SpriteFactory.CreateArrowLeftProjectileSprite();
                    break;
            }

        }

        public void Update()
        {
            float distanceTravelled = Math.Abs(position.X - startingPosition.X) + Math.Abs(position.Y - startingPosition.Y);
            if (distanceTravelled < maxDistanceTravel)
            {
                Move();
            }
            else
            {
                Collide();
            }

            sprite.Update();
        }

        public void Draw()
        {
            sprite.Draw(Position.X, Position.Y, Color.White, maxDistanceTravel, maxDistanceTravel);
        }

        private void Move()
        {
            float changeX = 0f;
            float changeY = 0f;
            switch (direction)
            {
                case Direction.Up:
                    changeY = -1f * speed;
                    break;
                case Direction.Down:
                    changeY = speed;
                    break;
                case Direction.Right:
                    changeX = speed;
                    break;
                case Direction.Left:
                    changeX = -1f * speed;
                    break;
            }

            position = new(position.X + changeX, position.Y + changeY);
        }

        private void Collide()
        {
            if (collisionTimer < 0)
            {
                isActive = false;
                return;
            }
            sprite = SpriteFactory.CreateArrowProjectileHitSprite();
            collisionTimer--;
        }
    }
}

