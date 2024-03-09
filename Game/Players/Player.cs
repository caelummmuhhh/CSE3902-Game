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

        public bool IsMoving { get; set; }
        public ISprite Sprite { get; set; }
        public IPlayerState CurrentState { get; set; }
        public Vector2 Position { get; set; }
		public Vector2 PreviousPosition { get; set; }

        public Rectangle MainHitbox { get; set; }
        public Rectangle BottomHalfHitBox { get; set; }
		public Rectangle SwordHitBox { get; set; }

        private readonly Game1 game;
        public readonly PlayerProjectilesManager ProjectilesManager;

        public Player(Game1 game)
		{
			ProjectilesManager = new(this);
            Position = new Vector2(100, 100); // TODO: Set spawn position properly
			CurrentState = new PlayerIdleDownState(this);
			this.game = game;
			UpdateHitBoxes();
			SwordHitBox = new();
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
		public void UseBoomerang(CardinalDirections direction) => ProjectilesManager.AddProjectile(new BoomerangProjectile(Position, direction));
        public void UseArrow(CardinalDirections direction) => ProjectilesManager.AddProjectile(new ArrowProjectile(Position, direction));
        public void UseFire(CardinalDirections direction) => ProjectilesManager.AddProjectile(new FireBallProjectile(Position, direction));
		public void UseBomb(CardinalDirections direction) => ProjectilesManager.AddProjectile(new BombProjectile(Position, direction));
		public void UseSwordBeam(CardinalDirections direction) => ProjectilesManager.AddProjectile(new SwordBeamProjectile(Position, direction));

		private void UpdateHitBoxes()
		{
			//MainHitbox = Utils.CentralizeRectangle((int)Position.X, (int)Position.Y, Sprite.DestinationRectangle);
			// TODO: Make it so this doesn't rely on magic number
			MainHitbox = new(
				Sprite.DestinationRectangle.X - 8 * Constants.UniversalScale,
				Sprite.DestinationRectangle.Y - 8 * Constants.UniversalScale,
                Sprite.DestinationRectangle.Width, Sprite.DestinationRectangle.Height
                );

			BottomHalfHitBox = new(
				MainHitbox.X, MainHitbox.Y + MainHitbox.Height / 2,
				MainHitbox.Width, MainHitbox.Height / 2
				);
		}
    }
}

