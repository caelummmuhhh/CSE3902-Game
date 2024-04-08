namespace MainGame.SpriteHandlers
{
    public static partial class SpriteFactory
    {
        public static ISprite CreateDeathParticle()
        {
            return new ParticleSprites.DeathParticle(
                TextureMap["ParticleSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                frameHeight: 16,
                frameWidth: 16,
                scale: Constants.UniversalScale) ;
        }

        public static ISprite CreateSwordBeamParticle(Direction facingDirection)
        {
            return new ParticleSprites.SwordBeamParticle(
                TextureMap["ParticleSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                numberOfFrames: 4,
                textureStartingY: 18,               
                frameHeight: 10,
                frameWidth: 8,
                facingDirection: facingDirection,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateSpawnParticle()
        {
            return new ParticleSprites.SpawnParticle(
                TextureMap["ParticleSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 3,
                numberOfFrames: 3,
                 textureStartingY: 32,
                frameHeight: 16,
                frameWidth: 16,
                scale: Constants.UniversalScale);
        }
    }
}
