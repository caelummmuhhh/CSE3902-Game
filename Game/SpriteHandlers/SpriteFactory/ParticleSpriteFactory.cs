namespace MainGame.SpriteHandlers
{
    public static partial class SpriteFactory
    {
public static ISprite CreateDeathParticle()
{
    return new ParticleSprites.DeathParticle(
        TextureMap["ParticleSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.DeathParticleSpriteColumns,
        numberOfFrames: GameConstants.DeathParticleSpriteFrames,
        frameHeight: GameConstants.DeathParticleSpriteFrameHeight,
        frameWidth: GameConstants.DeathParticleSpriteFrameWidth,
        scale: Constants.UniversalScale);
}

public static ISprite CreateSwordBeamParticle(Direction facingDirection)
{
    return new ParticleSprites.SwordBeamParticle(
        TextureMap["ParticleSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.SwordBeamParticleSpriteColumns,
        numberOfFrames: GameConstants.SwordBeamParticleSpriteFrames,
        textureStartingY: GameConstants.SwordBeamParticleSpriteTextureStartingY,
        frameHeight: GameConstants.SwordBeamParticleSpriteFrameHeight,
        frameWidth: GameConstants.SwordBeamParticleSpriteFrameWidth,
        facingDirection: facingDirection,
        scale: Constants.UniversalScale);
}

public static ISprite CreateSpawnParticle()
{
    return new ParticleSprites.SpawnParticle(
        TextureMap["ParticleSprites"], SpriteBatch,
        numRows: GameConstants.StandardSpriteRows,
        numColumns: GameConstants.SpawnParticleSpriteColumns,
        numberOfFrames: GameConstants.SpawnParticleSpriteFrames,
        textureStartingY: GameConstants.SpawnParticleSpriteTextureStartingY,
        frameHeight: GameConstants.SpawnParticleSpriteFrameHeight,
        frameWidth: GameConstants.SpawnParticleSpriteFrameWidth,
        scale: Constants.UniversalScale);
}    
}
}
