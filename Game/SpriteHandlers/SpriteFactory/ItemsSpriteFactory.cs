using System;
using MainGame.SpriteHandlers.ItemSprites;

namespace MainGame.SpriteHandlers
{
    public static partial class SpriteFactory
    {
        public static ISprite CreateItemSprite(ItemTypes item)
        {
            return item switch
            {
                ItemTypes.Heart => CreateHeartItemSprite(),
                ItemTypes.HeartContainer => CreateHeartContainerItemSprite(),
                ItemTypes.Clock => CreateClockItemSprite(),
                ItemTypes.FiveRupees => CreateFiveRupeesItemSprite(),
                ItemTypes.Rupee => CreateRupeeItemSprite(),
                ItemTypes.Map => CreateMapItemSprite(),
                ItemTypes.Boomerang => CreateWoodenBoomerangItemSprite(),
                ItemTypes.Bomb => CreateBombItemSprite(),
                ItemTypes.Bow => CreateBowItemSprite(),
                ItemTypes.Arrow => CreateArrowItemSprite(),
                ItemTypes.Key => CreateKeyItemSprite(),
                ItemTypes.Compass => CreateCompassItemSprite(),
                ItemTypes.TriforcePiece => CreateTriforcePieceItemSprite(),
                ItemTypes.Fairy => CreateFairyItemSprite(),
                ItemTypes.Fire => CreateFireSprite(),
                _ => null
            };
        }

        /// <summary>
        /// Tries to create an item sprite based on an item name.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <returns>The ISprite object created based on item name.</returns>
        /// <exception cref="ArgumentException">The item name does not match to an item.</exception>
        public static ISprite CreateItemSprite(string itemName, bool throwException = false)
        {
            bool conversionSuccess = Enum.TryParse(itemName, out ItemTypes item);

            if (!conversionSuccess && throwException)
            {
                throw new ArgumentException("Unable to parse item name string into a item.");
            }
            else if (!conversionSuccess && !throwException)
            {
                return null;
            }

            return CreateItemSprite(item);
        }


        /* Create methods for each individual sprite. */

        public static ISprite CreateHeartItemSprite()
        {
            return new HeartItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateHeartContainerItemSprite()
        {
            return new StaticItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 16,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateClockItemSprite()
        {
            return new StaticItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 32,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateFiveRupeesItemSprite()
        {
            return new StaticItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 48,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateRupeeItemSprite()
        {
            return new RupeeItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                textureStartingY: 48,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateMapItemSprite()
        {
            return new StaticItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 64,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateWoodenBoomerangItemSprite()
        {
            return new StaticItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 80,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateBombItemSprite()
        {
            return new StaticItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 96,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateBowItemSprite()
        {
            return new StaticItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 112,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateArrowItemSprite()
        {
            return new StaticItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 128,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateKeyItemSprite()
        {
            return new StaticItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 144,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateCompassItemSprite()
        {
            return new StaticItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 160,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateTriforcePieceItemSprite()
        {
            return new TriforcePieceItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                textureStartingY: 176,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateFairyItemSprite()
        {
            return new FairyItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                textureStartingY: 192,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateFireSprite()
        {
            return new FireSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 1,
                numberOfFrames: 1,
                textureStartingY: 208,
                scale: Constants.UniversalScale);

        }
    }
}
