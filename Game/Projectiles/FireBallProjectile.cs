using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Projectiles
{
	public class FireBallProjectile : IProjectile
    {
        public Vector2 Position { get => position; }
        public bool IsActive { get => isActive; }

        private readonly ISprite sprite;
        private readonly float maxDistanceTravel = 200f;
        private int idletime = 20;
        private readonly float speed = 10f;
        private bool isActive = true;
        private Vector2 position;
        private Vector2 startingPosition;
        private readonly Direction direction;

        public FireBallProjectile(Vector2 startingPosition, Direction direction)
		{
            this.direction = direction;
            this.startingPosition = startingPosition;
            position = startingPosition;
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
            sprite.Draw(Position.X, Position.Y, Color.White, 0, 0);
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
    }
}

