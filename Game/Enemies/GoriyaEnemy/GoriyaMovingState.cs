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

        public GoriyaMovingState(GoriyaEnemy goriya)
        {
            entity = goriya;
            moveDuration = maxMoveDuration;
            entity.MovingDirection = Utils.GetRandomCardinalDirection();
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
                entity.MovingDirection = Utils.GetRandomCardinalDirection();
                moveDuration = maxMoveDuration;
                GetSprite();
            }
        }

        public void Draw() => entity.Sprite.Draw(entity.Position.X, entity.Position.Y, Color.White);

        public void Move()
        {
            entity.PreviousPosition = new(entity.Position.X, entity.Position.Y);
            if (moveDuration % entity.MovementCoolDownFrame == 0)
            {
                entity.Position = Utils.DirectionalMove(entity.Position, entity.MovingDirection, entity.MovementSpeed);
            }
        }

        private bool AttemptBoomerang()
        {
            Random random = new();
            if (random.Next(12) == 0)
            {
                entity.State = new GoriyaAttackingState(entity);
                return true;
            }
            return false;
        }

        private void GetSprite()
        {
            entity.Sprite = entity.MovingDirection switch
            {
                Direction.North => SpriteFactory.CreateGoriyaWalkingUpSprite(),
                Direction.East => SpriteFactory.CreateGoriyaWalkingRightSprite(),
                Direction.South => SpriteFactory.CreateGoriyaWalkingDownSprite(),
                Direction.West => SpriteFactory.CreateGoriyaWalkingLeftSprite(),
                _ => SpriteFactory.CreateGoriyaWalkingUpSprite()
            };
        }
    }
}

