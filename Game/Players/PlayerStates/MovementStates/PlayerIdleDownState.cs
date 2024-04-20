using MainGame.SpriteHandlers;

namespace MainGame.Players.PlayerStates
{
    public class PlayerIdleDownState : IPlayerState
    {
        private readonly IPlayer player;

        public PlayerIdleDownState(IPlayer player)
        {
            this.player = player;
            this.player.FacingDirection = Direction.South;
            this.player.Sprite = SpriteFactory.CreatePlayerIdleDownSprite();
        }

        public void Draw()
        {
            player.Sprite.Draw(player.Position.X, player.Position.Y, player.SpriteColor);
        }
        public void Update() => player.Sprite.Update();
        public void Stop() { }

        public void TakeDamage(Direction sideHit)
            => player.CurrentState = new PlayerKnockedBackState(player, Utils.OppositeDirection(sideHit));

        public void MoveUp() => player.CurrentState = new PlayerMovingUpState(player);
        public void MoveDown() => player.CurrentState = new PlayerMovingDownState(player);
        public void MoveRight() => player.CurrentState = new PlayerMovingRightState(player);
        public void MoveLeft() => player.CurrentState = new PlayerMovingLeftState(player);
        public void UseSword() => player.CurrentState = new PlayerUsingSwordDownState(player);
        public void UseEquipment()
        {
            if (player.Inventory.CanUseEquippedItem())
            {
                player.CurrentState = new PlayerUsingItemDownState(player);
            }
        }
    }
}
