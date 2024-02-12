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
                { Keys.Q, new QuitGameCommand(game) },
                { Keys.W, new linkMovingUpCommand(game, player) },
                { Keys.S, new linkMovingDownCommand(game, player) },
                { Keys.D, new linkMovingRightCommand(game, player) },
                { Keys.A, new linkMovingLeftCommand(game, player) }
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
                else
                {
                    keyCommands[key].UnExecute();
                }
            }
        }
    }
}

