using System;
using MainGame.Particles;

namespace MainGame.Enemies
{
	public class EnemyDeathState : IEnemyState
	{
		private readonly IEnemy entity;
		private readonly IParticle deathParticle;

        public EnemyDeathState(IEnemy enemy)
		{
			entity = enemy;
			deathParticle = ParticleFactory.GetDeathParticle(enemy.Position);
        }

		public void Update()
		{
            if (deathParticle.IsActive)
            {
                deathParticle.Update();
            }
			else
			{
				entity.Exists = false;
			}
        }

        public void Draw()
		{
			if (deathParticle.IsActive)
			{
				deathParticle.Draw();
			}
		}

		public void Move() { }
	}
}

