using Microsoft.Xna.Framework;
using MainGame.Players;
using MainGame.SpriteHandlers;
using MainGame.Audio;

namespace MainGame.WorldItems
{
    public class SingleStackEquipmentItem : AbstractPickupableItem
    {
        protected override ItemTypes ItemType { get; set; }
        protected override ISprite Sprite { get; set; }

        public SingleStackEquipmentItem(Vector2 spawnPosition, ItemTypes itemType, IPlayer player, AudioManager audioManager)
            : base(spawnPosition, player, audioManager)
        {
            ItemType = itemType;
            Sprite = SpriteFactory.CreateItemSprite(itemType);
        }

        public override void PickUp()
        {
            IsPickedUp = true;
            Player.Inventory.AddItem(Id, 1);
            audioManager.PlaySFX("Grab_Item_Medium", 0);
        }
    }
}


