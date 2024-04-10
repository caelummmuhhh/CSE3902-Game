using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using System;

namespace MainGame.Items
{
	public static class ItemFactory
	{
		public static IItem CreateItem(ItemTypes itemType, Vector2 position, bool active = true)
		{
			ISprite sprite = SpriteFactory.CreateItemSprite(itemType);
			return itemType switch
			{
				_ => new GenericItem(position, sprite, itemType, active)
			};
		}

		/// <summary>
		/// Tries to create an item based on a provided item name.
		/// </summary>
		/// <param name="itemName">The name of the item to try to create.</param>
		/// <param name="position">Position of where the item will be spawned.</param>
		/// <param name="active">Whether or not the item will be active upon spawnign.</param>
		/// <returns>The created item from the provided name.</returns>
		/// <exception cref="ArgumentException">If an item was unable to be parsed.</exception>
        public static IItem CreateItem(string itemName, Vector2 position, bool active = true)
		{
            bool conversionSuccess = Enum.TryParse(itemName, true, out ItemTypes item);

            if (!conversionSuccess)
            {
                throw new ArgumentException("Unable to parse item name string into an item.");
            }

            return CreateItem(item, position, active);
        }
    }
}

