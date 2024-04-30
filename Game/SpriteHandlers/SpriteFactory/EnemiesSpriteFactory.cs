using MainGame.SpriteHandlers.EnemySprites.AquamentusSprites;

namespace MainGame.SpriteHandlers
{
    public static partial class SpriteFactory
    {
        public static ISprite CreateKeeseFlightSprite()
        {
            return new EnemySprites.KeeseFlightSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                layerDepth: DefaultSpriteLayerDepths.EnemiesLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateKeeseTakeOffSprite()
        {
            return new EnemySprites.KeeseTakeOffSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                layerDepth: DefaultSpriteLayerDepths.EnemiesLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateKeeseLandingSprite()
        {
            return new EnemySprites.KeeseLandingSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                layerDepth: DefaultSpriteLayerDepths.EnemiesLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateKeeseLandedSprite()
        {
            return new EnemySprites.KeeseLandedSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                textureStartingX: 16,
                layerDepth: DefaultSpriteLayerDepths.EnemiesLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateStalfosSprite()
        {
            return new EnemySprites.StalfosSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 1,
                numberOfFrames: 1,
                textureStartingY: 16,
                layerDepth: DefaultSpriteLayerDepths.EnemiesLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateDarkStalfosSprite()
        {
            return new EnemySprites.DarkStalfosSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 1,
                numberOfFrames: 1,
                textureStartingY: 16,
                layerDepth: DefaultSpriteLayerDepths.EnemiesLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateGelSprite()
        {
            return new EnemySprites.GelSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                textureStartingY: 32,
                layerDepth: DefaultSpriteLayerDepths.EnemiesLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateWallMasterSprite()
        {
            return new EnemySprites.WallMasterSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                textureStartingY: 96,
                layerDepth: DefaultSpriteLayerDepths.EnemiesLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateOldManSprite()
        {
            return new EnemySprites.OldManSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                textureStartingX: 0,
                textureStartingY: 112,
                layerDepth: DefaultSpriteLayerDepths.EnemiesLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateSpikeCrossSprite()
        {
            return new EnemySprites.SpikeCrossSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                textureStartingY: 128,
                layerDepth: DefaultSpriteLayerDepths.EnemiesLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateAquamentusSprite()
        {
            return new EnemySprites.AquamentusSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                frameHeight: 32,
                frameWidth: 24,
                numberOfFrames: 2,
                textureStartingY: 144,
                layerDepth: DefaultSpriteLayerDepths.EnemiesLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateAquamentusAttackingSprite()
        {
            return new EnemySprites.AquamentusAttackingSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                frameHeight: 32,
                frameWidth: 24,
                numberOfFrames: 2,
                textureStartingX: 48,
                textureStartingY: 144,
                layerDepth: DefaultSpriteLayerDepths.EnemiesLayer,
                scale: Constants.UniversalScale);
        }


        public static ISprite CreateAquamentusAttackSprite()
        {
            return new AquamentusAttackProjectileSprite(
                TextureMap["ProjectilesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                numberOfFrames: 4,
                textureStartingY: 64,
                layerDepth: DefaultSpriteLayerDepths.EnemiesLayer,
                scale: Constants.UniversalScale);
        }


        public static ISprite CreateGoriyaWalkingUpSprite()
        {
            return new EnemySprites.GoriyaWalkingUpSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 1,
                numberOfFrames: 1,
                textureStartingY: 64,
                layerDepth: DefaultSpriteLayerDepths.EnemiesLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateGoriyaWalkingDownSprite()
        {
            return new EnemySprites.GoriyaWalkingDownSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                textureStartingY: 48,
                layerDepth: DefaultSpriteLayerDepths.EnemiesLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateGoriyaWalkingLeftSprite()
        {
            return new EnemySprites.GoriyaWalkingLeftSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                textureStartingY: 80,
                layerDepth: DefaultSpriteLayerDepths.EnemiesLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateGoriyaWalkingRightSprite()
        {
            return new EnemySprites.GoriyaWalkingRightSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                textureStartingY: 80,
                layerDepth: DefaultSpriteLayerDepths.EnemiesLayer,
                scale: Constants.UniversalScale);
        }
    }
}
