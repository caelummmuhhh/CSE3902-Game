using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Projectiles;

namespace MainGame.Players.PlayerStates
{
    public class PlayerIdleLeftState : IPlayerState
	{
		private readonly Player player;

		public PlayerIdleLeftState(Player player)
		{
			this.player = player;
			this.player.CurrentSprite = SpriteFactory.CreatePlayerIdleLeftSprite();
		}

        public void Draw()
        {
            player.CurrentSprite.Draw(player.Position.X, player.Position.Y, Color.White);
        }
        public void Update() => player.CurrentSprite.Update();
        public void Stop() { }

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
