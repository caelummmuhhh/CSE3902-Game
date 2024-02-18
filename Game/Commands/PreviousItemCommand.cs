using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System.Collections.Generic;

using MainGame.SpriteHandlers;
using MainGame.Players;
using MainGame.Blocks;
using MainGame.Items;

namespace MainGame.Commands
{
    public class PreviousItemCommand: ICommand
    {
        private Game game;
        private Player player;
        private int currentItemIndex;
        private List<ISprite> items;
        private Item item;

        public PreviousItemCommand(Game game, Player player, Block block, List<ISprite> blocks, Item item, List<ISprite> items)
        {
            this.game = game;
            this.item = item;
            this.items = items;
            currentItemIndex = 0;
        }

        public void Execute()
        {
            currentItemIndex = (currentItemIndex - 1 + items.Count) % items.Count;
            item.Sprite = items[currentItemIndex];
            UnExecute();
        }

        public void UnExecute()
        {
            item.Position = new Vector2(
                game.GraphicsDevice.Viewport.Width / 3*2,
                game.GraphicsDevice.Viewport.Height / 3
            );        
        }

        public ISprite GetCurrentBlock()
        {
            return items[currentItemIndex];
        }
    }
}
