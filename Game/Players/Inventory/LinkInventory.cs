using System;
using System.Collections.Generic;
using System.Linq;
using MainGame.Rooms;

namespace MainGame.Players.Inventory
{
	public class LinkInventory : ILinkInventory
	{
        public IInventoryItem EquippedItem { get; private set; } = null;
        public int MaxItems => 99;

        // Aliases to items in Items list, these are created during init and should always exist
        public IInventoryItem Rupees { get; private set; }
        public IInventoryItem Keys { get; private set; }
        public IInventoryItem Bombs { get; private set; }

        public List<IInventoryItem> Equippables { get; } = new();
		public List<IInventoryItem> PassiveItems { get; } = new();
		public List<IInventoryItem> Items => Equippables.Concat(PassiveItems).ToList();

        private readonly IPlayer player;
        private readonly GameRoomManager roomManager;

		public LinkInventory(IPlayer player, GameRoomManager roomManager, int[] startingItemIds, int startingRupees, int startingKeyCount, int startingBombCount)
		{
            this.player = player;
            this.roomManager = roomManager;

            Rupees = InventoryItemFactory.CreateInventoryItem(ItemTypes.Rupee, player, roomManager, startingRupees);
            Keys = InventoryItemFactory.CreateInventoryItem(ItemTypes.Key, player, roomManager, startingKeyCount);
            Bombs = InventoryItemFactory.CreateInventoryItem(ItemTypes.Bomb, player, roomManager, startingBombCount);
            Equippables.Add(Bombs);
            PassiveItems.Add(Keys);
            PassiveItems.Add(Rupees);

            foreach (int itemId in startingItemIds)
            {
                if (itemId == (int)ItemTypes.Bomb)
                {
                    continue;
                }
                InventoryItemFactory.CreateInventoryItem(itemId, player, roomManager);
            }
		}

        public void Equip(int itemId)
        {
            int itemIndex = Equippables.FindIndex(item => item.Id == itemId);
            if (itemIndex >= 0)
            {
                EquippedItem = Equippables[itemIndex];
            }
        }

        public void UnEquip() => EquippedItem = null;

        public void AddItem(int itemId, int quantity)
        {
            int itemIndex = Items.FindIndex(item => item.Id == itemId);
            if (itemIndex >= 0)
            {
                Items[itemIndex].Add(quantity);
                return;
            }

            IInventoryItem newItem = InventoryItemFactory.CreateInventoryItem(itemId, player, roomManager, quantity);
            if (newItem is null) { return; }

            if (newItem.Equippable)
            {
                Equippables.Add(newItem);
            }
            else
            {
                PassiveItems.Add(newItem);
            }
        }

        public void UseEquippedItem()
        {
            if (EquippedItem is null) { return; }

            EquippedItem.Use();
            if (EquippedItem.Quantity <= 0)
            {
                EquippedItem = null;
            }
        }

        public bool HasItem(int itemId) => Items.FindIndex(item => item.Id == itemId) >= 0;

        public void DropItem(int itemId, int quantity) { /* Link can't drop items in this game :( */ }
    }
}
