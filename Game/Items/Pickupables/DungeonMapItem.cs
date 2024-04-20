using Microsoft.Xna.Framework;
using MainGame.Players;
using MainGame.SpriteHandlers;

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
            Player.Inventory.ObtainItem(ItemType);
            // TODO: Maybe change if Map obtained attribute is moved to the dungeon.
        }
    }
}


