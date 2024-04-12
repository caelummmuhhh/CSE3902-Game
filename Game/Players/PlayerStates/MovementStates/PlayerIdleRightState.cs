using MainGame.SpriteHandlers;

namespace MainGame.Players.PlayerStates
{
    public class PlayerIdleRightState : IPlayerState
    {
        private readonly IPlayer player;

        public PlayerIdleRightState(IPlayer player)
        {
            this.player = player;
            this.player.FacingDirection = Direction.East;
            this.player.Sprite = SpriteFactory.CreatePlayerIdleRightSprite();
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
        public void UseSword() => player.CurrentState = new PlayerUsingSwordRightState(player);
        public void UseItem()
        {
            if (player.Inventory.CanUseEquippedItem())
            {
                player.CurrentState = new PlayerUsingItemRightState(player);
            }
        }
    }
}
