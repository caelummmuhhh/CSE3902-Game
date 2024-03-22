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
            this.player.Sprite = SpriteFactory.CreatePlayerWalkingLeftSprite();

            Vector2 playerOriginPosition = new(
                player.Position.X + player.Sprite.DestinationRectangle.Width / 2,
                player.Position.Y + player.Sprite.DestinationRectangle.Height / 2
                );
            player.Position = new Vector2(GridHandler.SnapToGridHalfStep(playerOriginPosition).X, GridHandler.SnapToGridHalfStep(playerOriginPosition).Y);
        }

        public void Draw()
        {
            player.Sprite.Draw(player.Position.X, player.Position.Y, Color.White);
        }

        public void MoveLeft()
        {
            player.PreviousPosition = player.Position;
            player.IsMoving = true;
            player.Position = new(player.Position.X - Player.Speed, player.Position.Y);
        }

        public void Update() => player.Sprite.Update();
        public void Stop() => player.CurrentState = new PlayerIdleLeftState(player);

        public void TakeDamage() => player.CurrentState = new PlayerDamagedLeftState(player);

        public void MoveUp() => player.CurrentState = new PlayerMovingUpState(player);
        public void MoveDown() => player.CurrentState = new PlayerMovingDownState(player);
        public void MoveRight() => player.CurrentState = new PlayerMovingRightState(player);

        public void UseSword() => player.CurrentState = new PlayerUsingSwordLeftState(player);

        public void UseArrow()
        {
            player.UseArrow(CardinalDirections.West);
            player.CurrentState = new PlayerUsingItemLeftState(player);
        }

        public void UseBoomerang()
        {
            player.UseBoomerang(CardinalDirections.West);
            player.CurrentState = new PlayerUsingItemLeftState(player);
        }

        public void UseFire()
        {
            player.UseFire(CardinalDirections.West);
            player.CurrentState = new PlayerUsingItemLeftState(player);
        }

        public void UseBomb()
        {
            player.UseBomb(CardinalDirections.West);
            player.CurrentState = new PlayerUsingItemLeftState(player);
        }

        public void UseSwordBeam()
        {
            player.UseSwordBeam(CardinalDirections.West);
            player.CurrentState = new PlayerUsingSwordLeftState(player);
        }
    }
}

