using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Players.PlayerStates;
using MainGame.Projectiles;

namespace MainGame.Players
{
	public class Player : IPlayer
	{
		public static readonly float Speed = 5f;
		public static readonly int UsingItemsSpeed = 10;
		public static readonly int KnockedBackDuration = 10;
		public static readonly float KnockedBackSpeed = 10f;

		private readonly PlayerProjectilesManager projectilesManager;

        public bool IsMoving { get; set; }
        public ISprite Sprite { get; set; }
        public IPlayerState CurrentState { get; set; }
        public Vector2 Position { get; set; }

        private readonly Game1 game;

		public Player(Game1 game)
		{
			projectilesManager = new(this);
            Position = new Vector2(0, 0);
			CurrentState = new PlayerIdleDownState(this);
			this.game = game;
		}

		public void Update()
		{
			CurrentState.Update();
			projectilesManager.Update();
		}

		public void Draw()
		{
			CurrentState.Draw();
			projectilesManager.Draw();
		}

        public void Stop() => CurrentState.Stop();

		public void TakeDamage()
        {
			CurrentState.TakeDamage();
			game.Player = new DamagedPlayer(this, game);
        }

        public void MoveUp() => CurrentState.MoveUp();
		public void MoveDown() => CurrentState.MoveDown();
		public void MoveLeft() => CurrentState.MoveLeft();
		public void MoveRight() => CurrentState.MoveRight();

		public void UseSword() => CurrentState.UseSword();

		public void UseBoomerang(Direction direction) => projectilesManager.AddProjectile(new BoomerangProjectile(Position, direction));
        public void UseArrow(Direction direction) => projectilesManager.AddProjectile(new ArrowProjectile(Position, direction));
        public void UseFire(Direction direction) => projectilesManager.AddProjectile(new FireBallProjectile(Position, direction));
		public void UseBomb(Direction direction) => projectilesManager.AddProjectile(new BombProjectile(Position, direction));
		public void UseSwordBeam(Direction direction) => projectilesManager.AddProjectile(new SwordBeamProjectile(Position, direction));
    }
}

