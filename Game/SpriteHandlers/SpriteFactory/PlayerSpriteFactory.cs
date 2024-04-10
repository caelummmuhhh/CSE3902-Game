using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MainGame.SpriteHandlers
{
    public static partial class SpriteFactory
    {
public static ISprite CreatePlayerAttackingDownSprite()
{
    return new PlayerSprites.PlayerAttackingDownSprite(
        TextureMap["LinkSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.PlayerAttackingSpriteColumns,
        frameHeight: GameConstants.PlayerAttackingDownSpriteFrameHeight,
        frameWidth: GameConstants.PlayerAttackingSpriteFrameWidth,
        numberOfFrames: GameConstants.PlayerAttackingSpriteFrames,
        textureStartingY: GameConstants.PlayerAttackingDownSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreatePlayerAttackingUpSprite()
{
    return new PlayerSprites.PlayerAttackingUpSprite(
        TextureMap["LinkSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.PlayerAttackingSpriteColumns,
        frameHeight: GameConstants.PlayerAttackingUpSpriteFrameHeight,
        frameWidth: GameConstants.PlayerAttackingSpriteFrameWidth,
        numberOfFrames: GameConstants.PlayerAttackingSpriteFrames,
        textureStartingY: GameConstants.PlayerAttackingUpSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreatePlayerAttackingRightSprite()
{
    return new PlayerSprites.PlayerAttackingRightSprite(
        TextureMap["LinkSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.PlayerAttackingSpriteColumns,
        frameHeight: GameConstants.PlayerAttackingRightSpriteFrameHeight,
        frameWidth: GameConstants.PlayerAttackingRightSpriteFrameWidth,
        numberOfFrames: GameConstants.PlayerAttackingSpriteFrames,
        textureStartingY: GameConstants.PlayerAttackingRightSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreatePlayerAttackingLeftSprite()
{
    return new PlayerSprites.PlayerAttackingLeftSprite(
        TextureMap["LinkSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.PlayerAttackingSpriteColumns,
        frameHeight: GameConstants.PlayerAttackingLeftSpriteFrameHeight,
        frameWidth: GameConstants.PlayerAttackingLeftSpriteFrameWidth,
        numberOfFrames: GameConstants.PlayerAttackingSpriteFrames,
        textureStartingY: GameConstants.PlayerAttackingLeftSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreatePlayerWalkingDownSprite()
{
    return new PlayerSprites.PlayerWalkingDownSprite(
        TextureMap["LinkSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.PlayerWalkingSpriteColumns,
        numberOfFrames: GameConstants.PlayerWalkingSpriteFrames,
        textureStartingY: GameConstants.PlayerWalkingDownSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreatePlayerWalkingUpSprite()
{
    return new PlayerSprites.PlayerWalkingUpSprite(
        TextureMap["LinkSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.PlayerWalkingSpriteColumns,
        numberOfFrames: GameConstants.PlayerWalkingSpriteFrames,
        textureStartingY: GameConstants.PlayerWalkingUpSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreatePlayerWalkingLeftSprite()
{
    return new PlayerSprites.PlayerWalkingLeftSprite(
        TextureMap["LinkSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.PlayerWalkingSpriteColumns,
        numberOfFrames: GameConstants.PlayerWalkingSpriteFrames,
        textureStartingY: GameConstants.PlayerWalkingLeftSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreatePlayerWalkingRightSprite()
{
    return new PlayerSprites.PlayerWalkingRightSprite(
        TextureMap["LinkSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.PlayerWalkingSpriteColumns,
        numberOfFrames: GameConstants.PlayerWalkingSpriteFrames,
        textureStartingY: GameConstants.PlayerWalkingRightSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreatePlayerHoldingItemSprite()
{
    return new PlayerSprites.PlayerHoldingItemSprite(
        TextureMap["LinkSprites"], SpriteBatch,
        textureStartingY: GameConstants.PlayerHoldingItemSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreatePlayerHoldingTriforceSprite()
{
    return new PlayerSprites.PlayerHoldingItemSprite(
        TextureMap["LinkSprites"], SpriteBatch,
        textureStartingY: GameConstants.PlayerHoldingTriforceSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreatePlayerInteractingDownSprite()
{
    return new PlayerSprites.PlayerInteractingDownSprite(
        TextureMap["LinkSprites"], SpriteBatch,
        textureStartingY: GameConstants.PlayerInteractingDownSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreatePlayerInteractingUpSprite()
{
    return new PlayerSprites.PlayerInteractingUpSprite(
        TextureMap["LinkSprites"], SpriteBatch,
        textureStartingY: GameConstants.PlayerInteractingUpSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreatePlayerInteractingLeftSprite()
{
    return new PlayerSprites.PlayerInteractingLeftSprite(
        TextureMap["LinkSprites"], SpriteBatch,
        textureStartingY: GameConstants.PlayerInteractingLeftSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreatePlayerInteractingRightSprite()
{
    return new PlayerSprites.PlayerInteractingRightSprite(
        TextureMap["LinkSprites"], SpriteBatch,
        textureStartingY: GameConstants.PlayerInteractingRightSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreatePlayerIdleDownSprite()
{
    return new PlayerSprites.PlayerIdleDownSprite(
        TextureMap["LinkSprites"], SpriteBatch,
        textureStartingY: GameConstants.PlayerIdleDownSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreatePlayerIdleUpSprite()
{
    return new PlayerSprites.PlayerIdleUpSprite(
        TextureMap["LinkSprites"], SpriteBatch,
        textureStartingY: GameConstants.PlayerIdleUpSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreatePlayerIdleLeftSprite()
{
    return new PlayerSprites.PlayerIdleLeftSprite(
        TextureMap["LinkSprites"], SpriteBatch,
        textureStartingY: GameConstants.PlayerIdleLeftSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreatePlayerIdleRightSprite()
{
    return new PlayerSprites.PlayerIdleRightSprite(
        TextureMap["LinkSprites"], SpriteBatch,
        textureStartingY: GameConstants.PlayerIdleRightSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}    }
}
