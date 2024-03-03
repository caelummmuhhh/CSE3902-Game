using System;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
    public class KeeseFlyingState : IEnemyState
    {
        private readonly GenericEnemy entity;
        private readonly Random random;
        private CardinalAndOrdinalDirection moveDirection;

        private int flightDurationTimer;
        private int directionChangeTimer;

        public KeeseFlyingState(GenericEnemy enemy)
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
            if (flightDurationTimer % entity.MovementCoolDownFrame == 0)
            {
                entity.Position = EnemyUtils.DirectionalMove(entity.Position, moveDirection, entity.MovementSpeed);
            }
        }

        private void ChangeDirection()
        {
            moveDirection = EnemyUtils.GetRandomCardinalAndOrdinalDirection();
            directionChangeTimer = random.Next(1, 16) * 4;
        }
    }
}
