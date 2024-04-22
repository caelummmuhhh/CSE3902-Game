using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Players;
using System;
using MainGame.Audio;
using MainGame.Rooms;

namespace MainGame.WorldItems
{
	public static class ItemFactory
	{
		public static IPickupableItem CreateItem(ItemTypes itemType, Vector2 position, IPlayer player,
			GameRoomManager roomManager = null)
		{
			return itemType switch
			{
				ItemTypes.Heart => new HealthRecoveryItem(position, player, itemType, 2),
				ItemTypes.Fairy => new FairyItem(position, player),
				ItemTypes.HeartContainer => new HeartContainerItem(position, player),
				ItemTypes.Rupee => new RupeeItem(position, player, itemType, 1),
				ItemTypes.FiveRupees => new RupeeItem(position, player, itemType, 5),
				ItemTypes.Map => new DungeonMapItem(position, player, roomManager),
				ItemTypes.Compass => new DungeonCompassItem(position, player, roomManager),
				ItemTypes.Key => new KeyItem(position, player),
				ItemTypes.Boomerang => new SingleStackEquipmentItem(position, itemType, player),
				ItemTypes.Bow => new SingleStackEquipmentItem(position, itemType, player),
				ItemTypes.Arrow => new SingleStackEquipmentItem(position, itemType, player),
				ItemTypes.Candle => new SingleStackEquipmentItem(position, itemType, player),
				ItemTypes.Bomb => new BombItem(position, player, 4),
				_ => null
			};
		}

		/// <summary>
		/// Tries to create an item based on a provided item name.
		/// </summary>
		/// <param name="itemName">The name of the item to try to create.</param>
		/// <param name="position">Position of where the item will be spawned.</param>
		/// <param name="player">The player that will be affected by such items</param>
		/// <param name="throwException">If unable to parse, throw an exception if true, return null otherwise.</param>
		/// <returns>The created item from the provided name.</returns>
		/// <exception cref="ArgumentException">If an item was unable to be parsed.</exception>
        public static IPickupableItem CreateItem(string itemName, Vector2 position, IPlayer player,
			GameRoomManager roomManager = null, bool throwException = false)
		{
            bool conversionSuccess = Enum.TryParse(itemName, true, out ItemTypes item);

            if (!conversionSuccess && throwException)
            {
                throw new ArgumentException("Unable to parse item name string into an item.");
            }
			else if (!conversionSuccess && !throwException)
			{
				return null;
			}

            return CreateItem(item, position, player, roomManager);
        }
    }
}
