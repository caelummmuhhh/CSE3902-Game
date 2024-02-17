using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MainGame.SpriteHandlers.ItemSprites;

namespace MainGame.SpriteHandlers
{
    public static partial class SpriteFactory
    {
        public static ISprite CreateHeartItemSprite()
        {
            return new HeartItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateHeartContainerItemSprite()
        {
            return new HeartContainerItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 16,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateClockItemSprite()
        {
            return new ClockItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 32,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateFiveRupeesItemSprite()
        {
            return new FiveRupeesItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 48,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateRupeeItemSprite()
        {
            return new RupeeItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                textureStartingY: 48,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateMapItemSprite()
        {
            return new MapItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 64,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateWoodenBoomerangItemSprite()
        {
            return new WoodenBoomerangItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 80,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateBombItemSprite()
        {
            return new BombItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 96,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateBowItemSprite()
        {
            return new BowItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 112,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateArrowItemSprite()
        {
            return new ArrowItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 128,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateKeyItemSprite()
        {
            return new KeyItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 144,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateCompassItemSprite()
        {
            return new CompassItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                textureStartingY: 160,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateTriforcePieceItemSprite()
        {
            return new TriforcePieceItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                textureStartingY: 176,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateFairyItemSprite()
        {
            return new FairyItemSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                textureStartingY: 192,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateFireSprite()
        {
            return new FireSprite(
                TextureMap["ItemsSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 1,
                numberOfFrames: 1,
                textureStartingY: 208,
                scale: UniversalScaleMultiplier);

        }
    }
}
