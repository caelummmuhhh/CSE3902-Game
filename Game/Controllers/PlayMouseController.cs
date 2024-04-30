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
	public class PlayMouseController : IController
	{
        private readonly IPlayer player;
        private readonly Game1 game;
        private readonly PlayGameState gameState;
        private readonly int screenWidth;
        private readonly int screenHeight;
        
        public PlayMouseController(Game1 game, PlayGameState gameState, IPlayer player)
		{
            this.game = game;
            this.gameState = gameState;
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
                if (mouseState.X < 0 || mouseState.Y < Constants.HudAndMenuHeight || mouseState.X > screenWidth || mouseState.Y > screenHeight) return;

                if (mouseState.X < 2 * Constants.BlockSize)
                {
                    command = new ChangeRoomWestCommand(gameState);
                    command.Execute();
                }
                if (mouseState.X > 14 * Constants.BlockSize)
                {
                    command = new ChangeRoomEastCommand(gameState);
                    command.Execute();
                }
                if (mouseState.Y < 2 * Constants.BlockSize + Constants.HudAndMenuHeight)
                {
                    command = new ChangeRoomNorthCommand(gameState);
                    command.Execute();
                }
                if (mouseState.Y > 9 * Constants.BlockSize + Constants.HudAndMenuHeight)
                {
                    command = new ChangeRoomSouthCommand(gameState);
                    command.Execute();
                }
            } 
        }
    }
}

