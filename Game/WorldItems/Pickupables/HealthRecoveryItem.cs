﻿using Microsoft.Xna.Framework;
using MainGame.Players;
using MainGame.SpriteHandlers;
using MainGame.Audio;

namespace MainGame.WorldItems
{
    public class HealthRecoveryItem : AbstractPickupableItem
    {
        protected override ItemTypes ItemType { get; set; }
        protected override ISprite Sprite { get; set; }
        protected readonly int healAmount;

        public HealthRecoveryItem(Vector2 spawnPosition, IPlayer player, ItemTypes itemType, int healAmount, AudioManager audioManager)
            : base(spawnPosition, player, audioManager)
        {
            ItemType = itemType;
            Sprite = SpriteFactory.CreateItemSprite(itemType);
            this.healAmount = healAmount;
            
        }

        public override void PickUp()
        {
            IsPickedUp = true;
            Player.Heal(healAmount);
            audioManager.PlaySFX("Grab_Item_Short", 0);
        }
    }
}

