using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Projectiles
{
	public class FireBallProjectile : IProjectile
    {
        public Vector2 Position { get => position; }
        public bool IsActive { get => isActive; }
        public Direction MovingDirection { get => direction; }
        public Rectangle HitBox { get => new(position.ToPoint(), sprite.DestinationRectangle.Size); }

        private readonly ISprite sprite;
        private readonly float maxDistanceTravel = Constants.BlockSize;
        private int idletime = GameConstants.FireBallProjectileInitialIdleTime;
        private readonly float speed = GameConstants.FireBallProjectileSpeed;
        private bool isActive = true;
        private Vector2 position;
        private Vector2 startingPosition;
        private readonly Direction direction;

        public FireBallProjectile(Vector2 startingPosition, Direction direction)
		{
            this.direction = direction;
            this.startingPosition = startingPosition;
            switch (direction)
            {
                case Direction.North:
                    this.startingPosition = new(startingPosition.X, startingPosition.Y - Constants.BlockSize);
                    break;
                case Direction.South:
                    this.startingPosition = new(startingPosition.X, startingPosition.Y + Constants.BlockSize);
                    break;
                case Direction.East:
                    this.startingPosition = new(startingPosition.X + Constants.BlockSize, startingPosition.Y);
                    break;
                case Direction.West:
                    this.startingPosition = new(startingPosition.X - Constants.BlockSize, startingPosition.Y);
                    break;
            }
            position = this.startingPosition;
            sprite = SpriteFactory.CreateFireSprite();
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
                idletime--;
            }

            if (idletime < 0)
            {
                isActive = false;
            }
            sprite.Update();
        }

        public void Draw()
        {
            sprite.Draw(Position.X, Position.Y, Color.White);
        }

        public void Collide() { }

        private void Move()
        {
            float changeX = GameConstants.FireBallProjectileInitialChange;
            float changeY = GameConstants.FireBallProjectileInitialChange;
            switch (direction)
            {
                case Direction.North:
                    changeY = -1f * speed;
                    break;
                case Direction.South:
                    changeY = speed;
                    break;
                case Direction.East:
                    changeX = speed;
                    break;
                case Direction.West:
                    changeX = -1f * speed;
                    break;
            }

            position = new(position.X + changeX, position.Y + changeY);
        }
    }
}
