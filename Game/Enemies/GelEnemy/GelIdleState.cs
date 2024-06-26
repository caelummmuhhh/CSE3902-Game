﻿using System;
using Microsoft.Xna.Framework;

namespace MainGame.Enemies
{
	public class GelIdleState : IEnemyState
	{
		private readonly GenericEnemy entity;
		private int stateDuration;

		public GelIdleState(GenericEnemy enemy)
		{
			entity = enemy;
			stateDuration = new Random().Next(0, 8) * 16;
        }

		public void Update()
		{
            entity.PreviousPosition = new(entity.Position.X, entity.Position.Y);
            if (stateDuration <= 0)
			{
				entity.State = new GelMovingState(entity);
			}
			stateDuration--;
		}

		public void Draw() => entity.Sprite.Draw(entity.Position.X, entity.Position.Y, entity.SpriteColor);

        public void Move() { /* no movement during idle... */ }
	}
}

