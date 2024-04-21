using System;
using MainGame.Projectiles;
using MainGame.Rooms;

namespace MainGame.Players.Inventory
{
	public class BombEquippableItem : IInventoryItem
	{
        public int Id => (int)itemType;
        public string Name => nameof(itemType);
        public bool Equippable { get; } = true;
        public bool Stackable { get; } = true;
        public bool IsUseable => Quantity > 0 && (projectile is null || !projectile.IsActive);
        public int MaxStack { get; } = 999;
        public int Quantity { get; private set; }

        private readonly ItemTypes itemType = ItemTypes.Bomb;
        private readonly IPlayer player;
        private readonly GameRoomManager roomManager;
        private IProjectile projectile;

        public BombEquippableItem(IPlayer player, GameRoomManager roomManager, int quantity = 0)
		{
            this.player = player;
            this.roomManager = roomManager;
            Quantity = quantity;
		}

        public void Add(int quantity)
        {
            Quantity = Quantity + quantity > MaxStack ? MaxStack : Quantity + quantity;
        }

        public void Remove(int quantity)
        {
            Quantity = Quantity - quantity < 0 ? 0 : Quantity - quantity;
        }

        public void Use()
        {
            if (IsUseable)
            {
                Remove(1);
                projectile = ProjectileFactory.GetBombProjectile(player.Position, player.FacingDirection);
                roomManager.CurrentRoom.PlayerProjectiles.Add(projectile);
            }
        }
	}
}

