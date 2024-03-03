using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
    public class KeeseFlyingState : IEnemyState
    {
        private readonly IEnemy entity;
        private readonly Random random;
        private CardinalAndOrdinalDirection direction;

        private int flightDurationTimer;
        private int directionChangeTimer;

        public KeeseFlyingState(IEnemy enemy)
        {
            entity = enemy;
            entity.Sprite = SpriteFactory.CreateKeeseFlightSprite();
            random = new();

            flightDurationTimer = random.Next(1, 64) * 16;
            ChangeDirection();
        }

        public void Update()
        {
            if (flightDurationTimer <= 0)
            {
                entity.State = new KeeseLandingState(entity);
            }
            if (directionChangeTimer <= 0)
            {
                ChangeDirection();
            }

            directionChangeTimer--;
            flightDurationTimer--;
        }

        public void Draw() => entity.Draw();

        public void Move()
        {
            float x = entity.Position.X;
            float y = entity.Position.Y;

            entity.Position = direction switch
            {
                CardinalAndOrdinalDirection.North => new Vector2(x, y - KeeseEnemy.Speed),
                CardinalAndOrdinalDirection.NorthEast => new Vector2(x + KeeseEnemy.Speed, y - KeeseEnemy.Speed),
                CardinalAndOrdinalDirection.East => new Vector2(x + KeeseEnemy.Speed, y),
                CardinalAndOrdinalDirection.SouthEast => new Vector2(x + KeeseEnemy.Speed, y + KeeseEnemy.Speed),
                CardinalAndOrdinalDirection.South => new Vector2(x, y + KeeseEnemy.Speed),
                CardinalAndOrdinalDirection.SouthWest => new Vector2(x - KeeseEnemy.Speed, y + KeeseEnemy.Speed),
                CardinalAndOrdinalDirection.West => new Vector2(x - KeeseEnemy.Speed, y),
                CardinalAndOrdinalDirection.NorthWest => new Vector2(x - KeeseEnemy.Speed, y - KeeseEnemy.Speed),
                _ => new Vector2(x, y)
            };
        }

        private void ChangeDirection()
        {
            int randDirectionInt = random.Next(0, Enum.GetNames(direction.GetType()).Length);
            direction = (CardinalAndOrdinalDirection)randDirectionInt;
            directionChangeTimer = random.Next(1, 16) * 4;
        }
    }
}
