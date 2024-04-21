using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Players.PlayerStates
{
    public class PlayerMovingDownState : IPlayerState
    {
		private readonly IPlayer player;

		public PlayerMovingDownState(IPlayer player)
		{
			this.player = player;
            this.player.FacingDirection = Direction.South;
			this.player.Sprite = SpriteFactory.CreatePlayerWalkingDownSprite();

            player.Position = new Vector2(
                GridHandler.SnapToGridHalfStep(player.Position).X,
                player.Position.Y
                );
        }

        public void Draw()
		{
            player.Sprite.Draw(player.Position.X, player.Position.Y, player.SpriteColor);
        }

        public void MoveDown()
		{
            player.PreviousPosition = player.Position;
			player.Position = new Vector2(player.Position.X, player.Position.Y + Player.Speed);
		}

        public void Update() => player.Sprite.Update();
        public void Stop() => player.CurrentState = new PlayerIdleDownState(player);

        public void TakeDamage(Direction sideHit)
            => player.CurrentState = new PlayerKnockedBackState(player, Utils.OppositeDirection(sideHit));

        public void MoveUp() { player.CurrentState = new PlayerMovingUpState(player); }

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

        public void UseSword() => player.CurrentState = new PlayerUsingSwordDownState(player);
        public void UseEquipment()
        {
            if (player.Inventory.EquippedItem is not null && player.Inventory.EquippedItem.IsUseable)
            {
                player.CurrentState = new PlayerUsingItemDownState(player);
            }
        }
    }
}

