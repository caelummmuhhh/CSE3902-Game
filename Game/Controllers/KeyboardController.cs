﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MainGame.Commands;
using MainGame.Players;
using MainGame.SpriteHandlers;

namespace MainGame.Controllers
{
	public class KeyboardController : IController
	{
        private Dictionary<Keys, ICommand> keyCommands;
		private readonly Player player;
		private readonly Game game;

        public KeyboardController(Game game, Player player)
		{
			this.game = game;
			this.player = player;

			keyCommands = new()
			{
                { Keys.D0, new QuitGameCommand(game) },
                { Keys.D1, new StationaryStaticSpriteCommand(game, player) },
                { Keys.D2, new StationaryAnimatedSpriteCommand(game, player) },
                { Keys.D3, new MovingStaticSpriteCommand(game, player) },
                { Keys.D4, new MovingAnimatedSpriteCommand(game, player) }

            };
        }

		public void Update()
		{
            KeyboardState keyState = Keyboard.GetState();

            foreach (Keys key in keyCommands.Keys)
            {
                if (keyState.IsKeyDown(key))
                {
                    keyCommands[key].Execute();
                }
            }
        }
    }
}
