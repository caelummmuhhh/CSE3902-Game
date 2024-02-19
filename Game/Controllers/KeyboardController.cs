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
        private List<ICommand> executingCommands;
		private readonly Player player;
		private readonly Game game;

        public KeyboardController(Game game, Player player)
		{
			this.game = game;
			this.player = player;
            executingCommands = new();
            keyCommands = new()
            {
                { Keys.D0, new QuitGameCommand(game) },

                { Keys.W, new PlayerMoveUpCommand(player) },
                { Keys.A, new PlayerMoveLeftCommand(player) },
                { Keys.S, new PlayerMoveDownCommand(player) },
                { Keys.D, new PlayerMoveRightCommand(player) },

                { Keys.N, new PlayerUseSwordCommand(player) }
            };
        }

		public void Update()
		{
            KeyboardState keyState = Keyboard.GetState();

            foreach (Keys key in keyCommands.Keys)
            {
                if (keyState.IsKeyDown(key) && !executingCommands.Contains(keyCommands[key]))
                {
                    executingCommands.Add(keyCommands[key]);
                }
                else if (!keyState.IsKeyDown(key) && executingCommands.Contains(keyCommands[key]))
                {
                    keyCommands[key].UnExecute();
                    executingCommands.Remove(keyCommands[key]);
                }
            }
            ExecuteCommands();
        }

        private void ExecuteCommands()
        {
            if (executingCommands.Count > 0)
            {
                executingCommands[^1].Execute();
            }
        }
    }
}

