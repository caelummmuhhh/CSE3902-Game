using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Players.PlayerStates;
using MainGame.Projectiles;

namespace MainGame.Players
{
	public class Player : IPlayer
	{
        public Vector2 Position;
		public ISprite CurrentSprite;
		public bool IsMoving;
		public static readonly float Speed = 5f;
		public static readonly int UsingItemsSpeed = 10;

		private PlayerProjectilesManager projectilesManager;

        private IPlayerState currentState;
        public IPlayerState CurrentState
		{
			get => currentState;
			set => currentState = value;
		}

		private readonly Game game;

		public Player(Game game)
		{
			projectilesManager = new(this);
            Position = new Vector2(0, 0);
			currentState = new PlayerIdleDownState(this);
			this.game = game;
		}

		public void Update()
		{
			currentState.Update();
			projectilesManager.Update();
		}

		public void Draw()
		{
			currentState.Draw();
			projectilesManager.Draw();
		}

        public void Stop() => currentState.Stop();

        public void MoveUp() => currentState.MoveUp();
		public void MoveDown() => currentState.MoveDown();
		public void MoveLeft() => currentState.MoveLeft();
		public void MoveRight() => currentState.MoveRight();

		public void UseSword() => currentState.UseSword();

		public void UseBoomerang(Direction direction) => projectilesManager.AddProjectile(new BoomerangProjectile(Position, direction));
        public void UseArrow(Direction direction) => projectilesManager.AddProjectile(new ArrowProjectile(Position, direction));
        public void UseFire(Direction direction) => projectilesManager.AddProjectile(new FireBallProjectile(Position, direction));
		public void UseBomb(Direction direction) => projectilesManager.AddProjectile(new BombProjectile(Position, direction));
		public void UseSwordBeam(Direction direction) => projectilesManager.AddProjectile(new SwordBeamProjectile(Position, direction));
    }
}

