using Microsoft.Xna.Framework;
using MainGame.Players;
using MainGame.SpriteHandlers;

namespace MainGame.WorldItems
{
    public class SingleStackEquipmentItem : AbstractPickupableItem
    {
        protected override ItemTypes ItemType { get; set; }
        protected override ISprite Sprite { get; set; }

        public SingleStackEquipmentItem(Vector2 spawnPosition, ItemTypes itemType, IPlayer player) : base(spawnPosition, player)
        {
            ItemType = itemType;
            Sprite = SpriteFactory.CreateItemSprite(itemType);
        }

        public override void PickUp()
        {
            IsPickedUp = true;
            Player.Inventory.AddItem(Id, 1);
        }
    }
}


