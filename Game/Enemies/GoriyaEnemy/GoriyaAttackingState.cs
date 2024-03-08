using Microsoft.Xna.Framework;
using MainGame.Projectiles;

namespace MainGame.Enemies
{
	public class GoriyaAttackingState : IEnemyState
	{
		private readonly GoriyaEnemy entity;
		private readonly IProjectile boomerang;

		public GoriyaAttackingState(GoriyaEnemy goriya, CardinalDirections direction)
		{
			entity = goriya;
			boomerang = new BoomerangProjectile(entity.Position, direction);
		}

		public void Update()
		{
			if (!boomerang.IsActive)
			{
				entity.State = new GoriyaMovingState(entity);
			}
			boomerang.Update();
		}

        public void Draw()
        {
			boomerang.Draw();
			entity.Sprite.Draw(entity.Position.X, entity.Position.Y, Color.White);
        }

        public void Move() { /* no moving while attacking */ }
	}
}

