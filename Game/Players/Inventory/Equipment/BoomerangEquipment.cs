using System;
using MainGame.Projectiles;

namespace MainGame.Players.Inventory.Equipment
{
	public class BoomerangEquipment : GenericEquipment
    {
        private readonly IPlayer player;

        public BoomerangEquipment(IPlayer player)
        {
            this.player = player;
        }

        protected override IProjectile GetNewProjectile()
        {
            return ProjectileFactory.GetPlayerBoomerangProjectile(player, player.FacingDirection);
        }
    }
}
