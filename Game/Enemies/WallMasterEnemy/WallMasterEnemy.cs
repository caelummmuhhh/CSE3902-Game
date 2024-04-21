﻿using Microsoft.Xna.Framework;
using MainGame.Players;
using MainGame.SpriteHandlers;
using MainGame.Audio;

namespace MainGame.Enemies
{
	public class WallMasterEnemy : GenericEnemy
	{
        public override int Health { get; protected set; } = 3;
        public override int Damage => 2;
        public override int MovementCoolDownFrame { get; protected set; } = 1;
        public readonly IPlayer Player;

        public WallMasterEnemy(Vector2 startingPosition, AudioManager audioManager, IPlayer player)
		{
			Sprite = SpriteFactory.CreateWallMasterSprite();
            AudioManager = audioManager;
            Player = player;
            Position = startingPosition;
            PreviousPosition = new(Position.X, Position.Y);
        }

        public override void Move()
        {
            // TODO
        }
        public override void Draw() => Sprite.Draw(Position.X, Position.Y, SpriteColor);

        public override void TakeDamage(Direction sideHit, int damage)
        {
            if (!IsInvulnerable)
            {
                DamageState = new EnemyDamagedState(this, sideHit, false);
                Health -= damage;
                CheckForDeath();
            }
        }
    }
}

