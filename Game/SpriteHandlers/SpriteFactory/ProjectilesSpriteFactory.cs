using MainGame.SpriteHandlers.ProjectileSprites;

namespace MainGame.SpriteHandlers
{
    public static partial class SpriteFactory
    {
        public static ISprite CreateArrowDownProjectileSprite()
        {
            return new ArrowDownProjectileSprite(
                TextureMap["ProjectilesSprites"], SpriteBatch,
                layerDepth: DefaultSpriteLayerDepths.ProjectilesLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateArrowUpProjectileSprite()
        {
            return new ArrowUpProjectileSprite(
                TextureMap["ProjectilesSprites"], SpriteBatch,
                layerDepth: DefaultSpriteLayerDepths.ProjectilesLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateArrowLeftProjectileSprite()
        {
            return new ArrowLeftProjectileSprite(
                TextureMap["ProjectilesSprites"], SpriteBatch,
                layerDepth: DefaultSpriteLayerDepths.ProjectilesLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateArrowRightProjectileSprite()
        {
            return new ArrowRightProjectileSprite(
                TextureMap["ProjectilesSprites"], SpriteBatch,
                layerDepth: DefaultSpriteLayerDepths.ProjectilesLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateArrowProjectileHitSprite()
        {
            return new ArrowProjectileHitSprite(
                TextureMap["ProjectilesSprites"], SpriteBatch,
                textureStartingX: 16,
                layerDepth: DefaultSpriteLayerDepths.ProjectilesLayer,
                scale: Constants.UniversalScale);
        }



        public static ISprite CreateSwordBeamDownProjectileSprite()
        {
            return new SwordBeamDownProjectileSprite(
                TextureMap["ProjectilesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                numberOfFrames: 4,
                textureStartingY: 48,
                layerDepth: DefaultSpriteLayerDepths.ProjectilesLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateSwordBeamUpProjectileSprite()
        {
            return new SwordBeamUpProjectileSprite(
                TextureMap["ProjectilesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                numberOfFrames: 4,
                textureStartingY: 48,
                layerDepth: DefaultSpriteLayerDepths.ProjectilesLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateSwordBeamLeftProjectileSprite()
        {
            return new SwordBeamLeftProjectileSprite(
                TextureMap["ProjectilesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                numberOfFrames: 4,
                textureStartingY: 48,
                layerDepth: DefaultSpriteLayerDepths.ProjectilesLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateSwordBeamRightProjectileSprite()
        {
            return new SwordBeamRightProjectileSprite(
                TextureMap["ProjectilesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                numberOfFrames: 4,
                textureStartingY: 48,
                layerDepth: DefaultSpriteLayerDepths.ProjectilesLayer,
                scale: Constants.UniversalScale);
        }



        public static ISprite CreateWoodenBoomerangSprite()
        {
            return new WoodenBoomerangSprite(
                TextureMap["ProjectilesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 3,
                numberOfFrames: 3,
                textureStartingY: 16,
                layerDepth: DefaultSpriteLayerDepths.ProjectilesLayer,
                scale: Constants.UniversalScale);

        }

        public static ISprite CreateBombExplodingSprite()
        {
            return new BombExplodingSprite(
                TextureMap["ProjectilesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                numberOfFrames: 4,
                textureStartingY: 32,
                layerDepth: DefaultSpriteLayerDepths.ProjectilesLayer,
                scale: Constants.UniversalScale);
        }

        public static ISprite CreateBombSprite()
        {
            return new BombSprite(
                TextureMap["ProjectilesSprites"], SpriteBatch,
                textureStartingY: 32,
                layerDepth: DefaultSpriteLayerDepths.ItemsLayer,
                scale: Constants.UniversalScale);
        }


    }
}
