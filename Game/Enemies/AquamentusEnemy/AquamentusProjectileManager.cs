using System.Collections.Generic;
using MainGame.Projectiles;

namespace MainGame.Players
{
    public class AquamentusProjectilesManager
    {
        public readonly List<AquamentusAttackProjectiles> ActiveProjectiles = new();

        public AquamentusProjectilesManager() { }

        public void Update()
        {
            for (int i = 0; i < ActiveProjectiles.Count; i++)
            {
                AquamentusAttackProjectiles projectile = ActiveProjectiles[i];
                projectile.Update();

                if (!projectile.IsActive)
                {
                    ActiveProjectiles.RemoveAt(i);
                }
            }
        }

        public void Draw()
        {
            foreach (AquamentusAttackProjectiles projectile in ActiveProjectiles)
            {
                projectile.Draw();
            }
        }

        public void AddProjectile(AquamentusAttackProjectiles projectile)
        {
            ActiveProjectiles.Add(projectile);
        }
    }
}

