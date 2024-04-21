using Microsoft.Xna.Framework;
using MainGame.Players;
using MainGame.SpriteHandlers;
using MainGame.Audio;

namespace MainGame.WorldItems
{
    public class HeartContainerItem : AbstractPickupableItem
    {
        protected override ISprite Sprite { get; set; }
        protected override ItemTypes ItemType { get; set; } = ItemTypes.HeartContainer;

        public HeartContainerItem(Vector2 spawnPosition, IPlayer player, AudioManager audioManager)
            : base(spawnPosition, player, audioManager)
        {
            Sprite = SpriteFactory.CreateHeartContainerItemSprite();
        }

        public override void PickUp()
        {
            IsPickedUp = true;
            Player.IncreaseMaxHP();
            Player.Heal(Player.MaxHealth);
            audioManager.PlaySFX("Grab_Item_Medium", 0);
        }
    }
}

