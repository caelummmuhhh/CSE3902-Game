using Microsoft.Xna.Framework;
using MainGame.Players;

namespace MainGame.Projectiles
{
	public class AquamentusAttackProjectiles
	{
        public bool IsActive { get; private set; } = true;
        public AquamentusUpwardProjectile UpProjectile { get => upProjectile;  }
        public AquamentusForwardProjectile StraightProjectile { get => straightProjectile; }
        public AquamentusDownwardProjectile DownProjectile { get => downProjectile; }

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
            if (upProjectile.IsActive)
            {
                upProjectile.Update();
            }
            if (straightProjectile.IsActive)
            {
                straightProjectile.Update();
            }
            if (downProjectile.IsActive)
            {
                downProjectile.Update();
            }

            IsActive = upProjectile.IsActive || straightProjectile.IsActive || downProjectile.IsActive;
        }

        public void Draw()
        {
            if (upProjectile.IsActive)
            {
                upProjectile.Draw();
            }
            if (straightProjectile.IsActive)
            {
                straightProjectile.Draw();
            }
            if (downProjectile.IsActive)
            {
                downProjectile.Draw();
            }
        }
    }
}

