using MainGame.Players;
using MainGame.WorldItems;
using System;

namespace MainGame.Collision.CollisionHandlers
{
	public class PlayerItemCollisionHandler : ICollisionHandler
	{
		private readonly IPlayer player;
		private readonly IPickupableItem item;

		public PlayerItemCollisionHandler(IPlayer player, IPickupableItem item)
		{
			this.player = player;
			this.item = item;
		}

		public void HandleCollision()
		{
			item.PickUp();
			Console.WriteLine($"Picked up {item.Name}");
		}
	}
}

