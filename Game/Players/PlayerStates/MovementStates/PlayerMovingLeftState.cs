using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Projectiles;

namespace MainGame.Players.PlayerStates
{
    public class PlayerMovingLeftState : IPlayerState
    {
        private readonly Player player;

		public PlayerMovingLeftState(Player player)
		{
            this.player = player;
            this.player.CurrentSprite = SpriteFactory.CreatePlayerWalkingLeftSprite();
		}

        public void Draw()
        {
            player.CurrentSprite.Draw(player.Position.X, player.Position.Y, Color.White);
        }

        public void MoveLeft()
        {
            player.IsMoving = true;
            player.Position = new(player.Position.X - Player.Speed, player.Position.Y);
        }

        public void Update() => player.CurrentSprite.Update();
        public void Stop() => player.CurrentState = new PlayerIdleLeftState(player);

        public void MoveUp() => player.CurrentState = new PlayerMovingUpState(player);
        public void MoveDown() => player.CurrentState = new PlayerMovingDownState(player);
        public void MoveRight() => player.CurrentState = new PlayerMovingRightState(player);

        public void UseSword() => player.CurrentState = new PlayerUsingSwordLeftState(player);

        public void UseArrow() => player.CurrentState = new PlayerUsingItemLeftState(player);
        public void UseBoomerang()
        {
            player.UseBoomerang(Direction.Left);
            player.CurrentState = new PlayerUsingItemLeftState(player);
        }
        public void UseFire() => player.CurrentState = new PlayerUsingItemLeftState(player);
        public void UseBomb() => player.CurrentState = new PlayerUsingItemLeftState(player);
        public void UseSwordBeam() => player.CurrentState = new PlayerUsingSwordLeftState(player);
    }
}

