using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Projectiles;

namespace MainGame.Players.PlayerStates
{
	public class PlayerMovingUpState : IPlayerState
	{
		private readonly IPlayer player;

		public PlayerMovingUpState(IPlayer player)
		{
            this.player = player;
            this.player.Sprite = SpriteFactory.CreatePlayerWalkingUpSprite();

            player.Position = new Vector2(GridHandler.SnapToGridHalfStep(player.Position).X, player.Position.Y);
        }

        public void Draw()
        {
            player.Sprite.Draw(player.Position.X, player.Position.Y, Color.White);
        }

        public void MoveUp()
        {
            player.PreviousPosition = player.Position;
            player.IsMoving = true;
            player.Position = new(player.Position.X, player.Position.Y - Player.Speed);
        }

        public void Update() => player.Sprite.Update();
        public void Stop() => player.CurrentState = new PlayerIdleUpState(player);

        public void TakeDamage() => player.CurrentState = new PlayerDamagedUpState(player);

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

        public void UseArrow()
        {
            player.UseArrow(CardinalDirections.North);
            player.CurrentState = new PlayerUsingItemUpState(player);
        }

        public void UseBoomerang()
        {
            player.UseBoomerang(CardinalDirections.North);
            player.CurrentState = new PlayerUsingItemUpState(player);
        }

        public void UseFire()
        {
            player.UseFire(CardinalDirections.North);
            player.CurrentState = new PlayerUsingItemUpState(player);
        }

        public void UseBomb()
        {
            player.UseBomb(CardinalDirections.North);
            player.CurrentState = new PlayerUsingItemUpState(player);
        }

        public void UseSwordBeam()
        {
            player.UseSwordBeam(CardinalDirections.North);
            player.CurrentState = new PlayerUsingSwordUpState(player);
        }
    }
}

