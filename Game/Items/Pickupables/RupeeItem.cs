using Microsoft.Xna.Framework;
using MainGame.Players;
using MainGame.SpriteHandlers;

namespace MainGame.Items
{
    public class RupeeItem : AbstractPickupableItem
    {
        protected override ItemTypes ItemType { get; set; }
        protected override ISprite Sprite { get; set; }
        private readonly int worth;

        public RupeeItem(Vector2 spawnPosition, IPlayer player, ItemTypes itemType, int quantity) : base(spawnPosition, player)
        {
            ItemType = itemType;
            Sprite = SpriteFactory.CreateItemSprite(itemType);
            worth = quantity;
        }

        public override void PickUp()
        {
            IsPickedUp = true;
            Player.Inventory.Rupees.Obtain(worth);
        }
    }
}

