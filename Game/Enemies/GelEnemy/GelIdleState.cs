using System;
namespace MainGame.Enemies
{
	public class GelIdleState : IEnemyState
	{
		private readonly IEnemy entity;
		private int stateDuration;

		public GelIdleState(IEnemy enemy)
		{
			entity = enemy;
			stateDuration = new Random().Next(0, 8) * 16;
        }

		public void Update()
		{
			if (stateDuration <= 0)
			{
				entity.State = new GelMovingState(entity);
			}
			stateDuration--;
		}

		public void Draw() => entity.Draw();

		public void Move() { /* no movement during idle... */ }
	}
}

