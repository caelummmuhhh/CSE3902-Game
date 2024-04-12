using System;
using MainGame.Projectiles;

namespace MainGame.Players.Inventory.Equipment
{
	public abstract class GenericEquipment : IEquipment
	{
        public virtual bool IsActive { get; protected set; }
        public virtual IProjectile Projectile { get; protected set; }

        public GenericEquipment()
        {
            IsActive = false;
            Projectile = null;
        }

        public virtual void Use()
        {
            if (IsActive)
            {
                return;
            }

            Projectile = GetNewProjectile();
            IsActive = Projectile.IsActive;
        }

        public virtual void Draw()
        {
            Projectile?.Draw();
        }

        public virtual void Update()
        {
            if (Projectile is not null)
            {
                Projectile.Update();
                IsActive = Projectile.IsActive;
                Projectile = Projectile.IsActive ? Projectile : null;
            }
        }

        protected abstract IProjectile GetNewProjectile();
    }
}
