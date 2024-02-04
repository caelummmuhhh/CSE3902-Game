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
        private readonly Player player;
        private readonly Game game;
        private readonly int screenWidth;
        private readonly int screenHeight;
        
        public MouseController(Game game, Player player)
		{
            this.game = game;
            this.player = player;

            screenWidth = game.GraphicsDevice.Viewport.Width;
            screenHeight = game.GraphicsDevice.Viewport.Height;
        }

        public void Update()
        {
            MouseState mouseState = Mouse.GetState();
            ICommand command = null;

            if (mouseState.RightButton == ButtonState.Pressed)
            {
                command = new QuitGameCommand(game);
                command.Execute();
            }

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                int x = mouseState.X;
                int y = mouseState.Y;

                if (x < screenWidth / 2 && y < screenHeight / 2)
                {
                    command = new StationaryStaticSpriteCommand(game, player);
                }
                else if (x > screenWidth / 2 && y < screenHeight / 2)
                {
                    command = new StationaryAnimatedSpriteCommand(game, player);
                }
                else if (x < screenWidth / 2 && y > screenHeight / 2)
                {
                    command = new MovingStaticSpriteCommand(game, player);
                }
                else if (x > screenWidth / 2 && y > screenHeight / 2)
                {
                    command = new MovingAnimatedSpriteCommand(game, player);
                }
            }

            if (command != null)
            {
                command.Execute();
            }
        }
    }
}

