using System;
using MainGame.SpriteHandlers;
using Microsoft.Xna.Framework;

namespace MainGame.Enemies
{
    public class KeeseFlyingState : IEnemyState
    {
        private readonly KeeseEnemy entity;
        private readonly Random random;

        private int flightDurationTimer;
        private int directionChangeTimer;

        public KeeseFlyingState(KeeseEnemy enemy)
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

        public void Draw() => entity.Sprite.Draw(entity.Position.X, entity.Position.Y, entity.SpriteColor);

        public void Move()
        {
            if (flightDurationTimer % entity.MovementCoolDownFrame == 0)
            {
                entity.Position = Utils.DirectionalMove(entity.Position, entity.MovingDirection, entity.MovementSpeed);
            }
        }

        public void ChangeDirection()
        {
            entity.ChangeDirection();
            directionChangeTimer = random.Next(1, 16) * 4;
        }
    }
}
