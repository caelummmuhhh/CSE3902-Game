using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Players.PlayerStates
{
    public class PlayerMovingRightState : IPlayerState
    {
		private readonly Player player;

		public PlayerMovingRightState(Player player)
		{
			this.player = player;
			this.player.CurrentSprite = SpriteFactory.CreatePlayerWalkingRightSprite();
		}

        public void Draw()
		{
			player.CurrentSprite.Draw(player.Position.X, player.Position.Y, Color.White);
		}

        public void MoveRight()
		{
			player.IsMoving = true;
			player.Position = new(player.Position.X + Player.Speed, player.Position.Y);
		}

        public void Update() => player.CurrentSprite.Update();
        public void Stop() => player.CurrentState = new PlayerIdleRightState(player);

        public void MoveUp() => player.CurrentState = new PlayerMovingUpState(player);
		public void MoveDown() => player.CurrentState = new PlayerMovingDownState(player);
		public void MoveLeft() => player.CurrentState = new PlayerMovingLeftState(player);

        public void UseSword() => player.CurrentState = new PlayerUsingSwordRightState(player);

        public void UseArrow() => player.CurrentState = new PlayerUsingItemRightState(player);
        public void UseBoomerang() => player.CurrentState = new PlayerUsingItemRightState(player);
        public void UseFire() => player.CurrentState = new PlayerUsingItemRightState(player);
        public void UseBomb() => player.CurrentState = new PlayerUsingItemRightState(player);
        public void UseSwordBeam() => player.CurrentState = new PlayerUsingSwordRightState(player);
    }
}

