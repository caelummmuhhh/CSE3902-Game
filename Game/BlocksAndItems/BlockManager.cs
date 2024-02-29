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
            blocks.Add(SpriteFactory.CreateBlock("BlueFloor"));
            blocks.Add(SpriteFactory.CreateBlock(BlockSpriteTypes.SquareBlock));
            blocks.Add(SpriteFactory.CreateBlock(BlockSpriteTypes.StatueOneEntrance));
            blocks.Add(SpriteFactory.CreateBlock(BlockSpriteTypes.StatueTwoEntrance));
            blocks.Add(SpriteFactory.CreateBlock(BlockSpriteTypes.StatueOneEnd));
            blocks.Add(SpriteFactory.CreateBlock(BlockSpriteTypes.StatueTwoEnd));
            blocks.Add(SpriteFactory.CreateBlock(BlockSpriteTypes.BlackSquare));
            blocks.Add(SpriteFactory.CreateBlock(BlockSpriteTypes.BlueSand));
            blocks.Add(SpriteFactory.CreateBlock(BlockSpriteTypes.BlueGap));
            blocks.Add(SpriteFactory.CreateBlock(BlockSpriteTypes.Stairs));
            blocks.Add(SpriteFactory.CreateBlock(BlockSpriteTypes.WhiteBrick));
            blocks.Add(SpriteFactory.CreateBlock(BlockSpriteTypes.WhiteLadder));
        }

        public List<ISprite> GetBlocks()
        {
            return blocks;
        }
    }
}