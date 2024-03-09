using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
	public class KeeseTakeOffState : IEnemyState
	{
		private readonly GenericEnemy entity;
		private readonly CardinalAndOrdinalDirection direction;
		private readonly int stateDuration;
		private int stateTimeRemaining;

		public KeeseTakeOffState(GenericEnemy enemy)
		{
            direction = EnemyUtils.GetRandomCardinalAndOrdinalDirection();

            entity = enemy;
			entity.Sprite = SpriteFactory.CreateKeeseTakeOffSprite();

			AnimatedSprite newSprite = (AnimatedSprite)entity.Sprite;
            stateDuration = newSprite.AnimationFrameDuration;
			stateTimeRemaining = stateDuration;
		}

		public void Update()
		{
			if (stateTimeRemaining <= 0)
			{
				entity.State = new KeeseFlyingState(entity);
				return;
			}

			stateTimeRemaining--;
			Move();
		}

		public void Draw() => entity.Draw();

		public void Move()
		{
			// Move in direction every 8 frames for first half, then 4 frames for second
			if ((stateTimeRemaining > stateDuration / 2 && stateTimeRemaining % 8 != 0)
				|| (stateTimeRemaining <= stateDuration / 2 && stateTimeRemaining % 4 != 0))
			{
				return;
			}
            entity.Position = EnemyUtils.DirectionalMove(entity.Position, direction, entity.MovementSpeed);
        }
    }
}
