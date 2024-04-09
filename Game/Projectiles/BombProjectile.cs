using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Projectiles
{
    public class BombProjectile : IProjectile
    {
        public Vector2 Position { get => position; }
        public bool IsActive { get => isActive; }
        public Direction MovingDirection { get => direction; }
        public Rectangle HitBox { get => hitBox; }

        private ISprite sprite;
        private bool isActive = true;
        private readonly Vector2 position;
        private Rectangle hitBox = new();
        private readonly int bombSpawnOffset = 48;

        private int detonationCountdown = 64;
        private int explosionTime = 0;
        private bool detonated = false;
        private readonly Direction direction;

        public BombProjectile(Vector2 spawnerPosition, Direction direction)
        {
            sprite = SpriteFactory.CreateBombSprite();
            this.direction = direction;
            switch (direction)
            {
                case Direction.North:
                    position = new(spawnerPosition.X, spawnerPosition.Y - bombSpawnOffset);
                    break;
                case Direction.South:
                    position = new(spawnerPosition.X, spawnerPosition.Y + bombSpawnOffset);
                    break;
                case Direction.East:
                    position = new(spawnerPosition.X + bombSpawnOffset, spawnerPosition.Y);
                    break;
                case Direction.West:
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
            if (detonated)
            {
                DrawExplosion();
                return;
            }
            sprite.Draw(position.X, position.Y, Color.White);
        }

        public void Collide() { }

        private void DetonateBomb()
        {
            if (!detonated)
            {
                int height = sprite.DestinationRectangle.Height * 5 / 2;
                int width = sprite.DestinationRectangle.Width * 3;
                hitBox = new Rectangle(
                    (int)position.X - sprite.DestinationRectangle.Width,
                    (int)position.Y - sprite.DestinationRectangle.Height * 3 / 4,
                    width, height);

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

        private void DrawExplosion()
        {
            Color smokeColor = Color.White;
            if (detonationCountdown % 2 == 0)
            {
                smokeColor = Color.Transparent;
            }

            int height = sprite.DestinationRectangle.Height * 3 / 4;
            int width = sprite.DestinationRectangle.Width;

            sprite.Draw(position.X + width / 2, position.Y - height, smokeColor);
            sprite.Draw(position.X - width / 2, position.Y - height, smokeColor);

            sprite.Draw(position.X - width, position.Y, smokeColor);
            sprite.Draw(position.X, position.Y, Color.White);
            sprite.Draw(position.X + width, position.Y, smokeColor);

            sprite.Draw(position.X + width / 2, position.Y + height, smokeColor);
            sprite.Draw(position.X - width / 2, position.Y + height, smokeColor);
        }
    }
}

