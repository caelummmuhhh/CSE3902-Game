using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Players.PlayerStates
{
    public class PlayerMovingRightState : IPlayerState
    {
		private readonly IPlayer player;

		public PlayerMovingRightState(IPlayer player)
		{
			this.player = player;
            this.player.FacingDirection = Direction.East;
			this.player.Sprite = SpriteFactory.CreatePlayerWalkingRightSprite();

            player.Position = new Vector2(player.Position.X, GridHandler.SnapToGridHalfStep(player.Position).Y);
        }

        public void Draw()
		{
			player.Sprite.Draw(player.Position.X, player.Position.Y, player.SpriteColor);
		}

        public void MoveRight()
		{
            player.PreviousPosition = new Vector2(player.Position.X, player.Position.Y);
			player.Position = new(player.Position.X + Player.Speed, player.Position.Y);
		}

        public void Update() => player.Sprite.Update();
        public void Stop() => player.CurrentState = new PlayerIdleRightState(player);

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

