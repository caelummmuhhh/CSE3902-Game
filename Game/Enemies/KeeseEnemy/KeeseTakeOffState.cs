﻿using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
	public class KeeseTakeOffState : IEnemyState
	{
		private readonly KeeseEnemy entity;
		private readonly int stateDuration;
		private int stateTimeRemaining;

		public KeeseTakeOffState(KeeseEnemy enemy)
		{
			enemy.ChangeDirection();

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

        public void Draw() => entity.Sprite.Draw(entity.Position.X, entity.Position.Y, entity.SpriteColor);

        public void Move()
		{
			// Move in direction every 8 frames for first half, then 4 frames for second
			if ((stateTimeRemaining > stateDuration / 2 && stateTimeRemaining % 8 != 0)
				|| (stateTimeRemaining <= stateDuration / 2 && stateTimeRemaining % 4 != 0))
			{
				return;
			}
            entity.Position = Utils.DirectionalMove(entity.Position, entity.MovingDirection, entity.MovementSpeed);
        }
    }
}
