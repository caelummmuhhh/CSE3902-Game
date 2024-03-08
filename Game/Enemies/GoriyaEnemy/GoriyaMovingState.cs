using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
    public class GoriyaMovingState : IEnemyState
    {
        private readonly GoriyaEnemy entity;
        private readonly int maxMoveDuration = 31;
        private int moveDuration;
        private CardinalDirections direction;

        public GoriyaMovingState(GoriyaEnemy goriya)
        {
            entity = goriya;
            moveDuration = maxMoveDuration;
            direction = EnemyUtils.GetRandomCardinalDirection();
            GetSprite();
        }

        public void Update()
        {
            if (moveDuration > 0)
            {
                moveDuration--;
                return;
            }
            if (!AttemptBoomerang())
            {
                direction = EnemyUtils.GetRandomCardinalDirection();
                moveDuration = maxMoveDuration;
                GetSprite();
            }
        }

        public void Draw() => entity.Sprite.Draw(entity.Position.X, entity.Position.Y, Color.White);

        public void Move()
        {
            if (moveDuration % entity.MovementCoolDownFrame == 0)
            {
                entity.Position = EnemyUtils.DirectionalMove(entity.Position, direction, entity.MovementSpeed);
            }
        }

        private bool AttemptBoomerang()
        {
            Random random = new();
            if (random.Next(15) == 0)
            {
                entity.State = new GoriyaAttackingState(entity, direction);
                return true;
            }
            return false;
        }

        private void GetSprite()
        {
            entity.Sprite = direction switch
            {
                CardinalDirections.North => SpriteFactory.CreateGoriyaWalkingUpSprite(),
                CardinalDirections.East => SpriteFactory.CreateGoriyaWalkingRightSprite(),
                CardinalDirections.South => SpriteFactory.CreateGoriyaWalkingDownSprite(),
                CardinalDirections.West => SpriteFactory.CreateGoriyaWalkingLeftSprite(),
                _ => SpriteFactory.CreateGoriyaWalkingUpSprite()
            };
        }
    }
}

