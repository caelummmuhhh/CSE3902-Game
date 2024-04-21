﻿using Microsoft.Xna.Framework;
using MainGame.Players;
using MainGame.SpriteHandlers;
using MainGame.Audio;

namespace MainGame.WorldItems
{
    public class BombItem : AbstractPickupableItem
    {
        protected override ItemTypes ItemType { get; set; } = ItemTypes.Bomb;
        protected override ISprite Sprite { get; set; }
        private readonly int quantity;

        public BombItem(Vector2 spawnPosition, IPlayer player, int quantity, AudioManager audioManager)
            : base(spawnPosition, player, audioManager)
        {
            Sprite = SpriteFactory.CreateBombItemSprite();
            this.quantity = quantity;
        }

        public override void PickUp()
        {
            IsPickedUp = true;
            Player.Inventory.AddItem(Id, quantity);
            audioManager.PlaySFX("Grab_Item_Medium", 0);
        }
    }
}
