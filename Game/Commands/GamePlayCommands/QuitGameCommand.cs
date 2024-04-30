using System;
using Microsoft.Xna.Framework;

namespace MainGame.Commands
{
    public class QuitGameCommand : ICommand
    {
        private readonly Game game;

        public QuitGameCommand(Game game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Exit();
        }

        public void UnExecute()
        {
            // not needed
        }
    }
}

