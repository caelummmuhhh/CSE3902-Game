using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Players.PlayerStates;
using MainGame.Projectiles;

namespace MainGame.Players
{
	public class Player : IPlayer
	{
		public static readonly float Speed = Constants.UniversalScale;
		public static readonly int UsingItemsSpeed = 6;
		public static readonly int KnockedBackDuration = 10;
		public static readonly float KnockedBackSpeed = 10f;

        public ISprite Sprite { get; set; }
        public IPlayerState CurrentState { get; set; }
        public Vector2 Position { get; set; }
		public Vector2 PreviousPosition { get; set; }
        public Direction FacingDirection { get; set; }

        public Rectangle MainHitbox { get; set; }
        public Rectangle BottomHalfHitBox { get; set; }
		public Rectangle SwordHitBox { get; set; }

        private readonly Game1 game;
        public readonly PlayerProjectilesManager ProjectilesManager;

        public Player(Game1 game, Vector2 spawnPosition)
		{
			ProjectilesManager = new(this);
			Position = spawnPosition;
			CurrentState = new PlayerIdleDownState(this);
			this.game = game;
			SwordHitBox = new();
            UpdateHitBoxes();
        }

		public void Update()
		{
			CurrentState.Update();
			ProjectilesManager.Update();
            UpdateHitBoxes();
        }

        public void Draw()
		{
			CurrentState.Draw();
			ProjectilesManager.Draw();
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
		public void UseBoomerang(Direction direction) => ProjectilesManager.AddProjectile(new BoomerangProjectile(Position, direction));
        public void UseArrow(Direction direction) => ProjectilesManager.AddProjectile(new ArrowProjectile(Position, direction));
        public void UseFire(Direction direction) => ProjectilesManager.AddProjectile(new FireBallProjectile(Position, direction));
		public void UseBomb(Direction direction) => ProjectilesManager.AddProjectile(new BombProjectile(Position, direction));
		public void UseSwordBeam(Direction direction) => ProjectilesManager.AddProjectile(new SwordBeamProjectile(Position, direction));

		private void UpdateHitBoxes()
		{
			MainHitbox = new(Position.ToPoint(), Sprite.DestinationRectangle.Size);

			BottomHalfHitBox = new(
				MainHitbox.X, MainHitbox.Y + MainHitbox.Height / 2,
				MainHitbox.Width, MainHitbox.Height / 2
				);
		}
    }
}

