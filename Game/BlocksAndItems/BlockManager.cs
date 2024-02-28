using System.Collections.Generic;
using MainGame.SpriteHandlers;

namespace MainGame.Managers
{
    public class BlockManager
    {
        private List<ISprite> blocks;

        public BlockManager()
        {
            blocks = new List<ISprite>();
        }

        public void LoadBlocks()
        {
            blocks.Add(SpriteFactory.CreateBlock(BlockTypes.BlueFloor));
            blocks.Add(SpriteFactory.CreateBlock(BlockTypes.SquareBlock));
            blocks.Add(SpriteFactory.CreateBlock(BlockTypes.StatueOneEntrance));
            blocks.Add(SpriteFactory.CreateBlock(BlockTypes.StatueTwoEntrance));
            blocks.Add(SpriteFactory.CreateBlock(BlockTypes.StatueOneEnd));
            blocks.Add(SpriteFactory.CreateBlock(BlockTypes.StatueTwoEnd));
            blocks.Add(SpriteFactory.CreateBlock(BlockTypes.BlackSquare));
            blocks.Add(SpriteFactory.CreateBlock(BlockTypes.BlueSand));
            blocks.Add(SpriteFactory.CreateBlock(BlockTypes.BlueGap));
            blocks.Add(SpriteFactory.CreateBlock(BlockTypes.Stairs));
            blocks.Add(SpriteFactory.CreateBlock(BlockTypes.WhiteBrick));
            blocks.Add(SpriteFactory.CreateBlock(BlockTypes.WhiteLadder));
        }

        public List<ISprite> GetBlocks()
        {
            return blocks;
        }
    }
}