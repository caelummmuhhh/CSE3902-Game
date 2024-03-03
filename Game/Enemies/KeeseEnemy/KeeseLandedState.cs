using System;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
	public class KeeseLandedState : IEnemyState
	{
		private readonly GenericEnemy entity;
		private int landDurationTimer = 100; // TODO: Figure out how long duration actual is.

		public KeeseLandedState(GenericEnemy enemy)
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

        public void Draw() => entity.Draw();

		public void Move() { /* no movement while landed */ }
    }
}

