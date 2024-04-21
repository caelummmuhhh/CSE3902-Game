using System;
namespace MainGame.Enemies
{
	public class EnemyStunnedState : IEnemyState
    {
        private readonly IEnemy entity;
		private readonly IEnemyState prevState;
		private int stunnedDuration;

        public EnemyStunnedState(IEnemy enemy, IEnemyState prevState, int duration)
		{
			entity = enemy;
			entity.IsStunned = true;
			stunnedDuration = duration;
            this.prevState = prevState;
		}

		public void Update()
		{
			if (stunnedDuration <= 0)
			{
				entity.IsStunned = false;
				entity.State = prevState;
            }

			stunnedDuration--;
		}

		public void Draw()
		{
			prevState.Draw();
		}

		public void Move() { }
	}
}

