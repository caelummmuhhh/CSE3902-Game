using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

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
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateStalfosSprite()
        {
            return new EnemySprites.StalfosSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 1,
                numberOfFrames: 1,
                textureStartingY: 16,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateGelSprite()
        {
            return new EnemySprites.GelSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                textureStartingY: 32,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateWallMasterSprite()
        {
            return new EnemySprites.WallMasterSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                textureStartingY: 96,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateOldManSprite()
        {
            return new EnemySprites.OldManSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                textureStartingX: 0,
                textureStartingY: 112,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateSpikeCrossSprite()
        {
            return new EnemySprites.SpikeCrossSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                textureStartingY: 128,
                scale: UniversalScaleMultiplier);
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
                scale: UniversalScaleMultiplier);
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
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateGoriyaWalkingUpSprite()
        {
            return new EnemySprites.GoriyaWalkingUpSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 1,
                numberOfFrames: 1,
                textureStartingY: 64,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateGoriyaWalkingDownSprite()
        {
            return new EnemySprites.GoriyaWalkingDownSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                textureStartingY: 48,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateGoriyaWalkingLeftSprite()
        {
            return new EnemySprites.GoriyaWalkingLeftSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                textureStartingY: 80,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateGoriyaWalkingRightSprite()
        {
            return new EnemySprites.GoriyaWalkingRightSprite(
                TextureMap["EnemiesSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                textureStartingY: 80,
                scale: UniversalScaleMultiplier);
        }
    }
}
