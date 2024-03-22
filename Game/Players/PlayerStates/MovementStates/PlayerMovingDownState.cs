using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Projectiles;

namespace MainGame.Players.PlayerStates
{
    public class PlayerMovingDownState : IPlayerState
    {
		private readonly IPlayer player;

		public PlayerMovingDownState(IPlayer player)
		{
			this.player = player;
			this.player.Sprite = SpriteFactory.CreatePlayerWalkingDownSprite();

            Vector2 playerOriginPosition = new(
                player.Position.X + player.Sprite.DestinationRectangle.Width / 2,
                player.Position.Y + player.Sprite.DestinationRectangle.Height / 2
                );
            player.Position = new Vector2(
                GridHandler.SnapToGridHalfStep(playerOriginPosition).X,
                GridHandler.SnapToGridHalfStep(playerOriginPosition).Y
                );
        }

        public void Draw()
		{
            player.Sprite.Draw(player.Position.X, player.Position.Y, Color.White);
        }

        public void MoveDown()
		{
            player.PreviousPosition = player.Position;
			player.IsMoving = true;
			player.Position = new Vector2(player.Position.X, player.Position.Y + Player.Speed);
		}

        public void Update() => player.Sprite.Update();
        public void Stop() => player.CurrentState = new PlayerIdleDownState(player);

        public void TakeDamage() => player.CurrentState = new PlayerDamagedDownState(player);

        public void MoveUp() { player.CurrentState = new PlayerMovingUpState(player); }

		public void MoveRight()
        {
            player.Position = new(player.Position.X, player.Position.Y + 16f * 0.5f * Constants.UniversalScale);
            player.CurrentState = new PlayerMovingRightState(player);
        }
		public void MoveLeft() { player.CurrentState = new PlayerMovingLeftState(player); }

        public void UseSword() => player.CurrentState = new PlayerUsingSwordDownState(player);

        public void UseArrow()
        {
            player.UseArrow(CardinalDirections.South);
            player.CurrentState = new PlayerUsingItemDownState(player);
        }

        public void UseBoomerang()
        {
            player.UseBoomerang(CardinalDirections.South);
            player.CurrentState = new PlayerUsingItemDownState(player);
        }

        public void UseFire()
        {
            player.UseFire(CardinalDirections.South);
            player.CurrentState = new PlayerUsingItemDownState(player);
        }

        public void UseBomb()
        {
            player.UseBomb(CardinalDirections.South);
            player.CurrentState = new PlayerUsingItemDownState(player);
        }

        public void UseSwordBeam()
        {
            player.UseSwordBeam(CardinalDirections.South);
            player.CurrentState = new PlayerUsingSwordDownState(player);
        }
    }
}

