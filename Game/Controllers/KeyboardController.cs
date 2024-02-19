using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MainGame.Commands;
using MainGame.Commands.PlayerCommands;
using MainGame.Players;
using MainGame.SpriteHandlers;

namespace MainGame.Controllers
{
	public class KeyboardController : IController
	{
        private Dictionary<Keys, ICommand> keyCommands;
        private ICommand currentCommand;
		private readonly Player player;
		private readonly Game game;

        public KeyboardController(Game game, Player player)
		{
			this.game = game;
			this.player = player;
            currentCommand = null;
            keyCommands = new()
            {
                { Keys.D0, new QuitGameCommand(game) },
                { Keys.W, new PlayerMoveUpCommand(player) },
                { Keys.A, new PlayerMoveLeftCommand(player) },
                { Keys.S, new PlayerMoveDownCommand(player) },
                { Keys.D, new PlayerMoveRightCommand(player) }
            };
        }

		public void Update()
		{
            KeyboardState keyState = Keyboard.GetState();

            foreach (Keys key in keyCommands.Keys)
            {
                if (keyState.IsKeyDown(key))
                {
                    currentCommand = keyCommands[key];
                    keyCommands[key].Execute();
                }
                else if (currentCommand == keyCommands[key])
                {
                    currentCommand.UnExecute();
                }
            }
        }
    }
}

