using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

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

        public void UseArrow() { }
        public void UseBoomerang() { }
        public void UseFire() { }
        public void UseBomb() { }
        public void UseSwordBeam() { }

    }
}
