using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Players.PlayerStates;
using MainGame.Projectiles;
using MainGame.Audio;
using System;

namespace MainGame.Players
{
	public class Player : IPlayer
	{
		public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int RupeeCount { get; set; }
        public int KeyCount { get; set; }
        public int BombCount { get; set; }
		public ItemTypes[] Items { get; set; }
		public int NumItems { get; set; }
        public ItemTypes CurrentItem { get; set; }

        public static readonly float Speed = Constants.UniversalScale + 2;
		public static readonly int UsingItemsSpeed = 6;
		public static readonly float KnockedBackSpeed = 10f;
		public static readonly int ImmunityFrame = 100;
		public static readonly int KnockedBackDistance = 2 * Constants.BlockSize;

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
		AudioManager SFXPlayer;

        public Player(Vector2 spawnPosition, AudioManager sfxPlayer, int hearts, int rupees, int keys, int bombs, string[] items)
		{
			ProjectilesManager = new(this);
			SFXPlayer = sfxPlayer;
			Position = spawnPosition;
			CurrentState = new PlayerIdleUpState(this);
			SwordHitBox = new();

			MaxHealth = hearts;
			CurrentHealth = hearts;
			RupeeCount = rupees;
			KeyCount = keys;
			BombCount = bombs;

			CurrentItem = ItemTypes.Bomb;

			Items = new ItemTypes[8];
			NumItems = 0;
			if (items[0].Length > 0)
			{
				foreach (string item in items)
				{
					Items[NumItems] = (ItemTypes)Enum.Parse(typeof(ItemTypes), item);
					++NumItems;
				}
			}

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
                SFXPlayer.PlaySFX("Player_Hurt", 0);
            }
		}

        public void MakeInvulnerable(int duration) => invulnerableTimer = duration;

        public void MoveUp() => CurrentState.MoveUp();
		public void MoveDown() => CurrentState.MoveDown();
		public void MoveLeft() => CurrentState.MoveLeft();
		public void MoveRight() => CurrentState.MoveRight();

		public void SelectLeft() 
		{ 
			//TO DO
		}
		public void SelectRight() 
		{
            //TO DO
        }

		public void UseSword()
		{
			CurrentState.UseSword();
            SFXPlayer.PlaySFX("Sword_Attack", 0);
        }
		public void UseBoomerang(Direction direction)
		{
			if (ProjectilesManager.ActiveProjectiles.Count == 0) 
			{
				ProjectilesManager.AddProjectile(new PlayerBoomerangProjectile(this, direction));
                SFXPlayer.PlaySFX("Arrow_And_Boomerang",0); 
            }
		}
		public void UseArrow(Direction direction)
        {
            if (ProjectilesManager.ActiveProjectiles.Count == 0)
            {
                RupeeCount--;
                ProjectilesManager.AddProjectile(new ArrowProjectile(Position, direction));
                SFXPlayer.PlaySFX("Arrow_And_Boomerang", 0);
            }
		}
		public void UseFire(Direction direction)
        {
            if (ProjectilesManager.ActiveProjectiles.Count == 0)
            {
                ProjectilesManager.AddProjectile(new FireBallProjectile(Position, direction));
                SFXPlayer.PlaySFX("Candle", 0);
            }
		}
		public void UseBomb(Direction direction)
		{
			BombCount--;
			ProjectilesManager.AddProjectile(new BombProjectile(Position, direction));
            SFXPlayer.PlaySFX("Bomb_Drop", 0);
            SFXPlayer.PlaySFX("Bomb_Blow", 64);

        }
		public void UseSwordBeam(Direction direction)
        {
            SFXPlayer.PlaySFX("Sword_Attack", 0);
            if (ProjectilesManager.ActiveProjectiles.Count == 0)
            {
                ProjectilesManager.AddProjectile(new SwordBeamProjectile(Position, direction));
                SFXPlayer.PlaySFX("Sword_Beam", 4);
            }
		}

		private void UpdateHitBoxes()
		{
			MainHitbox = new(Position.ToPoint(), new Point(Constants.BlockSize, Constants.BlockSize));

			BottomHalfHitBox = new(
				MainHitbox.X, MainHitbox.Y + MainHitbox.Height / 2,
				MainHitbox.Width, MainHitbox.Height / 2
				);
		}

		private void FlashColors()
		{
            SpriteColor = Color.White;
			if (invulnerableTimer % 4 == 0 || invulnerableTimer % 4 == 1)
			{
                SpriteColor = Color.IndianRed;
            }
		}
    }
}
