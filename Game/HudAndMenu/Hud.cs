using System;
using MainGame.SpriteHandlers;
using MainGame.SpriteHandlers.BlockSprites;
using Microsoft.Xna.Framework;

namespace MainGame.HudAndMenu
{
    public class Hud
    {
        public ISprite HudBase;
        private int pauseShift;

        public Vector2 Position;
        private readonly Game1 game;

        private readonly BlockSprite background; // TODO: make an actual sprite that can do this...
        private readonly ISprite textLevel;
        private readonly ISprite textItemKey;
        private readonly ISprite textAttackKey;
        private readonly ISprite textLife;
        private ISprite textRupees;
        private ISprite textKeys;
        private ISprite textBombs;

        private readonly ISprite swordDisplay;
        private ISprite itemDisplay;

        private ISprite[] heartsDisplay;
        private int maxHealth;
        private ISprite[][] layoutDisplay;
        private ISprite triforceRoom;
        private Vector2 triforceRoomLoc;
        private readonly float textLayer = DefaultSpriteLayerDepths.HudLayer + 0.05f;

        public Hud(string dungeonID, string itemKey, string attackKey, Game1 game) 
        {
            this.game = game;
            background = (BlockSprite)SpriteFactory.CreateBlackSquareSprite();
            background.LayerDepth = DefaultSpriteLayerDepths.HudLayer - 0.01f;
            HudBase = SpriteFactory.CreateEmptyHudSprite();

            heartsDisplay = new ISprite[16];
            maxHealth = game.Player.MaxHealth; // Game crashed when it didn't use a copy
            InitializeMapLayout();
            triforceRoom = SpriteFactory.CreateMapTriforceTrackerSprite();
            triforceRoomLoc = game.Dungeon.TriforceRoomLocation;

            textLevel = SpriteFactory.CreateTextSprite("LEVEL-" + dungeonID, textLayer);
            textItemKey = SpriteFactory.CreateTextSprite(itemKey, textLayer);
            textAttackKey = SpriteFactory.CreateTextSprite(attackKey, textLayer);
            textLife = SpriteFactory.CreateTextSprite("-LIFE-", textLayer);

            swordDisplay = SpriteFactory.CreateSwordBeamUpProjectileSprite();
        }
        private void InitializeMapLayout()
        {
            layoutDisplay = new ISprite[game.Dungeon.DungeonSize][];
            for (int i = 0; i < game.Dungeon.DungeonSize; i++)
            {
                layoutDisplay[i] = new ISprite[game.Dungeon.DungeonSize];
            }
            for (int i = 0; i < game.Dungeon.DungeonSize; i++)
            {
                for (int j = 0; j < game.Dungeon.DungeonSize; j++)
                {
                    if (game.Dungeon.DungeonLayout[i][j] != 0)
                    {
                        layoutDisplay[i][j] = SpriteFactory.CreateMapLayoutPieceSprite();
                    }
                }
            }
        }

        public void TogglePauseDisplay(bool isPaused)
        {
            if (isPaused)
            {
                pauseShift = 176 * Constants.UniversalScale;
                return;
            }
            pauseShift = 0;

        }

        public void Update()
        {
            textRupees = SpriteFactory.CreateTextSprite($"X{game.Player.Inventory.Rupees.Quantity}", textLayer);
            textKeys = SpriteFactory.CreateTextSprite($"X{game.Player.Inventory.Keys.Quantity}", textLayer);
            textBombs = SpriteFactory.CreateTextSprite($"X{game.Player.Inventory.Bombs.Quantity}", textLayer);

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

            if (game.Player.Inventory.EquippedItem is null)
            {
                game.Menu.MoveSelectingBoxToFirstValidItem();
                itemDisplay = null;
            }
            else
            {
                itemDisplay = SpriteFactory.CreateItemSprite(game.Player.Inventory.EquippedItem.Name);
            }
        }
        public void Draw()
        {
            background.Draw(new Rectangle(new Point(0, pauseShift), HudBase.DestinationRectangle.Size), Color.White);
            HudBase.Draw(0, pauseShift, Color.White);
            textLevel.Draw(16 * Constants.UniversalScale, 8 * Constants.UniversalScale + pauseShift, Color.White);
            textRupees.Draw(96 * Constants.UniversalScale, 16 * Constants.UniversalScale + pauseShift, Color.White);
            textKeys.Draw(96 * Constants.UniversalScale, 32 * Constants.UniversalScale + pauseShift, Color.White);
            textBombs.Draw(96 * Constants.UniversalScale, 40 * Constants.UniversalScale + pauseShift, Color.White);
            textItemKey.Draw(128 * Constants.UniversalScale, 16 * Constants.UniversalScale + pauseShift, Color.White);
            textAttackKey.Draw(152 * Constants.UniversalScale, 16 * Constants.UniversalScale + pauseShift, Color.White);
            textLife.Draw(184 * Constants.UniversalScale, 16 * Constants.UniversalScale + pauseShift, Color.Red);

            if (itemDisplay is not null)
            {
                itemDisplay.LayerDepth = textLayer;
            }
            swordDisplay.LayerDepth = textLayer;
            swordDisplay.Draw(148 * Constants.UniversalScale, 24 * Constants.UniversalScale + pauseShift, Color.White);
            itemDisplay?.Draw(124 * Constants.UniversalScale, 24 * Constants.UniversalScale + pauseShift, Color.White);

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

            if (game.RoomManager.PlayerHasMap)
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

            if (game.RoomManager.PlayerHasCompass)
            {
                triforceRoom.Draw((18 + (8 * triforceRoomLoc.X)) * Constants.UniversalScale, (16 + (4 * triforceRoomLoc.Y)) * Constants.UniversalScale + pauseShift, Color.White);
            }
        }
    }

}
