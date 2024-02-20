using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Projectiles;

namespace MainGame.Players.PlayerStates
{
    public class PlayerIdleLeftState : IPlayerState
	{
		private readonly IPlayer player;

		public PlayerIdleLeftState(IPlayer player)
		{
			this.player = player;
			this.player.Sprite = SpriteFactory.CreatePlayerIdleLeftSprite();
		}

        public void Draw()
        {
            player.Sprite.Draw(player.Position.X, player.Position.Y, Color.White, TODO, TODO);
        }
        public void Update() => player.Sprite.Update();
        public void Stop() { }

        public void TakeDamage() => player.CurrentState = new PlayerDamagedLeftState(player);

        public void MoveUp() => player.CurrentState = new PlayerMovingUpState(player);
        public void MoveDown() => player.CurrentState = new PlayerMovingDownState(player);
        public void MoveRight() => player.CurrentState = new PlayerMovingRightState(player);
        public void MoveLeft() => player.CurrentState = new PlayerMovingLeftState(player);
        public void UseSword() => player.CurrentState = new PlayerUsingSwordLeftState(player);

        public void UseArrow()
        {
            player.UseArrow(Direction.Left);
            player.CurrentState = new PlayerUsingItemLeftState(player);
        }

        public void UseBoomerang()
        {
            player.UseBoomerang(Direction.Left);
            player.CurrentState = new PlayerUsingItemLeftState(player);
        }

        public void UseFire()
        {
            player.UseFire(Direction.Left);
            player.CurrentState = new PlayerUsingItemLeftState(player);
        }

        public void UseBomb()
        {
            player.UseBomb(Direction.Left);
            player.CurrentState = new PlayerUsingItemLeftState(player);
        }

        public void UseSwordBeam()
        {
            player.UseSwordBeam(Direction.Left);
            player.CurrentState = new PlayerUsingSwordLeftState(player);
        }
    }
}
