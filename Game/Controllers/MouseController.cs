using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MainGame.Commands;
using MainGame.Players;
using MainGame.SpriteHandlers;

namespace MainGame.Controllers
{
	public class MouseController : IController
	{
        private readonly IPlayer player;
        private readonly Game1 game;
        private readonly int screenWidth;
        private readonly int screenHeight;
        
        public MouseController(Game1 game, IPlayer player)
		{
            this.game = game;
            this.player = player;

            screenWidth = game.GraphicsDevice.Viewport.Width;
            screenHeight = game.GraphicsDevice.Viewport.Height;
        }

        public void Update()
        {
            MouseState mouseState = Mouse.GetState();
            ICommand command;
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (mouseState.X < 2 * Constants.BlockSize)
                {
                    command = new ChangeRoomWestCommand(game);
                    command.Execute();
                }
                if (mouseState.X > 14 * Constants.BlockSize)
                {
                    command = new ChangeRoomEastCommand(game);
                    command.Execute();
                }
                if (mouseState.Y < 2 * Constants.BlockSize + Constants.HudAndMenuHeight)
                {
                    command = new ChangeRoomNorthCommand(game);
                    command.Execute();
                }
                if (mouseState.Y > 9 * Constants.BlockSize + Constants.HudAndMenuHeight)
                {
                    command = new ChangeRoomSouthCommand(game);
                    command.Execute();
                }
            } 
        }
    }
}

