using MainGame.SpriteHandlers;

namespace MainGame.Players.PlayerStates
{
	public class PlayerUsingItemDownState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly int stateDuration;
        private int currentFrame = 0;

        public PlayerUsingItemDownState(IPlayer player)
        {
            this.player = player;
            this.player.FacingDirection = Direction.South;
            this.player.Sprite = SpriteFactory.CreatePlayerInteractingDownSprite();
            stateDuration = Player.UsingItemsSpeed;
            this.player.Inventory.UseEquippedItem(); // actually use the item
        }

        public void Update()
        {
            if (currentFrame == stateDuration)
            {
                player.CurrentState = new PlayerIdleDownState(player);
            }
            player.Sprite.Update();
        }

        public void Draw()
        {
            currentFrame++;
            player.Sprite.Draw(player.Position.X, player.Position.Y, player.SpriteColor);
        }

        public void TakeDamage(Direction sideHit)
            => player.CurrentState = new PlayerKnockedBackState(player, Utils.OppositeDirection(sideHit));

        /* Not useable in this state, therefore not implemented. */
        public void Stop() { }
        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public void UseSword() { }
        public void UseEquipment() { }
    }
}
