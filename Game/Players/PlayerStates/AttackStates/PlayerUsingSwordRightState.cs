﻿using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Audio;

namespace MainGame.Players.PlayerStates
{
    public class PlayerUsingSwordRightState : IPlayerState
    {
		private readonly IPlayer player;
		private readonly int stateDuration;
        private int currentFrame = 0;

        public PlayerUsingSwordRightState(IPlayer player)
		{
			this.player = player;
            this.player.FacingDirection = Direction.East;
			this.player.Sprite = SpriteFactory.CreatePlayerAttackingRightSprite();
            AnimatedSprite newSprite = (AnimatedSprite)this.player.Sprite;
            stateDuration = newSprite.AnimationFrameDuration;
            player.SwordHitBox = GetSwordHitBox();
            AudioManager.PlaySFX("Sword_Attack", 0);
        }

        public void Update()
		{
			if (currentFrame == stateDuration)
			{
                player.CurrentState = new PlayerIdleRightState(player);
                player.SwordHitBox = new();
                return;
            }
            player.Sprite.Update();
            player.SwordHitBox = GetSwordHitBox();
        }

        public void Draw()
		{
            currentFrame++;
            player.Sprite.Draw(player.Position.X, player.Position.Y, player.SpriteColor);
		}

        public void TakeDamage(Direction sideHit)
        {
            player.SwordHitBox = new();
            player.CurrentState = new PlayerKnockedBackState(player, Utils.OppositeDirection(sideHit));
        }

        /* Not useable in this state, therefore not implemented. */
        public void Stop() { }
        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public void UseSword() { }
        public void UseEquipment() { }

        private Rectangle GetSwordHitBox()
        {
            Rectangle playerRectangle = player.MainHitbox;
            return new(
                playerRectangle.X + 16 * Constants.UniversalScale,
                playerRectangle.Y + 8 * Constants.UniversalScale,
                11 * Constants.UniversalScale, 3 * Constants.UniversalScale
                );
        }
    }
}

