﻿using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Players.PlayerStates;
using MainGame.Players.Inventory;
using MainGame.Rooms;
using MainGame.Projectiles;
using MainGame.Audio;
using System;

namespace MainGame.Players
{
	public class Player : IPlayer
	{
        public static readonly float Speed = Constants.UniversalScale + 2;
        public static readonly int UsingItemsSpeed = 6;
        public static readonly float KnockedBackSpeed = 10f;
        public static readonly int ImmunityFrame = 100;
        public static readonly int KnockedBackDistance = 2 * Constants.BlockSize;

        public int MaxHealth { get; protected set; }
        public int CurrentHealth { get; protected set; }
        public ILinkInventory Inventory { get; protected set; }
        public ISprite Sprite { get; set; }
        public IPlayerState CurrentState { get; set; }
        public Vector2 Position { get; set; }
		public Vector2 PreviousPosition { get; set; }
		public Color SpriteColor { get; set; } = Color.White;
        public Direction FacingDirection { get; set; }
		public bool IsInvulnerable { get => invulnerableTimer > 0; }

        public Rectangle MainHitbox { get; protected set; }
        public Rectangle BottomHalfHitBox { get; protected set; }
		public Rectangle SwordHitBox { get; set; }

        private readonly GameRoomManager roomManager;
		private readonly AudioManager SFXPlayer;
        private int invulnerableTimer = 0;
		private IProjectile swordBeam;

        public Player(Vector2 spawnPosition, GameRoomManager roomManager, AudioManager sfxPlayer, int[] startingItemIds,
					  int maxHearts = 6, int rupees = 0, int keys = 0, int bombs = 0)
		{
			ProjectilesManager = new(this);
			SFXPlayer = sfxPlayer;
			Position = spawnPosition;
			CurrentState = new PlayerIdleUpState(this);
			SwordHitBox = new();
			MaxHealth = maxHearts;
			CurrentHealth = MaxHealth;
			Inventory = new LinkInventory(this, roomManager, startingItemIds, rupees, keys, bombs);
			this.roomManager = roomManager;
            UpdateHitBoxes();
        }

		public void Update()
		{
			CurrentState.Update();
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

        public void Draw() => CurrentState.Draw();

        public void Stop() => CurrentState.Stop();

		public void TakeDamage(Direction sideHit, int damageAmount)
		{
			if (!IsInvulnerable)
			{
                CurrentHealth -= damageAmount;
				if (CurrentHealth > 0)
				{
                    MakeInvulnerable(ImmunityFrame);
                    CurrentState.TakeDamage(sideHit);
					SFXPlayer.PlaySFX("Player_Hurt", 0);
					return;
                }
				CurrentState = new PlayerDeathState(this);
            }
		}

		public void Heal(int amount) => CurrentHealth = CurrentHealth + amount >= MaxHealth ? MaxHealth : CurrentHealth + amount;
        public void MakeInvulnerable(int duration) => invulnerableTimer = duration;
        public void IncreaseMaxHP(int amount = 2) => MaxHealth += amount;

        public void MoveUp() => CurrentState.MoveUp();
		public void MoveDown() => CurrentState.MoveDown();
		public void MoveLeft() => CurrentState.MoveLeft();
		public void MoveRight() => CurrentState.MoveRight();
		public void UseEquipment() => CurrentState.UseEquipment();

        public void UseSword()
		{
			SFXPlayer.PlaySFX("Sword_Attack", 0);
            CurrentState.UseSword();
            if (CurrentHealth == MaxHealth && swordBeam is not null && swordBeam.IsActive)
			{
				SFXPlayer.PlaySFX("Sword_Beam", 4);
				swordBeam = ProjectileFactory.GetSwordBeamProjectile(Position, FacingDirection);
				roomManager.CurrentRoom.PlayerProjectiles.Add(swordBeam);
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
