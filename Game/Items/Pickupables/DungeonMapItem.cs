using Microsoft.Xna.Framework;
using MainGame.Players;
using MainGame.SpriteHandlers;
using System;

namespace MainGame.Items
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
            // TODO: Make this interact with Room
        }
    }
}


