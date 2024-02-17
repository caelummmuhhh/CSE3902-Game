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
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateArrowUpProjectileSprite()
        {
            return new ArrowUpProjectileSprite(
                TextureMap["ProjectilesSprites"], SpriteBatch,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateArrowLeftProjectileSprite()
        {
            return new ArrowLeftProjectileSprite(
                TextureMap["ProjectilesSprites"], SpriteBatch,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateArrowRightProjectileSprite()
        {
            return new ArrowRightProjectileSprite(
                TextureMap["ProjectilesSprites"], SpriteBatch,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateArrowProjectileHitSprite()
        {
            return new ArrowProjectileHitSprite(
                TextureMap["ProjectilesSprites"], SpriteBatch,
                textureStartingX: 16,
                scale: UniversalScaleMultiplier);
        }



        public static ISprite CreateSwordBeamDownProjectileSprite()
        {
            return new SwordBeamDownProjectileSprite(
                TextureMap["ProjectilesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                numberOfFrames: 4,
                textureStartingY: 48,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateSwordBeamUpProjectileSprite()
        {
            return new SwordBeamUpProjectileSprite(
                TextureMap["ProjectilesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                numberOfFrames: 4,
                textureStartingY: 48,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateSwordBeamLeftProjectileSprite()
        {
            return new SwordBeamLeftProjectileSprite(
                TextureMap["ProjectilesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                numberOfFrames: 4,
                textureStartingY: 48,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateSwordBeamRightProjectileSprite()
        {
            return new SwordBeamRightProjectileSprite(
                TextureMap["ProjectilesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                numberOfFrames: 4,
                textureStartingY: 48,
                scale: UniversalScaleMultiplier);
        }



        public static ISprite CreateWoodenBoomerangSprite()
        {
            return new WoodenBoomerangSprite(
                TextureMap["ProjectilesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 3,
                numberOfFrames: 3,
                textureStartingY: 16,
                scale: UniversalScaleMultiplier);

        }

        public static ISprite CreateBombSprite()
        {
            return new BombSprite(
                TextureMap["ProjectilesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                numberOfFrames: 4,
                textureStartingY: 32,
                scale: UniversalScaleMultiplier);
        }


        public static ISprite CreateAquamentusAttackSprite()
        {
            return new AquamentusAttackProjectileSprite(
                TextureMap["ProjectilesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 4,
                numberOfFrames: 4,
                textureStartingY: 64,
                scale: UniversalScaleMultiplier);
        }
    }
}
