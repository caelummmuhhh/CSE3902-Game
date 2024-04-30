using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGame.Commands.DungeonSelectCommands
{
    public class MouseDungeonSelect : ICommand
    {
        Game1 game;
        Vector2 mousePosition;

        public MouseDungeonSelect(Game1 game, Vector2 MousePosition) 
        {
            this.game = game;
            this.mousePosition = MousePosition;
        }

        public void Execute() 
        {
            if (game.GameSelectScreen.NormalDungeonHitBox.Contains(mousePosition.X, mousePosition.Y)) { new NormalDungeonCommand(game).Execute(); }
            if (game.GameSelectScreen.RandomDungeonHitBox.Contains(mousePosition.X, mousePosition.Y)) { new RandomDungeonCommand(game).Execute(); }
        }

        public void UnExecute()
        {

        }

    }
}
