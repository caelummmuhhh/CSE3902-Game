using MainGame.Dungeons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGame.Commands.DungeonSelectCommands
{
    public class NormalDungeonCommand : ICommand
    {
        Game1 game;
        public NormalDungeonCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.LoadDungeon("Dungeon_1.csv", "Content/Rooms");
            game.GameSelectScreenToggle = false;
        }
        public void UnExecute()
        {

        }
    }
}
