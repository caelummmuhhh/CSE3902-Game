using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MainGame.SpriteHandlers.ProjectileSprites;

namespace MainGame.SpriteHandlers
{
    public static partial class SpriteFactory
    {
public static ISprite CreateArrowDownProjectileSprite()
{
    return new ArrowDownProjectileSprite(
        TextureMap["ProjectilesSprites"], SpriteBatch,
        scale: Constants.UniversalScale);
}

public static ISprite CreateArrowUpProjectileSprite()
{
    return new ArrowUpProjectileSprite(
        TextureMap["ProjectilesSprites"], SpriteBatch,
        scale: Constants.UniversalScale);
}

public static ISprite CreateArrowLeftProjectileSprite()
{
    return new ArrowLeftProjectileSprite(
        TextureMap["ProjectilesSprites"], SpriteBatch,
        scale: Constants.UniversalScale);
}

public static ISprite CreateArrowRightProjectileSprite()
{
    return new ArrowRightProjectileSprite(
        TextureMap["ProjectilesSprites"], SpriteBatch,
        scale: Constants.UniversalScale);
}

public static ISprite CreateArrowProjectileHitSprite()
{
    return new ArrowProjectileHitSprite(
        TextureMap["ProjectilesSprites"], SpriteBatch,
        textureStartingX: GameConstants.ArrowProjectileHitSpriteTextureStartingX,
        scale: Constants.UniversalScale);
}

public static ISprite CreateSwordBeamDownProjectileSprite()
{
    return new SwordBeamDownProjectileSprite(
        TextureMap["ProjectilesSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.SwordBeamProjectileSpriteColumns,
        numberOfFrames: GameConstants.SwordBeamProjectileSpriteFrames,
        textureStartingY: GameConstants.SwordBeamProjectileSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateSwordBeamUpProjectileSprite()
{
    return new SwordBeamUpProjectileSprite(
        TextureMap["ProjectilesSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.SwordBeamProjectileSpriteColumns,
        numberOfFrames: GameConstants.SwordBeamProjectileSpriteFrames,
        textureStartingY: GameConstants.SwordBeamProjectileSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateSwordBeamLeftProjectileSprite()
{
    return new SwordBeamLeftProjectileSprite(
        TextureMap["ProjectilesSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.SwordBeamProjectileSpriteColumns,
        numberOfFrames: GameConstants.SwordBeamProjectileSpriteFrames,
        textureStartingY: GameConstants.SwordBeamProjectileSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateSwordBeamRightProjectileSprite()
{
    return new SwordBeamRightProjectileSprite(
        TextureMap["ProjectilesSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.SwordBeamProjectileSpriteColumns,
        numberOfFrames: GameConstants.SwordBeamProjectileSpriteFrames,
        textureStartingY: GameConstants.SwordBeamProjectileSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateWoodenBoomerangSprite()
{
    return new WoodenBoomerangSprite(
        TextureMap["ProjectilesSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.WoodenBoomerangSpriteColumns,
        numberOfFrames: GameConstants.WoodenBoomerangSpriteFrames,
        textureStartingY: GameConstants.WoodenBoomerangSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateBombExplodingSprite()
{
    return new BombExplodingSprite(
        TextureMap["ProjectilesSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.BombExplodingSpriteColumns,
        numberOfFrames: GameConstants.BombExplodingSpriteFrames,
        textureStartingY: GameConstants.BombExplodingSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateBombSprite()
{
    return new BombSprite(
        TextureMap["ProjectilesSprites"], SpriteBatch,
        textureStartingY: GameConstants.BombSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}
        
    }
}
