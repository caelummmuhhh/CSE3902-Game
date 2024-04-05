using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Projectiles;

namespace MainGame.Players.PlayerStates
{
    public class PlayerMovingRightState : IPlayerState
    {
		private readonly IPlayer player;

		public PlayerMovingRightState(IPlayer player)
		{
			this.player = player;
			this.player.Sprite = SpriteFactory.CreatePlayerWalkingRightSprite();

            player.Position = new Vector2(player.Position.X, GridHandler.SnapToGridHalfStep(player.Position).Y);
        }

        public void Draw()
		{
			player.Sprite.Draw(player.Position.X, player.Position.Y, Color.White);
		}

        public void MoveRight()
		{
            player.PreviousPosition = player.Position;
            player.IsMoving = true;
			player.Position = new(player.Position.X + Player.Speed, player.Position.Y);
		}

        public void Update() => player.Sprite.Update();
        public void Stop() => player.CurrentState = new PlayerIdleRightState(player);

        public void TakeDamage() => player.CurrentState = new PlayerDamagedRightState(player);

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

        public void UseArrow()
        {
            player.UseArrow(CardinalDirections.East);
            player.CurrentState = new PlayerUsingItemRightState(player);
        }

        public void UseBoomerang()
        {
            player.UseBoomerang(CardinalDirections.East);
            player.CurrentState = new PlayerUsingItemRightState(player);
        }

        public void UseFire()
        {
            player.UseFire(CardinalDirections.East);
            player.CurrentState = new PlayerUsingItemRightState(player);
        }

        public void UseBomb()
        {
            player.UseBomb(CardinalDirections.East);
            player.CurrentState = new PlayerUsingItemRightState(player);
        }

        public void UseSwordBeam()
        {
            player.UseSwordBeam(CardinalDirections.East);
            player.CurrentState = new PlayerUsingSwordRightState(player);
        }
    }
}

