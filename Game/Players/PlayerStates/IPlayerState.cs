﻿namespace MainGame.Players.PlayerStates
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
		public void TakeDamage(Direction sideHit);
		public void UseEquipment();
	}
}
