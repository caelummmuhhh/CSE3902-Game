using System;
using MainGame.Rooms;

namespace MainGame.Players.Inventory
{
	public static class InventoryItemFactory
	{
		public static IInventoryItem CreateInventoryItem(ItemTypes item, IPlayer player, GameRoomManager roomManager, int quantity, bool throwException = false)
		{
            IInventoryItem createdItem = item switch
			{
				ItemTypes.Arrow => new ArrowPassiveItem(),
				ItemTypes.Rupee => new RupeesPassiveItem(quantity),
				ItemTypes.Key => new KeysPassiveItem(quantity),
				ItemTypes.Bomb => new BombEquippableItem(player, roomManager, quantity),
				ItemTypes.Boomerang => new BoomerangEquippableItem(player, roomManager),
				ItemTypes.Bow => new BowEquippableItem(player, roomManager),
				ItemTypes.Candle => new CandleEquippableItem(player, roomManager),
				_ => null
			};

			if (createdItem is null && throwException)
			{
                throw new ArgumentException($"Item \"{nameof(item)}\" cannot be parsed into an inventory item.");
            }
			return createdItem;
		}

		public static IInventoryItem CreateInventoryItem(int itemId, IPlayer player = null, GameRoomManager roomManager = null,
			int quantity = 0, bool throwException = false)
        {
            bool conversionSuccess = Enum.TryParse(itemId.ToString(), true, out ItemTypes itemType);

            if (!conversionSuccess && throwException)
            {
                throw new ArgumentException($"Unable to parse item id {itemId} into an item.");
            }
            else if (!conversionSuccess && !throwException)
            {
                return null;
            }

            return CreateInventoryItem(itemType, player, roomManager, quantity, throwException);

        }

        public static IInventoryItem CreateInventoryItem(string itemName, IPlayer player = null, GameRoomManager roomManager = null,
			int quantity = 0, bool throwException = false)
		{
            bool conversionSuccess = Enum.TryParse(itemName, true, out ItemTypes itemType);

            if (!conversionSuccess && throwException)
            {
                throw new ArgumentException($"Unable to parse item name, \"{itemName}\" string into an item.");
            }
            else if (!conversionSuccess && !throwException)
            {
                return null;
            }

            return CreateInventoryItem(itemType, player, roomManager, quantity, throwException);
        }
    }
}

