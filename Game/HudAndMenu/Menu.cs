using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainGame.Items;
using MainGame.Players;
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

        private ISprite mapDisplay;
        private ISprite CompassDisplay;
        private ISprite bombItemDisplay;
        private ISprite boomerangItemDisplay;
        private ISprite arrowItemDisplay;
        private ISprite bowDisplay;

        private ISprite selectingBox;

        public Menu(String itemKey, Game1 game) 
        {
            this.game = game;
            MenuBase = SpriteFactory.CreateEmptyMenuSprite();

            textInventory = SpriteFactory.CreateTextSprite("INVENTORY");
            textInstructions = SpriteFactory.CreateTextSprite("USE " + itemKey + " KEY FOR THIS");
            textMap = SpriteFactory.CreateTextSprite("MAP");
            textCompass = SpriteFactory.CreateTextSprite("COMPASS");

            mapDisplay = SpriteFactory.CreateTextSprite("");
            CompassDisplay = SpriteFactory.CreateTextSprite("");
            boomerangItemDisplay = SpriteFactory.CreateTextSprite("");
            arrowItemDisplay = SpriteFactory.CreateTextSprite("");
            bowDisplay = SpriteFactory.CreateTextSprite("");

            bombItemDisplay = SpriteFactory.CreateBombItemSprite();
            selectingBox = SpriteFactory.CreateSelectingBoxSprite();
        }
        public void Update()
        {
            foreach (ItemTypes item in game.Player.Items)
            {
                switch (item)
                {
                    case ItemTypes.Map:
                        mapDisplay = SpriteFactory.CreateMapItemSprite();
                        break;
                    case ItemTypes.Compass:
                        CompassDisplay = SpriteFactory.CreateCompassItemSprite();
                        break;
                    case ItemTypes.Boomerang:
                        boomerangItemDisplay = SpriteFactory.CreateWoodenBoomerangItemSprite();
                        break;
                    case ItemTypes.Arrow:
                        arrowItemDisplay = SpriteFactory.CreateArrowItemSprite();
                        break;
                    case ItemTypes.Bow:
                        bowDisplay = SpriteFactory.CreateBowItemSprite();
                        break;
                    default:
                        break;
                }
            }
        }
        public void Draw()
        {
            MenuBase.Draw(0, 0, Color.White);

            textInventory.Draw(32 * Constants.UniversalScale, 24 * Constants.UniversalScale, Color.Red);
            textInstructions.Draw(16 * Constants.UniversalScale, 72 * Constants.UniversalScale, Color.White);
            textMap.Draw(40 * Constants.UniversalScale, 96 * Constants.UniversalScale, Color.Red);
            textCompass.Draw(24 * Constants.UniversalScale, 136 * Constants.UniversalScale, Color.Red);

            mapDisplay.Draw(44 * Constants.UniversalScale, 112 * Constants.UniversalScale, Color.White);
            CompassDisplay.Draw(44 * Constants.UniversalScale, 152 * Constants.UniversalScale, Color.White);
            bombItemDisplay.Draw(152 * Constants.UniversalScale, 48 * Constants.UniversalScale, Color.White);
            boomerangItemDisplay.Draw(128 * Constants.UniversalScale, 48 * Constants.UniversalScale, Color.White);
            arrowItemDisplay.Draw(172 * Constants.UniversalScale, 48 * Constants.UniversalScale, Color.White);
            bowDisplay.Draw(180 * Constants.UniversalScale, 48 * Constants.UniversalScale, Color.White);

            selectingBox.Draw(152 * Constants.UniversalScale, 48 * Constants.UniversalScale, Color.White);
        }
    }

}
