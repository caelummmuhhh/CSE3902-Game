using System; 

namespace MainGame.SpriteHandlers
{
    public enum BlockSpriteTypes
    {
        BlueFloor,
        SquareBlock,
        StatueOneEntrance,
        StatueTwoEntrance,
        StatueOneEnd,
        StatueTwoEnd,
        BlackSquare,
        BlueSand,
        BlueGap,
        Stairs,
        WhiteBrick,
        WhiteLadder
    }

    public static partial class SpriteFactory
    {
        public static ISprite CreateBlock(BlockSpriteTypes block)
        {
            return block switch
            {
                BlockSpriteTypes.BlueFloor => CreateBlueFloorSprite(),
                BlockSpriteTypes.SquareBlock => CreateSquareBlockSprite(),
                BlockSpriteTypes.StatueOneEntrance => CreateStatueOneEntranceSprite(),
                BlockSpriteTypes.StatueTwoEntrance => CreateStatueTwoEntranceSprite(),
                BlockSpriteTypes.StatueOneEnd => CreateStatueOneEndSprite(),
                BlockSpriteTypes.StatueTwoEnd => CreateStatueTwoEndSprite(),
                BlockSpriteTypes.BlackSquare => CreateBlackSquareSprite(),
                BlockSpriteTypes.BlueSand => CreateBlueSandSprite(),
                BlockSpriteTypes.BlueGap => CreateBlueGapSprite(),
                BlockSpriteTypes.Stairs => CreateStairsSprite(),
                BlockSpriteTypes.WhiteBrick => CreateWhiteBrickSprite(),
                BlockSpriteTypes.WhiteLadder => CreateWhiteLadderSprite(),
                _ => null,
            };
        }

        /// <summary>
        /// Tries to create a block sprite based on given block name.
        /// </summary>
        /// <param name="blockName">The name of the block.</param>
        /// <returns>The ISprite object created based on the given block name</returns>
        /// <exception cref="ArgumentException">The block name does not match to a block.</exception>
        public static ISprite CreateBlock(string blockName)
        {
            bool conversionSuccess = Enum.TryParse(blockName, out BlockSpriteTypes block);

            if (!conversionSuccess)
            {
                throw new ArgumentException("Unable to parse block name string into a block.");
            }

            return CreateBlock(block);
        }


        /* Create methods for each individual sprite. */

        public static ISprite CreateBlueFloorSprite()
        {
            return new BlockSprites.BlockSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 0,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateSquareBlockSprite()
        {
            return new BlockSprites.BlockSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 16,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateStatueOneEntranceSprite()
        {
            return new BlockSprites.BlockSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 32,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateStatueTwoEntranceSprite()
        {
            return new BlockSprites.BlockSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 48,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateStatueOneEndSprite()
        {
            return new BlockSprites.BlockSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 64,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateStatueTwoEndSprite()
        {
            return new BlockSprites.BlockSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 80,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateBlackSquareSprite()
        {
            return new BlockSprites.BlockSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 96,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateBlueSandSprite()
        {
            return new BlockSprites.BlockSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 112,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateBlueGapSprite()
        {
            return new BlockSprites.BlockSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 128,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateStairsSprite()
        {
            return new BlockSprites.BlockSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 144,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateWhiteBrickSprite()
        {
            return new BlockSprites.BlockSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 160,
                scale: UniversalScaleMultiplier);
        }

        public static ISprite CreateWhiteLadderSprite()
        {
            return new BlockSprites.BlockSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: 176,
                scale: UniversalScaleMultiplier);
        }
    }
}