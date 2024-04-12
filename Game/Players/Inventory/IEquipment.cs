using System;
using MainGame.Projectiles;

namespace MainGame.Players.Inventory
{
	public interface IEquipment
	{
		public bool IsActive { get; }
		public IProjectile Projectile { get; }

		public void Use();
		public void Draw();
		public void Update();
	}
}

