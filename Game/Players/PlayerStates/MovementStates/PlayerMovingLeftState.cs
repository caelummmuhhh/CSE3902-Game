using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Players.PlayerStates
{
    public class PlayerMovingLeftState : IPlayerState
    {
        private readonly IPlayer player;

		public PlayerMovingLeftState(IPlayer player)
		{
            this.player = player;
            this.player.FacingDirection = Direction.West;
            this.player.Sprite = SpriteFactory.CreatePlayerWalkingLeftSprite();

            player.Position = new Vector2(player.Position.X, GridHandler.SnapToGridHalfStep(player.Position).Y);
        }

        public void Draw()
        {
            player.Sprite.Draw(player.Position.X, player.Position.Y, player.SpriteColor);
        }

        public void MoveLeft()
        {
            player.PreviousPosition = player.Position;
            player.Position = new(player.Position.X - Player.Speed, player.Position.Y);
        }

        public void Update() => player.Sprite.Update();
        public void Stop() => player.CurrentState = new PlayerIdleLeftState(player);

        public void TakeDamage(Direction sideHit)
            => player.CurrentState = new PlayerKnockedBackState(player, Utils.OppositeDirection(sideHit));

        public void MoveUp()
        {
            player.Position = new(player.Position.X - 1f * Constants.UniversalScale, player.Position.Y);
            player.CurrentState = new PlayerMovingUpState(player);
        }

        public void MoveDown()
        {
            player.Position = new(player.Position.X + 1f * Constants.UniversalScale, player.Position.Y);
            player.CurrentState = new PlayerMovingDownState(player);
        }

        public void MoveRight() => player.CurrentState = new PlayerMovingRightState(player);
        public void UseSword() => player.CurrentState = new PlayerUsingSwordLeftState(player);
        public void UseEquipment()
        {
            if (player.Inventory.EquippedItem is not null && player.Inventory.EquippedItem.IsUseable)
            {
                player.CurrentState = new PlayerUsingItemLeftState(player);
            }
        }

    }
}

