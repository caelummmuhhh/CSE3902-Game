﻿using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Players.PlayerStates;
using MainGame.Projectiles;
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

        public Player(Vector2 spawnPosition, int hearts, int rupees, int keys, int bombs, string[] items)
		{
			ProjectilesManager = new(this);
			Position = spawnPosition;
			CurrentState = new PlayerIdleUpState(this);
			SwordHitBox = new();

			MaxHealth = hearts;
			CurrentHealth = MaxHealth;
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

        public void UseSword() => CurrentState.UseSword();
		public void UseBoomerang(Direction direction) => ProjectilesManager.AddProjectile(new PlayerBoomerangProjectile(this, direction));
		public void UseArrow(Direction direction)
		{
			RupeeCount--;
			ProjectilesManager.AddProjectile(new ArrowProjectile(Position, direction));
		}
        public void UseFire(Direction direction) => ProjectilesManager.AddProjectile(new FireBallProjectile(Position, direction));
		public void UseBomb(Direction direction)
		{
			BombCount--;
			ProjectilesManager.AddProjectile(new BombProjectile(Position, direction));
		}
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
