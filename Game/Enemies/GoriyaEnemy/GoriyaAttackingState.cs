using Microsoft.Xna.Framework;
using MainGame.Projectiles;

namespace MainGame.Enemies
{
	public class GoriyaAttackingState : IEnemyState
	{
        public readonly IProjectile Boomerang;
        private readonly GoriyaEnemy entity;

		public GoriyaAttackingState(GoriyaEnemy goriya)
		{
			entity = goriya;
			Boomerang = new BoomerangProjectile(entity.Position, entity.MovingDirection);
		}

		public void Update()
		{
			if (!Boomerang.IsActive)
			{
				entity.State = new GoriyaMovingState(entity);
			}
			Boomerang.Update();
		}

        public void Draw()
        {
			Boomerang.Draw();
			entity.Sprite.Draw(entity.Position.X, entity.Position.Y, Color.White);
        }

        public void Move() { /* no moving while attacking */ }
	}
}

