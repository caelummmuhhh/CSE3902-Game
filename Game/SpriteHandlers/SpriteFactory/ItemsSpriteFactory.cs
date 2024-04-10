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
        public static ISprite CreateItemSprite(string itemName)
        {
            bool conversionSuccess = Enum.TryParse(itemName, out ItemTypes item);

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
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.HeartItemSpriteColumns,
        numberOfFrames: GameConstants.HeartItemSpriteFrames,
        scale: Constants.UniversalScale);
}

public static ISprite CreateHeartContainerItemSprite()
{
    return new StaticItemSprite(
        TextureMap["ItemsSprites"], SpriteBatch,
        textureStartingY: GameConstants.HeartContainerItemSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateClockItemSprite()
{
    return new StaticItemSprite(
        TextureMap["ItemsSprites"], SpriteBatch,
        textureStartingY: GameConstants.ClockItemSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateFiveRupeesItemSprite()
{
    return new StaticItemSprite(
        TextureMap["ItemsSprites"], SpriteBatch,
        textureStartingY: GameConstants.FiveRupeesItemSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateRupeeItemSprite()
{
    return new RupeeItemSprite(
        TextureMap["ItemsSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.RupeeItemSpriteColumns,
        numberOfFrames: GameConstants.RupeeItemSpriteFrames,
        textureStartingY: GameConstants.RupeeItemSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateMapItemSprite()
{
    return new StaticItemSprite(
        TextureMap["ItemsSprites"], SpriteBatch,
        textureStartingY: GameConstants.MapItemSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateWoodenBoomerangItemSprite()
{
    return new StaticItemSprite(
        TextureMap["ItemsSprites"], SpriteBatch,
        textureStartingY: GameConstants.WoodenBoomerangItemSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateBombItemSprite()
{
    return new StaticItemSprite(
        TextureMap["ItemsSprites"], SpriteBatch,
        textureStartingY: GameConstants.BombItemSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateBowItemSprite()
{
    return new StaticItemSprite(
        TextureMap["ItemsSprites"], SpriteBatch,
        textureStartingY: GameConstants.BowItemSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateArrowItemSprite()
{
    return new StaticItemSprite(
        TextureMap["ItemsSprites"], SpriteBatch,
        textureStartingY: GameConstants.ArrowItemSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateKeyItemSprite()
{
    return new StaticItemSprite(
        TextureMap["ItemsSprites"], SpriteBatch,
        textureStartingY: GameConstants.KeyItemSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateCompassItemSprite()
{
    return new StaticItemSprite(
        TextureMap["ItemsSprites"], SpriteBatch,
        textureStartingY: GameConstants.CompassItemSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateTriforcePieceItemSprite()
{
    return new TriforcePieceItemSprite(
        TextureMap["ItemsSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.TriforcePieceItemSpriteColumns,
        numberOfFrames: GameConstants.TriforcePieceItemSpriteFrames,
        textureStartingY: GameConstants.TriforcePieceItemSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateFairyItemSprite()
{
    return new FairyItemSprite(
        TextureMap["ItemsSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.FairyItemSpriteColumns,
        numberOfFrames: GameConstants.FairyItemSpriteFrames,
        textureStartingY: GameConstants.FairyItemSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateFireSprite()
{
    return new FireSprite(
        TextureMap["ItemsSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.StandardSpriteColumns,
        numberOfFrames: GameConstants.StandardSpriteFrames,
        textureStartingY: GameConstants.FireSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}    }
}
