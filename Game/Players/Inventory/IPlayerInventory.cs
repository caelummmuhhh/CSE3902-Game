using System.Collections.Generic;

namespace MainGame.Players.Inventory
{
	public interface IPlayerInventory
	{
		public List<IInventoryItem> Items { get; }
		public int MaxItems { get; }

		public void AddItem(int itemId, int quantity);
		public void DropItem(int itemId, int quantity);
		public bool HasItem(int itemId);
	}
}
