using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainGame.SpriteHandlers;
using Microsoft.Xna.Framework;

namespace MainGame.HudAndMenu
{
    public class Hud
    {
        public ISprite HudBase;

        public Vector2 Position;
        private readonly Game1 game;

        private ISprite textLevel;
        private ISprite textRupees;
        private ISprite textKeys;
        private ISprite textBombs;
        private ISprite textItemKey;
        private ISprite textAttackKey;
        private ISprite textLife;

        private ISprite[] heartsDisplay;
        public Hud(String dungeonID, String itemKey, String attackKey, Game1 game) 
        {
            this.game = game;
            HudBase = SpriteFactory.CreateEmptyHudSprite();

            heartsDisplay = new ISprite[16];

            textLevel = SpriteFactory.CreateTextSprite("LEVEL-" + dungeonID);
            textRupees = SpriteFactory.CreateTextSprite("999");
            textKeys = SpriteFactory.CreateTextSprite("X99");
            textBombs = SpriteFactory.CreateTextSprite("X99");
            textItemKey = SpriteFactory.CreateTextSprite(itemKey);
            textAttackKey = SpriteFactory.CreateTextSprite(attackKey);
            textLife = SpriteFactory.CreateTextSprite("-LIFE-");

            // This is temporary theoretical stuff until the player class is finalized (this code doesn't do it right)
            int max = 12;
            float hp = 6.5f;
            for (int i = 0; i < max; ++i)
            {
                if (i < hp)
                {
                    heartsDisplay[i] = SpriteFactory.CreateFullHeartDisplaySprite();
                }
                else if (i > hp)
                {
                    heartsDisplay[i] = SpriteFactory.CreateEmptyHeartDisplaySprite();
                } else
                {
                    heartsDisplay[i] = SpriteFactory.CreateHalfHeartDisplaySprite();
                }
            }
        }
        public void Update()
        {
            HudBase.Update();
        }
        public void Draw()
        {
            HudBase.Draw(0, 0, Color.White);
            textLevel.Draw(16 * 3, 8 * 3, Color.White);
            textRupees.Draw(96 * 3, 16 * 3, Color.White);
            textKeys.Draw(96 * 3, 32 * 3, Color.White);
            textBombs.Draw(96 * 3, 40 * 3, Color.White);
            textItemKey.Draw(128 * 3, 16 * 3, Color.White);
            textAttackKey.Draw(152 * 3, 16 * 3, Color.White);
            textLife.Draw(184 * 3, 16 * 3, Color.Red);

            for (int i = 0; i < 12; ++i)
            {
                if (i < 8)
                {
                    heartsDisplay[i].Draw((176 + (8 * i)) * 3, 40 * 3, Color.White);

                }
                else
                {
                    heartsDisplay[i].Draw((176 + (8 * (i - 8))) * 3, 32 * 3, Color.White);
                }
            }
        }
    }

}
