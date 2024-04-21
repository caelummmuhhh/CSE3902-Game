using System;
using MainGame.Projectiles;
using MainGame.Rooms;

namespace MainGame.Players.Inventory
{
	public class BowEquippableItem : IInventoryItem
    {
        public int Id => (int)itemType;
        public string Name => nameof(itemType);
        public bool Equippable { get; } = true;
        public bool Stackable { get; } = false;
        public int MaxStack { get; } = 1;
        public int Quantity { get; private set; } = 1;

        // Using the bow requires player to have arrow item and consumes 1 rupee
        public bool IsUseable => (projectile is null || !projectile.IsActive)
                                 && player.Inventory.HasItem((int)ItemTypes.Arrow)
                                 && player.Inventory.Rupees.Quantity > 0;

        private readonly ItemTypes itemType = ItemTypes.Bow;
        private readonly IPlayer player;
        private readonly GameRoomManager roomManager;
        private IProjectile projectile;

        public BowEquippableItem(IPlayer player, GameRoomManager roomManager)
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
                player.Inventory.Rupees.Remove(1);
                projectile = ProjectileFactory.GetArrowProjectile(player.Position, player.FacingDirection);
                roomManager.CurrentRoom.PlayerProjectiles.Add(projectile);
            }
        }
    }
}

