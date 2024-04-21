using System.Collections.Generic;

namespace MainGame.Players.Inventory
{
	public interface ILinkInventory : IPlayerInventory
	{
		public IInventoryItem EquippedItem { get; }
		public IInventoryItem Rupees { get; }
		public IInventoryItem Keys { get; }
		public IInventoryItem Bombs { get; }
        public List<IInventoryItem> Equippables { get; }
		public List<IInventoryItem> PassiveItems { get; }

		public void UseEquippedItem();
		public void Equip(int itemId);
		public void UnEquip();
	}
}

