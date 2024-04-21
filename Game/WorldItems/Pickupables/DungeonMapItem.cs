using Microsoft.Xna.Framework;
using MainGame.Players;
using MainGame.SpriteHandlers;
using System;
using MainGame.Audio;

namespace MainGame.WorldItems
{
    public class DungeonMapItem : AbstractPickupableItem
    {
        protected override ItemTypes ItemType { get; set; } = ItemTypes.Map;
        protected override ISprite Sprite { get; set; }

        public DungeonMapItem(Vector2 spawnPosition, IPlayer player) : base(spawnPosition, player)
        {
            Sprite = SpriteFactory.CreateMapItemSprite();
        }

        public override void PickUp()
        {
            IsPickedUp = true;
            Console.WriteLine("Player picked up Dungeon Compass.");
            AudioManager.PlaySFX("Grab_Item_Medium", 0);
            // TODO: Make this interact with Room
        }
    }
}


