namespace MainGame.Players.PlayerStates
{
    public class PlayerDamagedLeftState : IPlayerState
    {
		private readonly IPlayer player;
        private int damageTimeRemaining = Player.KnockedBackDuration;

		public PlayerDamagedLeftState(IPlayer player)
		{
			this.player = player;
            this.player.FacingDirection = Direction.West;
		}

        public void Stop() => player.CurrentState = new PlayerIdleLeftState(player);
        public void Update()
        {
            if (damageTimeRemaining <= 0)
            {
                Stop();
            }
            player.Position = new(player.Position.X + Player.KnockedBackSpeed, player.Position.Y);
            damageTimeRemaining--;
        }

        public void Draw() { }

        /* Cannot do while damaged */
        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public void UseSword() { }
        public void TakeDamage() { }
        public void UseArrow() { }
        public void UseBoomerang() { }
        public void UseFire() { }
        public void UseBomb() { }
        public void UseSwordBeam() {  }
    }
}

