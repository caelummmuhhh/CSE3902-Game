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
            this.player.FacingDirection = Direction.South;
			this.player.Sprite = SpriteFactory.CreatePlayerWalkingDownSprite();

            player.Position = new Vector2(
                GridHandler.SnapToGridHalfStep(player.Position).X,
                player.Position.Y
                );
        }

        public void Draw()
		{
            player.Sprite.Draw(player.Position.X, player.Position.Y, Color.White);
        }

        public void MoveDown()
		{
            player.PreviousPosition = player.Position;
			player.Position = new Vector2(player.Position.X, player.Position.Y + Player.Speed);
		}

        public void Update() => player.Sprite.Update();
        public void Stop() => player.CurrentState = new PlayerIdleDownState(player);

        public void TakeDamage() => player.CurrentState = new PlayerDamagedDownState(player);

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

        public void UseArrow()
        {
            player.UseArrow(Direction.South);
            player.CurrentState = new PlayerUsingItemDownState(player);
        }

        public void UseBoomerang()
        {
            player.UseBoomerang(Direction.South);
            player.CurrentState = new PlayerUsingItemDownState(player);
        }

        public void UseFire()
        {
            player.UseFire(Direction.South);
            player.CurrentState = new PlayerUsingItemDownState(player);
        }

        public void UseBomb()
        {
            player.UseBomb(Direction.South);
            player.CurrentState = new PlayerUsingItemDownState(player);
        }

        public void UseSwordBeam()
        {
            player.UseSwordBeam(Direction.South);
            player.CurrentState = new PlayerUsingSwordDownState(player);
        }
    }
}

