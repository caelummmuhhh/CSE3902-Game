using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Projectiles;

namespace MainGame.Players.PlayerStates
{
    public class PlayerMovingDownState : IPlayerState
    {
		private readonly Player player;

		public PlayerMovingDownState(Player player)
		{
			this.player = player;
			this.player.CurrentSprite = SpriteFactory.CreatePlayerWalkingDownSprite();
		}

        public void Draw()
		{
            player.CurrentSprite.Draw(player.Position.X, player.Position.Y, Color.White);
        }

        public void MoveDown()
		{
			player.IsMoving = true;
			player.Position = new Vector2(player.Position.X, player.Position.Y + Player.Speed);
		}

        public void Update() => player.CurrentSprite.Update();
        public void Stop() => player.CurrentState = new PlayerIdleDownState(player);

        public void MoveUp() { player.CurrentState = new PlayerMovingUpState(player); }
		public void MoveRight() { player.CurrentState = new PlayerMovingRightState(player); }
		public void MoveLeft() { player.CurrentState = new PlayerMovingLeftState(player); }

        public void UseSword() => player.CurrentState = new PlayerUsingSwordDownState(player);

        public void UseArrow() => player.CurrentState = new PlayerUsingItemDownState(player);

        public void UseBoomerang()
        {
            player.UseBoomerang(Direction.Down);
            player.CurrentState = new PlayerUsingItemDownState(player);
        }

        public void UseFire() => player.CurrentState = new PlayerUsingItemDownState(player);
        public void UseBomb() => player.CurrentState = new PlayerUsingItemDownState(player);
        public void UseSwordBeam() => player.CurrentState = new PlayerUsingSwordDownState(player);
    }
}

