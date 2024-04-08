using MainGame.SpriteHandlers;

namespace MainGame.Players.PlayerStates
{
    public class PlayerIdleLeftState : IPlayerState
	{
		private readonly IPlayer player;

		public PlayerIdleLeftState(IPlayer player)
		{
			this.player = player;
            this.player.FacingDirection = Direction.West;
			this.player.Sprite = SpriteFactory.CreatePlayerIdleLeftSprite();
		}

        public void Draw()
        {
            player.Sprite.Draw(player.Position.X, player.Position.Y, player.SpriteColor);
        }
        public void Update() => player.Sprite.Update();
        public void Stop() { }

        public void TakeDamage(Direction sideHit)
            => player.CurrentState = new PlayerKnockedBackState(player, Utils.OppositeDirection(sideHit));

        public void MoveUp() => player.CurrentState = new PlayerMovingUpState(player);
        public void MoveDown() => player.CurrentState = new PlayerMovingDownState(player);
        public void MoveRight() => player.CurrentState = new PlayerMovingRightState(player);
        public void MoveLeft() => player.CurrentState = new PlayerMovingLeftState(player);
        public void UseSword() => player.CurrentState = new PlayerUsingSwordLeftState(player);

        public void UseArrow()
        {
            player.UseArrow(Direction.West);
            player.CurrentState = new PlayerUsingItemLeftState(player);
        }

        public void UseBoomerang()
        {
            player.UseBoomerang(Direction.West);
            player.CurrentState = new PlayerUsingItemLeftState(player);
        }

        public void UseFire()
        {
            player.UseFire(Direction.West);
            player.CurrentState = new PlayerUsingItemLeftState(player);
        }

        public void UseBomb()
        {
            player.UseBomb(Direction.West);
            player.CurrentState = new PlayerUsingItemLeftState(player);
        }

        public void UseSwordBeam()
        {
            player.UseSwordBeam(Direction.West);
            player.CurrentState = new PlayerUsingSwordLeftState(player);
        }
    }
}
