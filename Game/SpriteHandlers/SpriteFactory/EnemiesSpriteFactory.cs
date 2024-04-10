using MainGame.SpriteHandlers.EnemySprites.AquamentusSprites;

namespace MainGame.SpriteHandlers
{
    public static partial class SpriteFactory
    {
        public static ISprite CreateKeeseFlightSprite()
{
    return new EnemySprites.KeeseFlightSprite(
        TextureMap["EnemiesSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.KeeseSpriteColumns,
        numberOfFrames: GameConstants.KeeseSpriteFrames,
        scale: Constants.UniversalScale);
}

public static ISprite CreateKeeseTakeOffSprite()
{
    return new EnemySprites.KeeseTakeOffSprite(
        TextureMap["EnemiesSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.KeeseSpriteColumns,
        numberOfFrames: GameConstants.KeeseSpriteFrames,
        scale: Constants.UniversalScale);
}

public static ISprite CreateKeeseLandingSprite()
{
    return new EnemySprites.KeeseLandingSprite(
        TextureMap["EnemiesSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.KeeseSpriteColumns,
        numberOfFrames: GameConstants.KeeseSpriteFrames,
        scale: Constants.UniversalScale);
}

public static ISprite CreateKeeseLandedSprite()
{
    return new EnemySprites.KeeseLandedSprite(
        TextureMap["EnemiesSprites"], SpriteBatch,
        textureStartingX: GameConstants.KeeseLandedSpriteTextureStartingX,
        scale: Constants.UniversalScale);
}

public static ISprite CreateStalfosSprite()
{
    return new EnemySprites.StalfosSprite(
        TextureMap["EnemiesSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.StandardSpriteColumns,
        numberOfFrames: GameConstants.StandardSpriteFrames,
        textureStartingY: GameConstants.StalfosSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateGelSprite()
{
    return new EnemySprites.GelSprite(
        TextureMap["EnemiesSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.GelSpriteColumns,
        numberOfFrames: GameConstants.GelSpriteFrames,
        textureStartingY: GameConstants.GelSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateWallMasterSprite()
{
    return new EnemySprites.WallMasterSprite(
        TextureMap["EnemiesSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.WallMasterSpriteColumns,
        numberOfFrames: GameConstants.WallMasterSpriteFrames,
        textureStartingY: GameConstants.WallMasterSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateOldManSprite()
{
    return new EnemySprites.OldManSprite(
        TextureMap["EnemiesSprites"], SpriteBatch,
        textureStartingX: GameConstants.OldManSpriteTextureStartingX,
        textureStartingY: GameConstants.OldManSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateSpikeCrossSprite()
{
    return new EnemySprites.SpikeCrossSprite(
        TextureMap["EnemiesSprites"], SpriteBatch,
        textureStartingY: GameConstants.SpikeCrossSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateAquamentusSprite()
{
    return new EnemySprites.AquamentusSprite(
        TextureMap["EnemiesSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.AquamentusSpriteColumns,
        frameHeight: GameConstants.AquamentusSpriteFrameHeight,
        frameWidth: GameConstants.AquamentusSpriteFrameWidth,
        numberOfFrames: GameConstants.AquamentusSpriteFrames,
        textureStartingY: GameConstants.AquamentusSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateAquamentusAttackingSprite()
{
    return new EnemySprites.AquamentusAttackingSprite(
        TextureMap["EnemiesSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.AquamentusSpriteColumns,
        frameHeight: GameConstants.AquamentusSpriteFrameHeight,
        frameWidth: GameConstants.AquamentusSpriteFrameWidth,
        numberOfFrames: GameConstants.AquamentusSpriteFrames,
        textureStartingX: GameConstants.AquamentusAttackingSpriteTextureStartingX,
        textureStartingY: GameConstants.AquamentusSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateAquamentusAttackSprite()
{
    return new AquamentusAttackProjectileSprite(
        TextureMap["ProjectilesSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.AquamentusAttackSpriteColumns,
        numberOfFrames: GameConstants.AquamentusAttackSpriteFrames,
        textureStartingY: GameConstants.AquamentusAttackSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateGoriyaWalkingUpSprite()
{
    return new EnemySprites.GoriyaWalkingUpSprite(
        TextureMap["EnemiesSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.StandardSpriteColumns,
        numberOfFrames: GameConstants.StandardSpriteFrames,
        textureStartingY: GameConstants.GoriyaWalkingUpSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateGoriyaWalkingDownSprite()
{
    return new EnemySprites.GoriyaWalkingDownSprite(
        TextureMap["EnemiesSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.GoriyaWalkingSpriteColumns,
        numberOfFrames: GameConstants.GoriyaWalkingSpriteFrames,
        textureStartingY: GameConstants.GoriyaWalkingDownSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateGoriyaWalkingLeftSprite()
{
    return new EnemySprites.GoriyaWalkingLeftSprite(
        TextureMap["EnemiesSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.GoriyaWalkingSpriteColumns,
        numberOfFrames: GameConstants.GoriyaWalkingSpriteFrames,
        textureStartingY: GameConstants.GoriyaWalkingLeftSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}

public static ISprite CreateGoriyaWalkingRightSprite()
{
    return new EnemySprites.GoriyaWalkingRightSprite(
        TextureMap["EnemiesSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.GoriyaWalkingSpriteColumns,
        numberOfFrames: GameConstants.GoriyaWalkingSpriteFrames,
        textureStartingY: GameConstants.GoriyaWalkingRightSpriteTextureStartingY,
        scale: Constants.UniversalScale);
}
    }
}
