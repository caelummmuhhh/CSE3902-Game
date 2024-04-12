using System;
using MainGame.Projectiles;

namespace MainGame.Players.Inventory.Equipment
{
	public class SwordBeamEquipment : GenericEquipment
    {
        private readonly IPlayer player;

        public SwordBeamEquipment(IPlayer player)
        {
            this.player = player;
        }

        protected override IProjectile GetNewProjectile()
        {
            return ProjectileFactory.GetSwordBeamProjectile(player.Position, player.FacingDirection);
        }
    }
}
