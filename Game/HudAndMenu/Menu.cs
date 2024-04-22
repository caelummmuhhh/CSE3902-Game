using System.Collections.Generic;
using MainGame.Audio;
using MainGame.Players;
using MainGame.Players.Inventory;
using MainGame.SpriteHandlers;
using Microsoft.Xna.Framework;

namespace MainGame.HudAndMenu
{
    public class Menu
    {
        public ISprite MenuBase;

        public Vector2 Position;
        private readonly Game1 game;

        private readonly ISprite textInventory;
        private readonly ISprite textInstructions;
        private readonly ISprite textMap;
        private readonly ISprite textCompass;

        private readonly ISprite mapDisplay;
        private readonly ISprite compassDisplay;

        private ISprite bombItemDisplay;
        private ISprite boomerangItemDisplay;
        private ISprite arrowItemDisplay;
        private ISprite bowItemDisplay;
        private ISprite candleItemDisplay;

        private ISprite selectedItemSprite;
        private readonly ISprite selectingBox;

        private readonly Point inventorySlotsSize = new(4, 2); // 4 columns, 2 rows
        private Point currentSlot = new(0, 0);

        // read from left to right, top to bottom.
        private readonly List<ItemTypes> itemSlotOrder = new()
        {
            ItemTypes.Boomerang, ItemTypes.Bomb, ItemTypes.Bow, ItemTypes.Candle
        };

        private readonly int maxItemSelectDebounce = 10;
        private int itemSelectDebounce = 10;

        public Menu(string itemKey, Game1 game) 
        {
            this.game = game;
            itemSelectDebounce = maxItemSelectDebounce;
            MenuBase = SpriteFactory.CreateEmptyMenuSprite();

            textInventory = SpriteFactory.CreateTextSprite("INVENTORY");
            textInstructions = SpriteFactory.CreateTextSprite("USE " + itemKey + " KEY FOR THIS");
            textMap = SpriteFactory.CreateTextSprite("MAP");
            textCompass = SpriteFactory.CreateTextSprite("COMPASS");

            selectingBox = SpriteFactory.CreateSelectingBoxSprite();

            MoveSelectingBoxToFirstValidItem();
        }

        public void Update()
        {
            selectingBox.Update();
            itemSelectDebounce = itemSelectDebounce - 1 < 0 ? -1 : itemSelectDebounce - 1;
            SetInventoryItemsDisplay();

            if (game.Player.Inventory.EquippedItem is null)
            {
                MoveSelectingBoxToFirstValidItem();
            }

            UpdateSelectedItemDisplay();
        }

        public void Draw()
        {
            MenuBase.Draw(0, 0, Color.White);

            textInventory.Draw(32 * Constants.UniversalScale, 24 * Constants.UniversalScale, Color.Red);
            textInstructions.Draw(16 * Constants.UniversalScale, 72 * Constants.UniversalScale, Color.White);
            textMap.Draw(40 * Constants.UniversalScale, 96 * Constants.UniversalScale, Color.Red);
            textCompass.Draw(24 * Constants.UniversalScale, 136 * Constants.UniversalScale, Color.Red);

            mapDisplay?.Draw(44 * Constants.UniversalScale, 112 * Constants.UniversalScale, Color.White);
            compassDisplay?.Draw(44 * Constants.UniversalScale, 152 * Constants.UniversalScale, Color.White);
            selectedItemSprite?.Draw(64 * Constants.UniversalScale, 48 * Constants.UniversalScale, Color.White);

            boomerangItemDisplay?.Draw(128 * Constants.UniversalScale, 48 * Constants.UniversalScale, Color.White);
            bombItemDisplay?.Draw(152 * Constants.UniversalScale, 48 * Constants.UniversalScale, Color.White);
            arrowItemDisplay?.Draw(172 * Constants.UniversalScale, 48 * Constants.UniversalScale, Color.White);
            bowItemDisplay?.Draw(180 * Constants.UniversalScale, 48 * Constants.UniversalScale, Color.White);
            candleItemDisplay?.Draw(200 * Constants.UniversalScale, 48 * Constants.UniversalScale, Color.White);

            selectingBox.Draw((128 + currentSlot.X * 24) * Constants.UniversalScale,
                (48 + currentSlot.Y * 16) * Constants.UniversalScale, Color.White);
        }


        public void MoveSelectingBoxRight()
        {
            if (itemSelectDebounce >= 0) return;
            itemSelectDebounce = maxItemSelectDebounce;

            int startingFlatIndex = currentSlot.Y * inventorySlotsSize.X + currentSlot.X + 1;
            for (int i = startingFlatIndex; i < startingFlatIndex + itemSlotOrder.Count; i++)
            {
                int newFlatIndex = i % itemSlotOrder.Count;
                ItemTypes itemType = itemSlotOrder[newFlatIndex];
                if (IsValidSelectItem(itemType))
                {
                    AudioManager.PlaySFX("Grab_Rupee_And_Menu", 0);
                    game.Player.Inventory.Equip((int)itemType);
                    MoveSelectBoxToFlatIndex(newFlatIndex);
                    UpdateSelectedItemDisplay();
                    return;
                }
            }
        }

        public void MoveSelectingBoxLeft()
        {
            if (itemSelectDebounce >= 0) return;
            itemSelectDebounce = maxItemSelectDebounce;

            int startingFlatIndex = currentSlot.Y * inventorySlotsSize.X + currentSlot.X - 1;
            for (int i = startingFlatIndex; i >= startingFlatIndex - itemSlotOrder.Count; i--)
            {
                int newFlatIndex = (i % itemSlotOrder.Count + itemSlotOrder.Count) % itemSlotOrder.Count;
                ItemTypes itemType = itemSlotOrder[newFlatIndex];
                if (IsValidSelectItem(itemType))
                {
                    AudioManager.PlaySFX("Grab_Rupee_And_Menu", 0);
                    game.Player.Inventory.Equip((int)itemType);
                    MoveSelectBoxToFlatIndex(newFlatIndex);
                    UpdateSelectedItemDisplay();
                    return;
                }
            }
        }

        public void MoveSelectingBoxToFirstValidItem()
        {
            int flatIndex;
            for (flatIndex = 0; flatIndex < itemSlotOrder.Count; flatIndex++)
            {
                ItemTypes itemType = itemSlotOrder[flatIndex];
                if (IsValidSelectItem(itemType))
                {
                    game.Player.Inventory.Equip((int)itemType);
                    MoveSelectBoxToFlatIndex(flatIndex);
                    UpdateSelectedItemDisplay();
                    return;
                }
            }

            // No items can be selected so default select box position back to first slot
            currentSlot = new Point(0, 0);
            UpdateSelectedItemDisplay();
        }

        private bool IsValidSelectItem(ItemTypes itemType)
        {
            ILinkInventory inventory = game.Player.Inventory;
            bool validItem = inventory.HasItem((int)itemType);
            validItem = validItem && (itemType != ItemTypes.Bomb || inventory.Bombs.Quantity > 0);
            validItem = validItem && ((itemType != ItemTypes.Bow && itemType != ItemTypes.Arrow)
                                       || (inventory.HasItem((int)ItemTypes.Bow) && inventory.HasItem((int)ItemTypes.Arrow)));
            return validItem;
        }

        private void UpdateSelectedItemDisplay()
        {
            if (game.Player.Inventory.EquippedItem is null)
            {
                selectedItemSprite = null;
                return;
            }
            selectedItemSprite = SpriteFactory.CreateItemSprite(game.Player.Inventory.EquippedItem.Name);
        }

        private void SetInventoryItemsDisplay()
        {
            ILinkInventory inventory = game.Player.Inventory;

            if (inventory.HasItem((int)ItemTypes.Bomb) && inventory.Bombs.Quantity > 0)
            {
                bombItemDisplay = SpriteFactory.CreateBombItemSprite();
            }
            else
            {
                bombItemDisplay = null;
            }

            if (boomerangItemDisplay is null && inventory.HasItem((int)ItemTypes.Boomerang))
            {
                boomerangItemDisplay = SpriteFactory.CreateWoodenBoomerangItemSprite();
            }

            if (candleItemDisplay is null && inventory.HasItem((int)ItemTypes.Candle))
            {
                candleItemDisplay = SpriteFactory.CreateCandleSprite();
            }

            if (bowItemDisplay is null && inventory.HasItem((int)ItemTypes.Bow))
            {
                bowItemDisplay = SpriteFactory.CreateBowItemSprite();
            }

            if (arrowItemDisplay is null && inventory.HasItem((int)ItemTypes.Arrow))
            {
                arrowItemDisplay = SpriteFactory.CreateArrowItemSprite();
            }
        }

        private void MoveSelectBoxToFlatIndex(int flatIndex)
        {
            int newColumn = flatIndex % inventorySlotsSize.X;
            int newRow = flatIndex / inventorySlotsSize.X;
            currentSlot = new Point(newColumn, newRow);
        }
    }

}
