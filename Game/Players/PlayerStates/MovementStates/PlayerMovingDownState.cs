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
			this.player.Sprite = SpriteFactory.CreatePlayerWalkingDownSprite();
		}

        public void Draw()
		{
            player.Sprite.Draw(player.Position.X, player.Position.Y, Color.White);
        }

        public void MoveDown()
		{
			player.IsMoving = true;
			player.Position = new Vector2(player.Position.X, player.Position.Y + Player.Speed);
		}

        public void Update() => player.Sprite.Update();
        public void Stop() => player.CurrentState = new PlayerIdleDownState(player);

        public void TakeDamage() => player.CurrentState = new PlayerDamagedDownState(player);

        public void MoveUp() { player.CurrentState = new PlayerMovingUpState(player); }
		public void MoveRight() { player.CurrentState = new PlayerMovingRightState(player); }
		public void MoveLeft() { player.CurrentState = new PlayerMovingLeftState(player); }

        public void UseSword() => player.CurrentState = new PlayerUsingSwordDownState(player);

        public void UseArrow()
        {
            player.UseArrow(Direction.Down);
            player.CurrentState = new PlayerUsingItemDownState(player);
        }

        public void UseBoomerang()
        {
            player.UseBoomerang(Direction.Down);
            player.CurrentState = new PlayerUsingItemDownState(player);
        }

        public void UseFire()
        {
            player.UseFire(Direction.Down);
            player.CurrentState = new PlayerUsingItemDownState(player);
        }

        public void UseBomb()
        {
            player.UseBomb(Direction.Down);
            player.CurrentState = new PlayerUsingItemDownState(player);
        }

        public void UseSwordBeam()
        {
            player.UseSwordBeam(Direction.Down);
            player.CurrentState = new PlayerUsingSwordDownState(player);
        }
    }
}

