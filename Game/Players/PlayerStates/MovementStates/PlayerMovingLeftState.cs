using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Projectiles;

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
            player.Sprite.Draw(player.Position.X, player.Position.Y, Color.White);
        }

        public void MoveLeft()
        {
            player.PreviousPosition = player.Position;
            player.Position = new(player.Position.X - Player.Speed, player.Position.Y);
        }

        public void Update() => player.Sprite.Update();
        public void Stop() => player.CurrentState = new PlayerIdleLeftState(player);

        public void TakeDamage() => player.CurrentState = new PlayerDamagedLeftState(player);

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

        public void UseArrow()
        {
            player.UseArrow(Direction.West);
            player.CurrentState = new PlayerUsingItemLeftState(player);
        }

        public void UseBoomerang()
        {
            player.UseBoomerang(Direction.West);
            player.CurrentState = new PlayerUsingItemLeftState(player);
        }

        public void UseFire()
        {
            player.UseFire(Direction.West);
            player.CurrentState = new PlayerUsingItemLeftState(player);
        }

        public void UseBomb()
        {
            player.UseBomb(Direction.West);
            player.CurrentState = new PlayerUsingItemLeftState(player);
        }

        public void UseSwordBeam()
        {
            player.UseSwordBeam(Direction.West);
            player.CurrentState = new PlayerUsingSwordLeftState(player);
        }
    }
}

