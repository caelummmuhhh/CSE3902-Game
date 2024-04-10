using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainGame.SpriteHandlers;
using Microsoft.Xna.Framework;

namespace MainGame.HudAndMenu
{
    public class Menu
    {
        public ISprite MenuBase;

        public Vector2 Position;
        private readonly Game1 game;

        private ISprite textInventory;
        private ISprite textInstructions;
        private ISprite textMap;
        private ISprite textCompass;

        public Menu(String itemKey, Game1 game) 
        {
            this.game = game;
            MenuBase = SpriteFactory.CreateEmptyMenuSprite();

            textInventory = SpriteFactory.CreateTextSprite("INVENTORY");
            textInstructions = SpriteFactory.CreateTextSprite("USE " + itemKey + " KEY FOR THIS");
            textMap = SpriteFactory.CreateTextSprite("MAP");
            textCompass = SpriteFactory.CreateTextSprite("COMPASS");
        }
        public void Update()
        {
            MenuBase.Update();
        }
        public void Draw()
        {
            MenuBase.Draw(0, 0, Color.White);
            textInventory.Draw(32 * 3, 24 * 3, Color.Red);
            textInstructions.Draw(16 * 3, 72 * 3, Color.White);
            textMap.Draw(40 * 3, 96 * 3, Color.Red);
            textCompass.Draw(24 * 3, 136 * 3, Color.Red);
        }
    }

}
