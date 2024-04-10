using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
    public class KeeseLandingState : IEnemyState
    {
        private readonly KeeseEnemy entity;
        private readonly int stateDuration;
        private int stateTimeRemaining;

        public KeeseLandingState(KeeseEnemy enemy)
        {
            enemy.ChangeDirection();

            entity = enemy;
            entity.Sprite = SpriteFactory.CreateKeeseLandingSprite();

            AnimatedSprite newSprite = (AnimatedSprite)entity.Sprite;
            stateDuration = newSprite.AnimationFrameDuration;
            stateTimeRemaining = stateDuration;
        }

        public void Update()
        {
            if (stateTimeRemaining <= 0)
            {
                entity.State = new KeeseLandedState(entity);
                return;
            }

            stateTimeRemaining--;
            Move();
        }

        public void Draw() => entity.Draw();

        public void Move()
        {
            // Move in direction every 4 frames for first half, then 8 frames for second
        if ((stateTimeRemaining < stateDuration / GameConstants.KeeseLandingStateHalf && stateTimeRemaining % GameConstants.KeeseLandingStateMoveSlow != 0)
            || (stateTimeRemaining >= stateDuration / GameConstants.KeeseLandingStateHalf && stateTimeRemaining % GameConstants.KeeseLandingStateMoveFast != 0))
            {
                return;
            }

            entity.Position = Utils.DirectionalMove(entity.Position, entity.MovingDirection, entity.MovementSpeed);
        }
    }
}
