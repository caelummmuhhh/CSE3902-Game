using System.Collections.Generic;
using MainGame.Projectiles;

namespace MainGame.Players
{
	public class PlayerProjectilesManager
	{
		private List<IProjectile> activeProjectiles = new();
		private readonly Player player;

		public PlayerProjectilesManager(Player player)
		{
			this.player = player;
		}

		public void Update()
		{
			for (int i = 0; i < activeProjectiles.Count; i++)
			{
				IProjectile projectile = activeProjectiles[i];
				projectile.Update();

                if (!projectile.IsActive)
                {
					activeProjectiles.RemoveAt(i);
                }
            }
		}

		public void Draw()
		{
			foreach (IProjectile projectile in activeProjectiles)
			{
				projectile.Draw();
			}
		}

		public void AddProjectile(IProjectile projectile)
		{
			activeProjectiles.Add(projectile);
		}
	}
}

