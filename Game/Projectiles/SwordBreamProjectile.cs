using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Projectiles
{
    public class SwordBeamProjectile : IProjectile
    {
        public Vector2 Position { get => position; }
        public bool IsActive { get => isActive; }

        private readonly ISprite sprite;
        private readonly float maxDistanceTravel = 500f;
        private readonly float speed = 20f;
        private bool isActive = true;
        private Vector2 position;
        private Vector2 startingPosition;
        private readonly Direction direction;


        public SwordBeamProjectile(Vector2 startingPosition, Direction direction)
        {
            this.direction = direction;
            this.startingPosition = startingPosition;
            position = startingPosition;
            switch (direction)
            {
                case Direction.Up:
                    sprite = SpriteFactory.CreateSwordBeamUpProjectileSprite();
                    break;
                case Direction.Down:
                    sprite = SpriteFactory.CreateSwordBeamDownProjectileSprite();
                    break;
                case Direction.Right:
                    sprite = SpriteFactory.CreateSwordBeamRightProjectileSprite();
                    break;
                case Direction.Left:
                    sprite = SpriteFactory.CreateSwordBeamLeftProjectileSprite();
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
                isActive = false;
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

