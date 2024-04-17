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
        private int maxHealth;
        private ISprite[][] layoutDisplay;
        private bool hasMap = false;
        private ISprite triforceRoom;
        private Vector2 triforceRoomLoc;
        private bool hasCompass = false;
        public Hud(String dungeonID, String itemKey, String attackKey, Game1 game) 
        {
            this.game = game;
            HudBase = SpriteFactory.CreateEmptyHudSprite();

            heartsDisplay = new ISprite[16];
            maxHealth = game.Player.MaxHealth; // Game crashed when it didn't use a copy
            InitializeMapLayout();
            InitializeTriforceRoom();

            textLevel = SpriteFactory.CreateTextSprite("LEVEL-" + dungeonID);
            textItemKey = SpriteFactory.CreateTextSprite(itemKey);
            textAttackKey = SpriteFactory.CreateTextSprite(attackKey);
            textLife = SpriteFactory.CreateTextSprite("-LIFE-");

            swordDisplay = SpriteFactory.CreateSwordBeamUpProjectileSprite();
            switch (game.Player.CurrentItem)
            {
                case ItemTypes.Bomb:
                    itemDisplay = SpriteFactory.CreateBombItemSprite();
                    break;
                case ItemTypes.Fire:
                    // Candle item not in reqirements
                    break;
                case ItemTypes.Boomerang:
                    itemDisplay = SpriteFactory.CreateWoodenBoomerangItemSprite();
                    break;
                case ItemTypes.Arrow:
                    itemDisplay = SpriteFactory.CreateArrowItemSprite();
                    break;
                default:
                    throw new FormatException("Default in Hud should not be possible");
            }
        }
        private void InitializeTriforceRoom()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (game.Dungeon.DungeonLayout[i][j] == game.Dungeon.DungeonRoomCount)
                    {
                        triforceRoom = SpriteFactory.CreateMapTriforceTrackerSprite();
                        triforceRoomLoc = new Vector2(j, i);
                    }
                }
            }
        }
        private void InitializeMapLayout()
        {
            layoutDisplay = new ISprite[8][];
            for (int i = 0; i < 8; i++)
            {
                layoutDisplay[i] = new ISprite[8];
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (game.Dungeon.DungeonLayout[i][j] != 0)
                    {
                        layoutDisplay[i][j] = SpriteFactory.CreateMapLayoutPieceSprite();
                    }
                }
            }
        }
        public void PauseUpdate()
        {
            pauseShift = 176 * Constants.UniversalScale;
        }
        public void Update()
        {
            pauseShift = 0;

            textRupees = SpriteFactory.CreateTextSprite("X" + this.game.Player.RupeeCount.ToString());
            textKeys = SpriteFactory.CreateTextSprite("X" + this.game.Player.KeyCount.ToString());
            textBombs = SpriteFactory.CreateTextSprite("X" + this.game.Player.BombCount.ToString());

            maxHealth = game.Player.MaxHealth;
            for (int i = 0; i < maxHealth / 2; ++i)
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

            // This is kinda dumb
            if (!hasMap || !hasCompass)
            {
                foreach (ItemTypes Item in game.Player.Items)
                {
                    switch (Item)
                    {
                        case ItemTypes.Map:
                            hasMap = true;
                            break;
                        case ItemTypes.Compass:
                            hasCompass = true;
                            break;
                        default:
                            // Do Nothing
                            break;
                    }
                }
            }
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
            itemDisplay.Draw(124 * Constants.UniversalScale, 24 * Constants.UniversalScale + pauseShift, Color.White);

            for (int i = 0; i < maxHealth / 2; ++i)
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

            if (hasMap)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (game.Dungeon.DungeonLayout[i][j] != 0) // && Room has been visited for when no map?
                        {
                            layoutDisplay[i][j].Draw((16 + (8 * j)) * Constants.UniversalScale, (16 + (4 * i)) * Constants.UniversalScale + pauseShift, Color.White);
                        }
                    }
                }
            } 
            if (hasCompass)
            {
                triforceRoom.Draw((18 + (8 * triforceRoomLoc.X)) * Constants.UniversalScale, (16 + (4 * triforceRoomLoc.Y)) * Constants.UniversalScale + pauseShift, Color.White);
            }
        }
    }

}
