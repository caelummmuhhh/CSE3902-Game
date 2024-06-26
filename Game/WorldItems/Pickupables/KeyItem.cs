﻿using Microsoft.Xna.Framework;
using MainGame.Players;
using MainGame.SpriteHandlers;
using MainGame.Audio;

namespace MainGame.WorldItems
{
    public class KeyItem : AbstractPickupableItem
    {
        protected override ItemTypes ItemType { get; set; } = ItemTypes.Key;
        protected override ISprite Sprite { get; set; }

        public KeyItem(Vector2 spawnPosition, IPlayer player) : base(spawnPosition, player)
        {
            Sprite = SpriteFactory.CreateKeyItemSprite();
        }

        public override void PickUp()
        {
            IsPickedUp = true;
            Player.Inventory.AddItem(Id, 1);
            AudioManager.PlaySFX("Grab_Item_Short", 0);
        }
    }
}


