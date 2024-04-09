using System.Collections.Generic;
using MainGame.Projectiles;

namespace MainGame.Players
{
	public class PlayerProjectilesManager
	{
		public List<IProjectile> ActiveProjectiles { get; } = new();
		private readonly Player player;

		public PlayerProjectilesManager(Player player)
		{
			this.player = player;
		}

		public void Update()
		{
			for (int i = 0; i < ActiveProjectiles.Count; i++)
			{
				IProjectile projectile = ActiveProjectiles[i];
				projectile.Update();

                if (!projectile.IsActive)
                {
					ActiveProjectiles.RemoveAt(i);
                }
            }
		}

		public void Draw()
		{
			foreach (IProjectile projectile in ActiveProjectiles)
			{
				projectile.Draw();
			}
		}

		public void AddProjectile(IProjectile projectile)
		{
			ActiveProjectiles.Add(projectile);
		}
	}
}

