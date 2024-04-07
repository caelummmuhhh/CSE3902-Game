using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Players.PlayerStates
{
    public class PlayerUsingSwordDownState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly int stateDuration;
        private int currentFrame = 0;

        public PlayerUsingSwordDownState(IPlayer player)
        {
            this.player = player;
            this.player.FacingDirection = Direction.South;
            this.player.Sprite = SpriteFactory.CreatePlayerAttackingDownSprite();
            AnimatedSprite newSprite = (AnimatedSprite)this.player.Sprite;
            stateDuration = newSprite.AnimationFrameDuration;
            player.SwordHitBox = GetSwordHitBox();
        }

        public void Update()
        {
            if (currentFrame == stateDuration)
            {
                player.CurrentState = new PlayerIdleDownState(player);
                player.SwordHitBox = new();
                return;
            }
            player.Sprite.Update();
            player.SwordHitBox = GetSwordHitBox();
        }

        public void Draw()
        {
            currentFrame++;
            player.Sprite.Draw(player.Position.X, player.Position.Y, Color.White);
        }

        public void TakeDamage()
        {
            player.SwordHitBox = new();
            player.CurrentState = new PlayerDamagedDownState(player);
        }

        /* Not useable in this state, therefore not implemented. */
        public void Stop() { }
        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public void UseSword() { }
        public void UseBoomerang() { }
        public void UseFire() { }
        public void UseArrow() { }
        public void UseBomb() { }
        public void UseSwordBeam() { }

        private Rectangle GetSwordHitBox()
        {
            Rectangle playerRectangle = player.MainHitbox;
            return new(
                playerRectangle.X + 7 * Constants.UniversalScale,
                playerRectangle.Y + 16 * Constants.UniversalScale,
                3 * Constants.UniversalScale, 11 * Constants.UniversalScale
                );
        }
    }
}

