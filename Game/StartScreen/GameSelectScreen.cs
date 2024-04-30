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
        private ISprite RandomDungeonText;
        private ISprite NormalDungeonText;
        public Rectangle RandomDungeonHitBox;
        public Rectangle NormalDungeonHitBox;


        public GameSelectScreen(Game1 game) 
        { 
            this.game = game;
            TopText = SpriteFactory.CreateTextSprite("Dungeon Selector");
            RandomDungeonHitBox = new Rectangle(20, 100, 250, 40);
            NormalDungeonHitBox = new Rectangle(20, 50, 250, 40);

            RandomDungeonText = SpriteFactory.CreateTextSprite("Random Dungeon");
            NormalDungeonText = SpriteFactory.CreateTextSprite("Normal Dungeon");
        }

        public void Update()
        {
            
        }

        public void Draw()
        {
            TopText.Draw(Constants.ScreenSize.X / 2 - 120, 0, Color.White);
            NormalDungeonText.Draw(NormalDungeonHitBox.X, NormalDungeonHitBox.Y, Color.White);
            RandomDungeonText.Draw(RandomDungeonHitBox.X, RandomDungeonHitBox.Y, Color.Red);
        }
    }
}
