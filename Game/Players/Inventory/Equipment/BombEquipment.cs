using MainGame.Projectiles;

namespace MainGame.Players.Inventory.Equipment
{
	public class BombEquipment : GenericEquipment
    {
        private readonly IPlayer player;

        public BombEquipment(IPlayer player)
		{
            this.player = player;
		}

        protected override IProjectile GetNewProjectile()
        {
            return ProjectileFactory.GetBombProjectile(player.Position, player.FacingDirection);
        }
    }
}
