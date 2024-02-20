using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Projectiles
{
    public class BombProjectile : IProjectile
    {
        public Vector2 Position { get => position; }
        public bool IsActive { get => isActive; }

        private ISprite sprite;
        private bool isActive = true;
        private readonly Vector2 position;
        private readonly int bombSpawnOffset = 50;

        private int detonationCountdown = 48;
        private int explosionTime = 0;
        private bool detonated = false;

        public BombProjectile(Vector2 spawnerPosition, Direction direction)
        {
            sprite = SpriteFactory.CreateBombSprite();

            switch (direction)
            {
                case Direction.Up:
                    position = new(spawnerPosition.X, spawnerPosition.Y - bombSpawnOffset);
                    break;
                case Direction.Down:
                    position = new(spawnerPosition.X, spawnerPosition.Y + bombSpawnOffset);
                    break;
                case Direction.Right:
                    position = new(spawnerPosition.X + bombSpawnOffset, spawnerPosition.Y);
                    break;
                case Direction.Left:
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
            sprite.Draw(position.X, position.Y, Color.White, 0, 0);
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

