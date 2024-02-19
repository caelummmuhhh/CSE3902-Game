namespace MainGame.Players.PlayerStates
{
	public interface IPlayerState
	{
		public void MoveUp();
		public void MoveDown();
		public void MoveLeft();
		public void MoveRight();

		public void UseSword();

		public void Update();
		public void Draw();
		public void Stop();

		// sprint2 specific
		public void UseArrow();
		public void UseBoomerang();
		public void UseFire();
		public void UseBomb();
		public void UseSwordBeam();
	}
}
