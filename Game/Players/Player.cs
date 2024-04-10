using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Players.PlayerStates;
using MainGame.Projectiles;

namespace MainGame.Players
{
	public class Player : IPlayer
	{
		public static readonly float Speed = Constants.UniversalScale + GameConstants.PlayerSpeedIncrease;
		public static readonly int UsingItemsSpeed = GameConstants.PlayerUsingItemsSpeed;
		public static readonly float KnockedBackSpeed = GameConstants.PlayerKnockedBackSpeed;
		public static readonly int ImmunityFrame = GameConstants.PlayerImmunityFrame;
		public static readonly int KnockedBackDistance = GameConstants.PlayerKnockedBackDistanceFactor * Constants.BlockSize;
        public ISprite Sprite { get; set; }
        public IPlayerState CurrentState { get; set; }
        public Vector2 Position { get; set; }
		public Vector2 PreviousPosition { get; set; }
		public Color SpriteColor { get; set; } = Color.White;
        public Direction FacingDirection { get; set; }
		public bool IsInvulnerable { get => invulnerableTimer > 0; }

        public Rectangle MainHitbox { get; set; }
        public Rectangle BottomHalfHitBox { get; set; }
		public Rectangle SwordHitBox { get; set; }

		private int invulnerableTimer = 0;
        public readonly PlayerProjectilesManager ProjectilesManager;

        public Player(Vector2 spawnPosition)
		{
			ProjectilesManager = new(this);
			Position = spawnPosition;
			CurrentState = new PlayerIdleDownState(this);
			SwordHitBox = new();
            UpdateHitBoxes();
        }

		public void Update()
		{
			CurrentState.Update();
			ProjectilesManager.Update();
            UpdateHitBoxes();

			if (invulnerableTimer > 0)
			{
				invulnerableTimer--;
				FlashColors();
			}
			else
			{
				SpriteColor = Color.White;
			}
        }

        public void Draw()
		{
			CurrentState.Draw();
			ProjectilesManager.Draw();
		}

        public void Stop() => CurrentState.Stop();
		public void TakeDamage(Direction sideHit)
		{
			if (!IsInvulnerable)
			{
				MakeInvulnerable(ImmunityFrame);
				CurrentState.TakeDamage(sideHit);
            }
		}

        public void MakeInvulnerable(int duration) => invulnerableTimer = duration;

        public void MoveUp() => CurrentState.MoveUp();
		public void MoveDown() => CurrentState.MoveDown();
		public void MoveLeft() => CurrentState.MoveLeft();
		public void MoveRight() => CurrentState.MoveRight();

		public void UseSword() => CurrentState.UseSword();
		public void UseBoomerang(Direction direction) => ProjectilesManager.AddProjectile(new PlayerBoomerangProjectile(this, direction));
        public void UseArrow(Direction direction) => ProjectilesManager.AddProjectile(new ArrowProjectile(Position, direction));
        public void UseFire(Direction direction) => ProjectilesManager.AddProjectile(new FireBallProjectile(Position, direction));
		public void UseBomb(Direction direction) => ProjectilesManager.AddProjectile(new BombProjectile(Position, direction));
		public void UseSwordBeam(Direction direction) => ProjectilesManager.AddProjectile(new SwordBeamProjectile(Position, direction));

		private void UpdateHitBoxes()
		{
			MainHitbox = new(Position.ToPoint(), new Point(Constants.BlockSize, Constants.BlockSize));

			BottomHalfHitBox = new(
				MainHitbox.X, MainHitbox.Y + MainHitbox.Height / GameConstants.PlayerHitBoxDivisor,
				MainHitbox.Width, MainHitbox.Height / GameConstants.PlayerHitBoxDivisor
				);
		}

		private void FlashColors()
		{
            SpriteColor = Color.White;
			if (invulnerableTimer % GameConstants.PlayerFlashColorFactor == 0 || invulnerableTimer % GameConstants.PlayerFlashColorFactor == 1)
			{
                SpriteColor = Color.IndianRed;
            }
		}
    }
}
