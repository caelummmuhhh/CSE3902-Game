using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGame.Commands
{
    public class StartGameCommand : ICommand
    {
        Game1 game;
        public StartGameCommand(Game1 game) 
        {
            this.game = game;
        }

        public void Execute()
        {
            game.StartScreen.StartScreenScroll();
        }

        public void UnExecute(){ }
    }
}
