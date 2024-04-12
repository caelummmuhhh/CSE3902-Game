using System;
using MainGame.Projectiles;

namespace MainGame.Players.Inventory.Equipment
{
	public class CandleEquipment : GenericEquipment
    {
        private readonly IPlayer player;

        public CandleEquipment(IPlayer player)
        {
            this.player = player;
        }

        protected override IProjectile GetNewProjectile()
        {
            return ProjectileFactory.GetFireProjectile(player.Position, player.FacingDirection);
        }
    }
}
