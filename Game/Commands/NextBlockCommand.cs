using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System.Collections.Generic;

using MainGame.SpriteHandlers;
using MainGame.Players;
using MainGame.Blocks;

namespace MainGame.Commands
{
    public class NextBlockCommand : ICommand
    {
        private Game game;
        private Player player;
        private int currentBlockIndex;
        private List<ISprite> blocks;

        private Block block;

        public NextBlockCommand(Game game, Player player, Block block, List<ISprite> blocks)
        {
            this.game = game;
            this.block = block;
            this.blocks = blocks;
            currentBlockIndex = 0;
        }

        public void Execute()
        {
            currentBlockIndex = (currentBlockIndex + 1) % blocks.Count;
            block.Sprite = blocks[currentBlockIndex];
            UnExecute();
        }

        public void UnExecute()
        {
            block.Position = new Vector2(
                game.GraphicsDevice.Viewport.Width / 3,
                game.GraphicsDevice.Viewport.Height / 3
            );        }

        public ISprite GetCurrentBlock()
        {
            return blocks[currentBlockIndex];
        }
    }
}