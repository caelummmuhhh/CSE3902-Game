using System.Collections.Generic;
using MainGame.Projectiles;

namespace MainGame.Players
{
    public class AquamentusProjectilesManager
    {
        private readonly List<AquamentusAttackProjectiles> activeProjectiles = new();

        public AquamentusProjectilesManager() { }

        public void Update()
        {
            for (int i = 0; i < activeProjectiles.Count; i++)
            {
                AquamentusAttackProjectiles projectile = activeProjectiles[i];
                projectile.Update();

                if (!projectile.IsActive)
                {
                    activeProjectiles.RemoveAt(i);
                }
            }
        }

        public void Draw()
        {
            foreach (AquamentusAttackProjectiles projectile in activeProjectiles)
            {
                projectile.Draw();
            }
        }

        public void AddProjectile(AquamentusAttackProjectiles projectile)
        {
            activeProjectiles.Add(projectile);
        }
    }
}

