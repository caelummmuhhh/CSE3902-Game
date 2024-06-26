﻿using System;
using MainGame.SpriteHandlers;
using Microsoft.Xna.Framework;

namespace MainGame.Enemies
{
	public class KeeseLandedState : IEnemyState
	{
		private readonly KeeseEnemy entity;
		private int landDurationTimer = new Random().Next(5, 20) * 10; // TODO: Figure out how long duration actual is.

        public KeeseLandedState(KeeseEnemy enemy)
		{
			entity = enemy;
			entity.Sprite = SpriteFactory.CreateKeeseLandedSprite();
		}

		public void Update()
		{
			if (landDurationTimer <= 0)
			{
				entity.State = new KeeseTakeOffState(entity);
			}
			landDurationTimer--;
        }

        public void Draw() => entity.Sprite.Draw(entity.Position.X, entity.Position.Y, entity.SpriteColor);

        public void Move() { /* no movement while landed */ }
    }
}

