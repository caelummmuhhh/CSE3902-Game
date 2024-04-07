using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Projectiles
{
    public class SwordBeamProjectile : IProjectile
    {
        public Vector2 Position { get => position; }
        public bool IsActive { get => isActive; }
        public Direction MovingDirection { get => direction; }
        public Rectangle HitBox
        {
            get
            {
                Rectangle destRect = sprite.DestinationRectangle;
                Rectangle resized = new(destRect.X, destRect.Y, destRect.Width / 2, destRect.Height / 2);
                return Utils.CentralizeRectangle((int)position.X, (int)position.Y, resized);
            }
        }

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
                case Direction.North:
                    sprite = SpriteFactory.CreateSwordBeamUpProjectileSprite();
                    break;
                case Direction.South:
                    sprite = SpriteFactory.CreateSwordBeamDownProjectileSprite();
                    break;
                case Direction.East:
                    sprite = SpriteFactory.CreateSwordBeamRightProjectileSprite();
                    break;
                case Direction.West:
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

