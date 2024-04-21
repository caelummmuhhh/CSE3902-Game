using Microsoft.Xna.Framework;
using MainGame.Players;
using MainGame.SpriteHandlers;
using System;

namespace MainGame.WorldItems
{
    public class DungeonCompassItem : AbstractPickupableItem
    {
        protected override ItemTypes ItemType { get; set; } = ItemTypes.Compass;
        protected override ISprite Sprite { get; set; }

        public DungeonCompassItem(Vector2 spawnPosition, IPlayer player) : base(spawnPosition, player)
        {
            Sprite = SpriteFactory.CreateCompassItemSprite();
        }

        public override void PickUp()
        {
            IsPickedUp = true;
            Console.WriteLine("Player picked up Dungeon Compass.");
            // TODO: Make this interact with Room
        }
    }
}


