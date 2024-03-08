using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Projectiles
{
    public class BombProjectile : IProjectile
    {
        public Vector2 Position { get => position; }
        public bool IsActive { get => isActive; }
        public Rectangle HitBox
        {
            get
            {
                Rectangle destRect = sprite.DestinationRectangle;
                Rectangle resized = new(destRect.X, destRect.Y, destRect.Width * 2, destRect.Height * 2);
                return Utils.CentralizeRectangle(destRect.X, destRect.Y, resized);
            }
        }

        private ISprite sprite;
        private bool isActive = true;
        private readonly Vector2 position;
        private readonly int bombSpawnOffset = 50;

        private int detonationCountdown = 48;
        private int explosionTime = 0;
        private bool detonated = false;

        public BombProjectile(Vector2 spawnerPosition, CardinalDirections direction)
        {
            sprite = SpriteFactory.CreateBombSprite();

            switch (direction)
            {
                case CardinalDirections.North:
                    position = new(spawnerPosition.X, spawnerPosition.Y - bombSpawnOffset);
                    break;
                case CardinalDirections.South:
                    position = new(spawnerPosition.X, spawnerPosition.Y + bombSpawnOffset);
                    break;
                case CardinalDirections.East:
                    position = new(spawnerPosition.X + bombSpawnOffset, spawnerPosition.Y);
                    break;
                case CardinalDirections.West:
                    position = new(spawnerPosition.X - bombSpawnOffset, spawnerPosition.Y);
                    break;
            }
        }

        public void Update()
        {
            if (detonationCountdown <= 0)
            {
                DetonateBomb();
            }
            detonationCountdown--;
            sprite.Update();
        }

        public void Draw()
        {
            sprite.Draw(position.X, position.Y, Color.White);
        }

        private void DetonateBomb()
        {
            if (!detonated)
            {
                AnimatedSprite explodingBombSprite = (AnimatedSprite)SpriteFactory.CreateBombExplodingSprite();
                sprite = explodingBombSprite;
                detonated = true;
                explosionTime = explodingBombSprite.AnimationFrameDuration;
            }
            explosionTime--;

            if (explosionTime <= 0)
            {
                isActive = false;
            }
        }
    }
}

