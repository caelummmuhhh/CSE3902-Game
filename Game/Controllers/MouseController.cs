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
        private readonly Game game;
        private readonly int screenWidth;
        private readonly int screenHeight;
        
        public MouseController(Game game, IPlayer player)
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
        }
    }
}

