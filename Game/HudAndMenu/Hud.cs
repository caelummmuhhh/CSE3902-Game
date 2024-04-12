using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainGame.Players;
using MainGame.SpriteHandlers;
using Microsoft.Xna.Framework;

namespace MainGame.HudAndMenu
{
    public class Hud
    {
        public ISprite HudBase;
        private int pauseShift;

        public Vector2 Position;
        private readonly Game1 game;

        private ISprite textLevel;
        private ISprite textRupees;
        private ISprite textKeys;
        private ISprite textBombs;
        private ISprite textItemKey;
        private ISprite textAttackKey;
        private ISprite textLife;

        private ISprite swordDisplay;
        private ISprite itemDisplay;

        private ISprite[] heartsDisplay;
        public Hud(String dungeonID, String itemKey, String attackKey, Game1 game) 
        {
            this.game = game;
            HudBase = SpriteFactory.CreateEmptyHudSprite();

            heartsDisplay = new ISprite[16];

            textLevel = SpriteFactory.CreateTextSprite("LEVEL-" + dungeonID);
            textItemKey = SpriteFactory.CreateTextSprite(itemKey);
            textAttackKey = SpriteFactory.CreateTextSprite(attackKey);
            textLife = SpriteFactory.CreateTextSprite("-LIFE-");

            swordDisplay = SpriteFactory.CreateSwordBeamUpProjectileSprite();
        }
        public void PauseUpdate()
        {
            pauseShift = 176 * Constants.UniversalScale;
        }
        public void Update()
        {
            pauseShift = 0;
            for (int i = 0; i < this.game.Player.MaxHealth / 2; ++i)
            {
                if (2 * (i + 1) <= this.game.Player.CurrentHealth)
                {
                    heartsDisplay[i] = SpriteFactory.CreateFullHeartDisplaySprite();
                }
                else if (this.game.Player.CurrentHealth - (2 * (i + 1)) == -1)
                {
                    heartsDisplay[i] = SpriteFactory.CreateHalfHeartDisplaySprite();
                }
                else
                {
                    heartsDisplay[i] = SpriteFactory.CreateEmptyHeartDisplaySprite();
                }
            }
            textRupees = SpriteFactory.CreateTextSprite($"X{game.Player.Inventory.Rupees.Count}");
            textKeys = SpriteFactory.CreateTextSprite($"X{game.Player.Inventory.KeyCount.Count}");
            textBombs = SpriteFactory.CreateTextSprite($"X{game.Player.Inventory.BombCount.Count}");
        }
        public void Draw()
        {
            HudBase.Draw(0, pauseShift, Color.White);
            textLevel.Draw(16 * Constants.UniversalScale, 8 * Constants.UniversalScale + pauseShift, Color.White);
            textRupees.Draw(96 * Constants.UniversalScale, 16 * Constants.UniversalScale + pauseShift, Color.White);
            textKeys.Draw(96 * Constants.UniversalScale, 32 * Constants.UniversalScale + pauseShift, Color.White);
            textBombs.Draw(96 * Constants.UniversalScale, 40 * Constants.UniversalScale + pauseShift, Color.White);
            textItemKey.Draw(128 * Constants.UniversalScale, 16 * Constants.UniversalScale + pauseShift, Color.White);
            textAttackKey.Draw(152 * Constants.UniversalScale, 16 * Constants.UniversalScale + pauseShift, Color.White);
            textLife.Draw(184 * Constants.UniversalScale, 16 * Constants.UniversalScale + pauseShift, Color.Red);

            swordDisplay.Draw(148 * Constants.UniversalScale, 24 * Constants.UniversalScale + pauseShift, Color.White);
            //itemDisplay.Draw(124 * Constants.UniversalScale, 24 * Constants.UniversalScale + pauseShift, Color.White);

            for (int i = 0; i < this.game.Player.MaxHealth / 2; ++i)
            {
                if (i < 8)
                {
                    heartsDisplay[i].Draw((176 + (8 * i)) * Constants.UniversalScale, 40 * Constants.UniversalScale + pauseShift, Color.White);

                }
                else
                {
                    heartsDisplay[i].Draw((176 + (8 * (i - 8))) * Constants.UniversalScale, 32 * Constants.UniversalScale + pauseShift, Color.White);
                }
            }
        }
    }

}
