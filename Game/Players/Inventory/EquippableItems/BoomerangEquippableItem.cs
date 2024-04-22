using System;
using MainGame.Audio;
using MainGame.Projectiles;
using MainGame.Rooms;

namespace MainGame.Players.Inventory
{
	public class BoomerangEquippableItem : IInventoryItem
    {
        public int Id => (int)itemType;
        public string Name => itemType.ToString();
        public bool Equippable { get; } = true;
        public bool Stackable { get; } = false;
        public bool IsUseable => projectile is null || !projectile.IsActive;
        public int MaxStack { get; } = 1;
        public int Quantity { get; private set; } = 1;

        private readonly ItemTypes itemType = ItemTypes.Boomerang;
        private readonly IPlayer player;
        private readonly GameRoomManager roomManager;
        private IProjectile projectile;

        public BoomerangEquippableItem(IPlayer player, GameRoomManager roomManager)
		{
            this.player = player;
            this.roomManager = roomManager;
        }

        public void Add(int quantity) { /* nothing to do */ }
        public void Remove(int quantity) { /* nothing to do */ }

        public void Use()
        {
            if (IsUseable)
            {
                AudioManager.PlaySFX("Arrow_And_Boomerang", 0);
                projectile = ProjectileFactory.GetPlayerBoomerangProjectile(player, player.FacingDirection);
                roomManager.CurrentRoom.PlayerProjectiles.Add(projectile);
            }
        }
    }
}

