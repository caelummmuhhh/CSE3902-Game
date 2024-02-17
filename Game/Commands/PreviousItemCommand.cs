using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System.Collections.Generic;

using MainGame.SpriteHandlers;
using MainGame.Players;

namespace MainGame.Commands
{
    public class PreviousItemCommand: ICommand
    {
        private Game game;
        private Player player;
        private int currentItemIndex;
        private List<ISprite> items;

        public PreviousItemCommand(Game game, Player player, List<ISprite> blocks,List<ISprite> items)
        {
            this.game = game;
            this.items = items;
            currentItemIndex = 0;
        }

        public void Execute()
        {
            currentItemIndex = (currentItemIndex - 1 + items.Count) % items.Count;
        }

        public void UnExecute()
        {
            currentItemIndex = (currentItemIndex + 1) % items.Count;
        }

        public ISprite GetCurrentBlock()
        {
            return items[currentItemIndex];
        }
    }
}