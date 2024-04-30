using MainGame.SpriteHandlers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGame.StartScreen
{
    public class GameSelectScreen
    {
        private Game1 game;
        private ISprite TopText;
        private ISprite NormalDungeonText;

        public GameSelectScreen(Game1 game) 
        { 
            this.game = game;
            TopText = SpriteFactory.CreateTextSprite("Dungeon Selector");
            NormalDungeonText = SpriteFactory.CreateTextSprite("Normal Dungeon");

        }

        public void Update()
        {
            
        }
        public void Draw()
        {
            TopText.Draw(Constants.ScreenSize.X / 2 - 120, 0, Color.White);
            NormalDungeonText.Draw(0, 100, Color.White);
        }
    }
}
