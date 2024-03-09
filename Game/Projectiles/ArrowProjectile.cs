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
		private readonly CardinalDirections direction;


		public ArrowProjectile(Vector2 startingPosition, CardinalDirections direction)
		{
			this.direction = direction;
            this.startingPosition = startingPosition;
            position = startingPosition;
            switch (direction)
            {
                case CardinalDirections.North:
                    sprite = SpriteFactory.CreateArrowUpProjectileSprite();
                    break;
                case CardinalDirections.South:
                    sprite = SpriteFactory.CreateArrowDownProjectileSprite();
                    break;
                case CardinalDirections.East:
                    sprite = SpriteFactory.CreateArrowRightProjectileSprite();
                    break;
                case CardinalDirections.West:
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
            sprite.Draw(Position.X, Position.Y, Color.White);
        }

        private void Move()
        {
            float changeX = 0f;
            float changeY = 0f;
            switch (direction)
            {
                case CardinalDirections.North:
                    changeY = -1f * speed;
                    break;
                case CardinalDirections.South:
                    changeY = speed;
                    break;
                case CardinalDirections.East:
                    changeX = speed;
                    break;
                case CardinalDirections.West:
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

