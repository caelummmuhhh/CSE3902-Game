﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MainGame.SpriteHandlers;
using MainGame.Players;

namespace MainGame.Commands
{
	public class StationaryStaticSpriteCommand : ICommand
    {
		private Game game;
		private Player player;

		public StationaryStaticSpriteCommand(Game game, Player player)
        {
            this.game = game;
            this.player = player;
        }

		public void Execute()
		{
            player.Sprite = SpriteFactory.CreatePlayerStaticIdleSprite();
            UnExecute();
            player.HorizontalMotionOn = false;
            player.VerticalMotionOn = false;
        }

        public void UnExecute()
		{
            player.Position = new Vector2(
                game.GraphicsDevice.Viewport.Width / 2,
                game.GraphicsDevice.Viewport.Height / 2
            );
        }
    }
}

