namespace MainGame.SpriteHandlers
{
    public enum BlockTypes
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
        public static ISprite CreateBlock(BlockTypes block)
        {
            var spriteStartingYPos = block switch
            {
                BlockTypes.BlueFloor => 0,
                BlockTypes.SquareBlock => 16,
                BlockTypes.StatueOneEntrance => 32,
                BlockTypes.StatueTwoEntrance => 48,
                BlockTypes.StatueOneEnd => 64,
                BlockTypes.StatueTwoEnd => 80,
                BlockTypes.BlackSquare => 96,
                BlockTypes.BlueSand => 112,
                BlockTypes.BlueGap => 128,
                BlockTypes.Stairs => 144,
                BlockTypes.WhiteBrick => 160,
                BlockTypes.WhiteLadder => 176,
                _ => 0,
            };

            return new BlockSprites.BlockSprite(
                TextureMap["BlocksSprites"], SpriteBatch,
                textureStartingY: spriteStartingYPos,
                scale: UniversalScaleMultiplier);
        }
    }
}
