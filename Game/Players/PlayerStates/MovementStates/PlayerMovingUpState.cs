using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Players.PlayerStates
{
	public class PlayerMovingUpState : IPlayerState
	{
		private readonly IPlayer player;

		public PlayerMovingUpState(IPlayer player)
		{
            this.player = player;
            this.player.FacingDirection = Direction.North;
            this.player.Sprite = SpriteFactory.CreatePlayerWalkingUpSprite();

            player.Position = new Vector2(GridHandler.SnapToGridHalfStep(player.Position).X, player.Position.Y);
        }

        public void Draw()
        {
            player.Sprite.Draw(player.Position.X, player.Position.Y, player.SpriteColor);
        }

        public void MoveUp()
        {
            player.PreviousPosition = player.Position;
            player.Position = new(player.Position.X, player.Position.Y - Player.Speed);
        }

        public void Update() => player.Sprite.Update();
        public void Stop() => player.CurrentState = new PlayerIdleUpState(player);

        public void TakeDamage(Direction sideHit)
            => player.CurrentState = new PlayerKnockedBackState(player, Utils.OppositeDirection(sideHit));

        public void MoveDown() => player.CurrentState = new PlayerMovingDownState(player);
        public void MoveRight()
        {
            player.Position = new(player.Position.X, player.Position.Y + 1f * Constants.UniversalScale);
            player.CurrentState = new PlayerMovingRightState(player);
        }
        public void MoveLeft()
        {
            player.Position = new(player.Position.X, player.Position.Y - 1f * Constants.UniversalScale);
            player.CurrentState = new PlayerMovingLeftState(player);
        }

        public void UseSword() => player.CurrentState = new PlayerUsingSwordUpState(player);
        public void UseEquipment()
        {
            if (player.Inventory.EquippedItem is not null && player.Inventory.EquippedItem.IsUseable)
            {
                player.CurrentState = new PlayerUsingItemUpState(player);
            }
        }
    }
}

