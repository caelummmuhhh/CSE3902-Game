using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System.Collections.Generic;

using MainGame.SpriteHandlers;
using MainGame.Players;

namespace MainGame.Commands
{
    public class NextBlockCommand : ICommand
    {
        private Game game;
        private Player player;
        private int currentBlockIndex;
        private List<ISprite> blocks;

        public NextBlockCommand(Game game, Player player, List<ISprite> blocks)
        {
            this.game = game;
            this.blocks = blocks;
            currentBlockIndex = 0;
        }

        public void Execute()
        {
            currentBlockIndex = (currentBlockIndex + 1) % blocks.Count;
        }

        public void UnExecute()
        {
            currentBlockIndex = (currentBlockIndex - 1 + blocks.Count) % blocks.Count;
        }

        public ISprite GetCurrentBlock()
        {
            return blocks[currentBlockIndex];
        }
    }
}