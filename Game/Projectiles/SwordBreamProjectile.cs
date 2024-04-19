using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Particles;

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
                if (exploding)
                {
                    return new();
                }
                Rectangle destRect = sprite.DestinationRectangle;
                Rectangle resized = new(destRect.X, destRect.Y, destRect.Width / 2, destRect.Height / 2);
                return Utils.CentralizeRectangle((int)position.X, (int)position.Y, resized);
            }
        }

        private readonly ISprite sprite;
        private readonly float maxDistanceTravel = 1000f;
        private readonly float speed = 10f;
        private readonly Vector2 directionVector;
        private bool exploding = false;
        private IParticle explodingParticles; 
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
                    directionVector = new(0, -1);
                    break;
                case Direction.South:
                    sprite = SpriteFactory.CreateSwordBeamDownProjectileSprite();
                    directionVector = new(0, 1);
                    break;
                case Direction.East:
                    sprite = SpriteFactory.CreateSwordBeamRightProjectileSprite();
                    directionVector = new(1, 0);
                    break;
                case Direction.West:
                    sprite = SpriteFactory.CreateSwordBeamLeftProjectileSprite();
                    directionVector = new(-1, 0);
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
            explodingParticles?.Update();
            isActive = explodingParticles is null || explodingParticles.IsActive;
        }

        public void Draw()
        {
            if (explodingParticles is null)
            {
                sprite.Draw(Position.X, Position.Y, Color.White);
                return;
            }
            explodingParticles?.Draw();
        }

        private void Move()
        {
            position = new(position.X + directionVector.X * speed, position.Y + directionVector.Y * speed);
        }

        public void Collide()
        {
            if (!exploding)
            {
                exploding = true;
                explodingParticles = new SwordBeamExplodingParticles(position);
            }
        }
    }
}
