using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MainGame.Commands;
using MainGame.Commands.PlayerCommands;
using MainGame.Players;
using MainGame.Blocks;
using MainGame.Items;

using MainGame.SpriteHandlers;

namespace MainGame.Controllers
{
	public class KeyboardController : IController
	{
        private Dictionary<Keys, ICommand> keyCommands;
        private KeyboardState previousKeyState;
        private List<ICommand> executingCommands;
		private readonly IPlayer player;
		private readonly Game game;

        public KeyboardController(Game1 game, IPlayer player, Block block, List<ISprite> blocks, Item item, List<ISprite> items)
		{
			this.game = game;
			this.player = player;
            executingCommands = new();
            keyCommands = new()
            {
                { Keys.Q, new QuitGameCommand(game) },
                { Keys.R, new ResetGameCommand(game) },
                { Keys.T, new PreviousBlockCommand(game, block, blocks) },
                { Keys.Y, new NextBlockCommand(game, block, blocks) },
                { Keys.U, new PreviousItemCommand(game, block, blocks, item, items) },
                { Keys.I, new NextItemCommand(game, block, blocks, item, items) },

                { Keys.W, new PlayerMoveUpCommand(player) },
                { Keys.A, new PlayerMoveLeftCommand(player) },
                { Keys.S, new PlayerMoveDownCommand(player) },
                { Keys.D, new PlayerMoveRightCommand(player) },

                { Keys.N, new PlayerUseSwordCommand(player) },
                { Keys.Z, new PlayerUseSwordBeamCommand(player) },

                { Keys.E, new PlayerDamageCommand(player) },

                { Keys.D1, new PlayerUseBombCommand(player) },
                { Keys.D2, new PlayerUseArrowCommand(player) },
                { Keys.D3, new PlayerUseBoomerangCommand(player) },
                { Keys.D4, new PlayerUseFireCommand(player) },
            };
            previousKeyState = Keyboard.GetState();
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