using System;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
	public class KeeseLandedState : IEnemyState
	{
		private readonly IEnemy entity;
		private int landDurationTimer = 100;

		public KeeseLandedState(IEnemy enemy)
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

