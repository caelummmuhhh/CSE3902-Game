using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using MainGame.Commands;
using MainGame.Commands.PlayerCommands;
using MainGame.Commands.MenuCommands;
using MainGame.Players;
using System;

namespace MainGame.Controllers
{
	public class KeyboardController : IController
	{
        private readonly Dictionary<Keys, ICommand> playCommands;
        private readonly Dictionary<Keys, ICommand> menuCommands;
        private readonly List<ICommand> executingCommands;
		private readonly IPlayer player;
		private readonly Game1 game;

        public KeyboardController(Game1 game, IPlayer player)
		{
			this.game = game;
			this.player = player;
            executingCommands = new();
            playCommands = new()
            {
                { Keys.Q, new QuitGameCommand(game) },
                { Keys.R, new ResetGameCommand(game) },

                { Keys.W, new PlayerMoveUpCommand(player) },
                { Keys.A, new PlayerMoveLeftCommand(game) },
                { Keys.S, new PlayerMoveDownCommand(player) },
                { Keys.D, new PlayerMoveRightCommand(game) },

                { Keys.K, new PlayerUseSwordCommand(player) },
                { Keys.J, new PlayerUseItemCommand(player) },

                { Keys.E, new PlayerDamageCommand(game) }, // TODO: delete in final

                { Keys.D1, new PlayerObtainBoomerangCommand(player) },
                { Keys.D2, new PlayerObtainBombCommand(player) },
                { Keys.D3, new PlayerObtainArrowCommand(player) },
                { Keys.D4, new PlayerObtainBowCommand(player) },
                { Keys.D5, new PlayerObtainCandleCommand(player) },
                { Keys.D6, new PlayerObtainRupeesCommand(player) },
                { Keys.D7, new PlayerMaxHealthCommand(player) },

                { Keys.Up, new NextRoomCommand(game) },

                { Keys.P, new PauseMenuCommand(game) },
                { Keys.M, new MuteMusicCommand(game) },
            };

            menuCommands = new()
            {
                { Keys.Q, playCommands[Keys.Q] },
                { Keys.A, new MoveItemSelectLeftCommand(game) },
                { Keys.D, new MoveItemSelectRightCommand(game) },
                { Keys.P, playCommands[Keys.P] },
                { Keys.M, playCommands[Keys.M] }
            };
        }

        public void Update()
		{
            KeyboardState keyState = Keyboard.GetState();
            List<ICommand> unexecuteCommands = new();

            Dictionary<Keys, ICommand> detectKeys = game.TogglePause ? menuCommands : playCommands;

            foreach (Keys key in detectKeys.Keys)
            {
                if (keyState.IsKeyDown(key) && !executingCommands.Contains(detectKeys[key]))
                {
                    executingCommands.Add(detectKeys[key]);
                }
                else if (!keyState.IsKeyDown(key) && executingCommands.Contains(detectKeys[key]))
                {
                    executingCommands.Remove(detectKeys[key]);
                    unexecuteCommands.Add(detectKeys[key]);
                }
            }

            if (executingCommands.Count == 0)
            {
                // it is only necessary to stop commands/unexecute when there are no commands to execute
                UnExecuteCommands(unexecuteCommands);
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

        private static void UnExecuteCommands(List<ICommand> commands)
        {
            foreach (ICommand command in commands)
            {
                command.UnExecute();
            }
        }
    }
}