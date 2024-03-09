using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGame.Commands
{
    public class NextRoomCommand : ICommand
    {
        private Game1 game;

        public NextRoomCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Room = game.Room.getNextRoom();
        }

        public void UnExecute()
        {
            
        }
    }
}
