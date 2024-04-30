using MainGame.Dungeons;
using MainGame.HudAndMenu;
using MainGame.Players;
using MainGame.RNG;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGame.Commands.DungeonSelectCommands
{
    public class RandomDungeonCommand : ICommand
    {
        Game1 game;
        public RandomDungeonCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute() 
        {
            
            game.LoadDungeon("Dungeon_Random.csv", "Content/Rooms");
            game.GameSelectScreenToggle = false;
        }

        public void UnExecute() { }
    }
}
