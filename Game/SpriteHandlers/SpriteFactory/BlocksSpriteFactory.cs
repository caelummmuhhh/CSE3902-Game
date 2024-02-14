using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MainGame.SpriteHandlers
{
    public static partial class SpriteFactory
    {
        public static ISprite CreateBlueFloorSprite()
        {
            return new BlockSprites.BlueFloorSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 0,
                scale: 2
                );
        }

        public static ISprite CreateSquareBlockSprite()
        {
            return new BlockSprites.SquareBlockSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 16,
                scale: 2
                );
        }

        public static ISprite CreateStatueOneEntranceSprite()
        {
            return new BlockSprites.StatueOneEntranceSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 32,
                scale: 2
                );
        }

        public static ISprite CreateStatueTwoEntranceSprite()
        {
            return new BlockSprites.StatueTwoEntranceSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 48,
                scale: 2
                );
        }

        public static ISprite CreateStatueOneEndSprite()
        {
            return new BlockSprites.StatueOneEndSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 64,
                scale: 2
                );
        }

        public static ISprite CreateStatueTwoEndSprite()
        {
            return new BlockSprites.StatueTwoEndSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 80,
                scale: 2
                );
        }

        public static ISprite CreateBlackSquareSprite()
        {
            return new BlockSprites.BlackSquareSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 96,
                scale: 2
                );
        }

        public static ISprite CreateBlueSandSprite()
        {
            return new BlockSprites.BlueSandSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 112,
                scale: 2
                );
        }

        public static ISprite CreateBlueGapSprite()
        {
            return new BlockSprites.BlueGapSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 128,
                scale: 2
                );
        }

        public static ISprite CreateStairsSprite()
        {
            return new BlockSprites.StairsSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 144,
                scale: 2
                );
        }

        public static ISprite CreateWhiteBrickSprite()
        {
            return new BlockSprites.WhiteBrickSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 160,
                scale: 2
                );
        }

        public static ISprite CreateWhiteLadderSprite()
        {
            return new BlockSprites.WhiteLadderSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 176,
                scale: 2
                );
        }
    }
}
