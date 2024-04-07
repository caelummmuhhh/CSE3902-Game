using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.BlocksAndItems
{
	public static class BlockFactory
	{
		public static IBlock CreateBlock(BlockTypes block, Vector2 position)
		{
            ISprite blockSprite = SpriteFactory.CreateBlockSprite(block);
            return block switch
            {
                BlockTypes.BlueFloor => new Block(position, blockSprite, false),
                BlockTypes.BlackSquare => new Block(position, blockSprite, false),
                BlockTypes.BlueSand => new Block(position, blockSprite, false),
                BlockTypes.Stairs => new Block(position, blockSprite, false),
                BlockTypes.WhiteLadder => new Block(position, blockSprite, false),
                BlockTypes.PushableBlock => new PushableBlock(position, blockSprite),
                _ => new Block(position, blockSprite, true)
            };
        }

        /// <summary>
        /// Tries to create a block based on given block name.
        /// </summary>
        /// <param name="blockName">The name of the block.</param>
        /// <param name="position">The position of the block (top left corner)</param>
        /// <returns>The ISprite object created based on the given block name</returns>
        /// <exception cref="ArgumentException">The block name does not match to a block.</exception>
        public static IBlock CreateBlock(string blockName, Vector2 position)
        {
            bool conversionSuccess = Enum.TryParse(blockName, true, out BlockTypes block);

            if (!conversionSuccess)
            {
                throw new ArgumentException("Unable to parse block name string into a block.");
            }

            return CreateBlock(block, position);
        }

    }
}

