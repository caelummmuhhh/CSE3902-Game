using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Players;
using System;
using MainGame.Audio;

namespace MainGame.WorldItems
{
	public static class ItemFactory
	{
		public static IPickupableItem CreateItem(ItemTypes itemType, Vector2 position, IPlayer player, AudioManager audioManager)
		{
			return itemType switch
			{
				ItemTypes.Heart => new HealthRecoveryItem(position, player, itemType, 2, audioManager),
				ItemTypes.Fairy => new FairyItem(position, player, audioManager),
				ItemTypes.HeartContainer => new HeartContainerItem(position, player, audioManager),
				ItemTypes.Rupee => new RupeeItem(position, player, itemType, 1, audioManager),
				ItemTypes.FiveRupees => new RupeeItem(position, player, itemType, 5, audioManager),
				ItemTypes.Map => new DungeonMapItem(position, player, audioManager),
				ItemTypes.Compass => new DungeonCompassItem(position, player, audioManager),
				ItemTypes.Key => new KeyItem(position, player, audioManager),
				ItemTypes.Boomerang => new SingleStackEquipmentItem(position, itemType, player, audioManager),
				ItemTypes.Bow => new SingleStackEquipmentItem(position, itemType, player, audioManager),
				ItemTypes.Arrow => new SingleStackEquipmentItem(position, itemType, player, audioManager),
				ItemTypes.Candle => new SingleStackEquipmentItem(position, itemType, player, audioManager),
				ItemTypes.Bomb => new BombItem(position, player, 4, audioManager),
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
												 AudioManager audioManager, bool throwException = false)
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

            return CreateItem(item, position, player, audioManager);
        }
    }
}
