using System;
using MainGame.Projectiles;

namespace MainGame.Players.Inventory.Equipment
{
	public class BowEquipment : GenericEquipment
    {
        private readonly IPlayer player;

        public BowEquipment(IPlayer player)
        {
            this.player = player;
        }

        protected override IProjectile GetNewProjectile()
        {
            return ProjectileFactory.GetArrowProjectile(player.Position, player.FacingDirection);
        }
    }
}
