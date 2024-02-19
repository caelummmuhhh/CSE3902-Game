using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Players.PlayerStates
{
	public class PlayerMovingUpState : IPlayerState
	{
		private readonly Player player;

		public PlayerMovingUpState(Player player)
		{
			this.player = player;
            player.CurrentSprite = SpriteFactory.CreatePlayerWalkingUpSprite();
		}

        public void Draw()
        {
            player.CurrentSprite.Draw(player.Position.X, player.Position.Y, Color.White);
        }

        public void MoveUp()
        {
            player.IsMoving = true;
            player.Position = new(player.Position.X, player.Position.Y - Player.Speed);
        }

        public void Update() => player.CurrentSprite.Update();
        public void Stop() => player.CurrentState = new PlayerIdleUpState(player);

        public void MoveDown() => player.CurrentState = new PlayerMovingDownState(player);
        public void MoveLeft() => player.CurrentState = new PlayerMovingLeftState(player);
        public void MoveRight() => player.CurrentState = new PlayerMovingRightState(player);

        public void UseSword() => player.CurrentState = new PlayerUsingSwordUpState(player);

        public void UseArrow() => player.CurrentState = new PlayerUsingItemUpState(player);
        public void UseBoomerang() => player.CurrentState = new PlayerUsingItemUpState(player);
        public void UseFire() => player.CurrentState = new PlayerUsingItemUpState(player);
        public void UseBomb() => player.CurrentState = new PlayerUsingItemUpState(player);
        public void UseSwordBeam() => player.CurrentState = new PlayerUsingSwordUpState(player);
    }
}

