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

        public void Update() { player.CurrentSprite.Update(); }
        public void Draw()
		{
			player.CurrentSprite.Draw(player.Position.X, player.Position.Y, Color.White);
		}
        public void Stop() { player.CurrentState = new PlayerIdleState(player, Directions.Right); }

        public void MoveRight()
		{
			player.IsMoving = true;
			player.Position = new(player.Position.X + Player.Speed, player.Position.Y);
		}

		public void MoveUp() { player.CurrentState = new PlayerMovingUpState(player); }
		public void MoveDown() { player.CurrentState = new PlayerMovingDownState(player); }
		public void MoveLeft() { player.CurrentState = new PlayerMovingLeftState(player); }

        public void UseSword() { }

        public void UseArrow() { }
        public void UseBoomerang() { }
        public void UseFire() { }
        public void UseBomb() { }
        public void UseSwordBeam() { }
    }
}

