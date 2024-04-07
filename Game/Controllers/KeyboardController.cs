using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using MainGame.Commands;
using MainGame.Commands.PlayerCommands;
using MainGame.Players;

namespace MainGame.Controllers
{
	public class KeyboardController : IController
	{
        private readonly Dictionary<Keys, ICommand> keyCommands;
        private readonly List<ICommand> executingCommands;
		private readonly IPlayer player;
		private readonly Game game;

        public KeyboardController(Game1 game, IPlayer player)
		{
			this.game = game;
			this.player = player;
            executingCommands = new();
            keyCommands = new()
            {
                { Keys.Q, new QuitGameCommand(game) },
                { Keys.R, new ResetGameCommand(game) },

                { Keys.W, new PlayerMoveUpCommand(player) },
                { Keys.A, new PlayerMoveLeftCommand(player) },
                { Keys.S, new PlayerMoveDownCommand(player) },
                { Keys.D, new PlayerMoveRightCommand(player) },

                { Keys.N, new PlayerUseSwordCommand(player) },
                { Keys.Z, new PlayerUseSwordBeamCommand(player) },

                { Keys.E, new PlayerDamageCommand(game) },

                { Keys.D1, new PlayerUseBombCommand(player) },
                { Keys.D2, new PlayerUseArrowCommand(player) },
                { Keys.D3, new PlayerUseBoomerangCommand(player) },
                { Keys.D4, new PlayerUseFireCommand(player) },

                { Keys.Up, new NextRoomCommand(game) },
            };
        }

        public void Update()
		{
            KeyboardState keyState = Keyboard.GetState();
            List<ICommand> unexecuteCommands = new();

            foreach (Keys key in keyCommands.Keys)
            {
                if (keyState.IsKeyDown(key) && !executingCommands.Contains(keyCommands[key]))
                {
                    executingCommands.Add(keyCommands[key]);
                }
                else if (!keyState.IsKeyDown(key) && executingCommands.Contains(keyCommands[key]))
                {
                    executingCommands.Remove(keyCommands[key]);
                    unexecuteCommands.Add(keyCommands[key]);
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