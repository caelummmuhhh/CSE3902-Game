using System;
using MainGame.Projectiles;
using MainGame.Rooms;

namespace MainGame.Players.Inventory
{
	public class CandleEquippableItem : IInventoryItem
    {
        public int Id => (int)itemType;
        public string Name => nameof(itemType);
        public bool Equippable { get; } = true;
        public bool Stackable { get; } = false;
        public bool IsUseable => projectile is null || !projectile.IsActive;
        public int MaxStack { get; } = 1;
        public int Quantity { get; private set; } = 1;

        private readonly ItemTypes itemType = ItemTypes.Candle;
        private readonly IPlayer player;
        private readonly GameRoomManager roomManager;
        private IProjectile projectile;

        public CandleEquippableItem(IPlayer player, GameRoomManager roomManager)
        {
            this.player = player;
            this.roomManager = roomManager;
        }

        public void Add(int quantity)
        {
            // The Add function will be used to indicate that the candle can be used again
            Quantity = 1;
        }
        public void Remove(int quantity) { /* nothing to do */ }

        public void Use()
        {
            if (IsUseable)
            {
                Quantity = 0;
                projectile = ProjectileFactory.GetFireProjectile(player.Position, player.FacingDirection);
                roomManager.CurrentRoom.PlayerProjectiles.Add(projectile);
            }
        }
    }
}
