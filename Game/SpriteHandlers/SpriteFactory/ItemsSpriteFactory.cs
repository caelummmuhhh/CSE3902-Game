using System;
using MainGame.SpriteHandlers.ItemSprites;

namespace MainGame.SpriteHandlers
{
    public enum ItemSpriteTypes
    {
        Heart,
        HeartContainer,
        Clock,
        FiveRupees,
        Rupee,
        Map,
        Boomerang,
        Bomb,
        Bow,
        Arrow,
        Key,
        Compass,
        TriforcePiece,
        Fairy,
        Fire
    }

    public static partial class SpriteFactory
    {
        public static ISprite CreateItemSprite(ItemSpriteTypes item)
        {
            return item switch
            {
                ItemSpriteTypes.Heart => CreateHeartItemSprite(),
                ItemSpriteTypes.HeartContainer => CreateHeartContainerItemSprite(),
                ItemSpriteTypes.Clock => CreateClockItemSprite(),
                ItemSpriteTypes.FiveRupees => CreateFiveRupeesItemSprite(),
                ItemSpriteTypes.Rupee => CreateRupeeItemSprite(),
                ItemSpriteTypes.Map => CreateMapItemSprite(),
                ItemSpriteTypes.Boomerang => CreateWoodenBoomerangItemSprite(),
                ItemSpriteTypes.Bomb => CreateBombItemSprite(),
                ItemSpriteTypes.Bow => CreateBowItemSprite(),
                ItemSpriteTypes.Arrow => CreateArrowItemSprite(),
                ItemSpriteTypes.Key => CreateKeyItemSprite(),
                ItemSpriteTypes.Compass => CreateCompassItemSprite(),
                ItemSpriteTypes.TriforcePiece => CreateTriforcePieceItemSprite(),
                ItemSpriteTypes.Fairy => CreateFairyItemSprite(),
                ItemSpriteTypes.Fire => CreateFireSprite(),
                _ => null
            };
        }

        /// <summary>
        /// Tries to create an item sprite based on an item name.
        /// </summary>
        /// <param name="itemName">The name of the item.</param>
        /// <returns>The ISprite object created based on item name.</returns>
        /// <exception cref="ArgumentException">The item name does not match to an item.</exception>
        public static ISprite CreateItemSprite(string itemName)
        {
            bool conversionSuccess = Enum.TryParse(itemName, out ItemSpriteTypes item);

            if (!conversionSuccess)
            {
                throw new ArgumentException("Unable to parse item name string into a item.");
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
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateHeartContainerItemSprite()
        {
            return new StaticItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 16,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateClockItemSprite()
        {
            return new StaticItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 32,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateFiveRupeesItemSprite()
        {
            return new StaticItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 48,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateRupeeItemSprite()
        {
            return new RupeeItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                textureStartingY: 48,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateMapItemSprite()
        {
            return new StaticItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 64,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateWoodenBoomerangItemSprite()
        {
            return new StaticItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 80,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateBombItemSprite()
        {
            return new StaticItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 96,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateBowItemSprite()
        {
            return new StaticItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 112,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateArrowItemSprite()
        {
            return new StaticItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 128,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateKeyItemSprite()
        {
            return new StaticItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 144,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateCompassItemSprite()
        {
            return new StaticItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 160,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateTriforcePieceItemSprite()
        {
            return new TriforcePieceItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                textureStartingY: 176,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateFairyItemSprite()
        {
            return new FairyItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                textureStartingY: 192,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateFireSprite()
        {
            return new FireSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 1,
                numberOfFrames: 1,
                textureStartingY: 208,
                scale: UniversalScaleMultiplier);

        }
    }
}
