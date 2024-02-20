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
    public class NextItemCommand: ICommand
    {
        private Game game;
        private Player player;
        private List<ISprite> items;
        private Item item;


        public NextItemCommand(Game game, Block block, List<ISprite> blocks, Item item, List<ISprite> items)
        {
            this.game = game;
            this.item = item;
            this.items = items;
        }

        public void Execute()
        {
            GlobalCounters.CurrentItemIndex = (GlobalCounters.CurrentItemIndex + 1) % items.Count;
            item.Sprite = items[GlobalCounters.CurrentItemIndex];
            UnExecute();
        }

        public void UnExecute()
        {
            item.Position = new Vector2(
                game.GraphicsDevice.Viewport.Width / 3*2,
                game.GraphicsDevice.Viewport.Height / 3
            );        }

        public ISprite GetCurrentBlock()
        {
            return items[GlobalCounters.CurrentItemIndex];
        }
    }
}