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
	public class PlayKeyboardController : IController
	{
        private readonly Dictionary<Keys, ICommand> playCommands;
        private readonly Dictionary<Keys, ICommand> menuCommands;
        private readonly List<ICommand> executingCommands;
		private readonly PlayGameState gameState;
        private int openMenuDebounce = 15;

        public PlayKeyboardController(Game1 game, PlayGameState gameState, IPlayer player)
		{
			this.gameState = gameState;
            executingCommands = new();
            playCommands = new()
            {
                { Keys.Q, new QuitGameCommand(game) },
                { Keys.R, new ResetGameCommand(game) },

                { Keys.W, new PlayerMoveUpCommand(player) },
                { Keys.A, new PlayerMoveLeftCommand(gameState) },
                { Keys.S, new PlayerMoveDownCommand(player) },
                { Keys.D, new PlayerMoveRightCommand(gameState) },

                { Keys.K, new PlayerUseSwordCommand(player) },
                { Keys.J, new PlayerUseItemCommand(player) },

                { Keys.E, new PlayerDamageCommand(gameState) }, // TODO: delete in final

                { Keys.D1, new PlayerObtainBoomerangCommand(player) },
                { Keys.D2, new PlayerObtainBombCommand(player) },
                { Keys.D3, new PlayerObtainArrowCommand(player) },
                { Keys.D4, new PlayerObtainBowCommand(player) },
                { Keys.D5, new PlayerObtainCandleCommand(player) },
                { Keys.D6, new PlayerObtainRupeesCommand(player) },
                { Keys.D7, new PlayerMaxHealthCommand(player) },

                { Keys.P, new PauseMenuCommand(gameState) },
                { Keys.M, new MuteMusicCommand(game) },
                { Keys.Escape, new SwitchToMenuStateCommand(game) }
            };

            menuCommands = new()
            {
                { Keys.Q, playCommands[Keys.Q] },
                { Keys.A, new MoveItemSelectLeftCommand(gameState) },
                { Keys.D, new MoveItemSelectRightCommand(gameState) },
                { Keys.P, playCommands[Keys.P] },
                { Keys.M, playCommands[Keys.M] },
                { Keys.Escape, playCommands[Keys.Escape] }
            };
        }

        public void Update()
		{
            openMenuDebounce = openMenuDebounce > 0 ? openMenuDebounce - 1 : 0;

            KeyboardState keyState = Keyboard.GetState();
            List<ICommand> unexecuteCommands = new();

            Dictionary<Keys, ICommand> detectKeys = gameState.TogglePause ? menuCommands : playCommands;

            foreach (Keys key in detectKeys.Keys)
            {
                if (key is Keys.Escape)
                {
                    if (keyState.IsKeyDown(key) && openMenuDebounce <= 0)
                    {
                        openMenuDebounce = 15;
                        Console.WriteLine("In play state. Switching to menu.");
                        detectKeys[key].Execute();
                    }
                    continue;
                }

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