using Microsoft.Xna.Framework;
using MainGame.Players;

namespace MainGame.Projectiles
{
	public class AquamentusAttackProjectiles
	{
        public bool IsActive { get; private set; } = true;

		private readonly AquamentusUpwardProjectile upProjectile;
        private readonly AquamentusForwardProjectile straightProjectile;
        private readonly AquamentusDownwardProjectile downProjectile;


        public AquamentusAttackProjectiles(Vector2 startPosition, IPlayer player)
		{
            upProjectile = new(startPosition, player);
            straightProjectile = new(startPosition, player);
            downProjectile = new(startPosition, player);
        }

        public void Update()
        {
            upProjectile.Update();
            straightProjectile.Update();
            downProjectile.Update();

            if (!upProjectile.IsActive && !upProjectile.IsActive && !upProjectile.IsActive)
            {
                IsActive = false;
            }
        }

        public void Draw()
        {
            upProjectile.Draw();
            straightProjectile.Draw();
            downProjectile.Draw();
        }
    }
}

