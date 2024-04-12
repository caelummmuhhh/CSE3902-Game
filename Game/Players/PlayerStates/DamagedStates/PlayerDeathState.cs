using System.Collections.Generic;
using MainGame.Particles;
using MainGame.SpriteHandlers;
using Microsoft.Xna.Framework;

namespace MainGame.Players.PlayerStates
{
    public class PlayerDeathState : IPlayerState
    {
        private enum DeathState
        {
            FlashingColor, SpinAnimation, GreyscaleEffect, DeathParticle, Complete
        }

        private readonly IPlayer player;
        private readonly List<ISprite> spinSprites = new();
        private readonly ISprite lookingDownSprite;

        private int flashingColorDuration = 30;
        private int spinDuration = 15;
        private int greyscaleDuration = 30;
        private Color color = Color.White;
        private readonly IParticle deathParticle;

        private int counter = 0;
        private DeathState currentDeathState = DeathState.FlashingColor;

        public PlayerDeathState(IPlayer player)
        {
            this.player = player;
            deathParticle = ParticleFactory.GetDeathParticle(player.Position);
            lookingDownSprite = SpriteFactory.CreatePlayerIdleDownSprite();
            spinSprites.Add(lookingDownSprite);
            spinSprites.Add(SpriteFactory.CreatePlayerIdleRightSprite());
            spinSprites.Add(SpriteFactory.CreatePlayerIdleUpSprite());
            spinSprites.Add(SpriteFactory.CreatePlayerIdleLeftSprite());
            this.player.Sprite = lookingDownSprite;
        }

        public void Update()
        {
            counter++;
            switch (currentDeathState)
            {
                case DeathState.FlashingColor:
                    UpdateFlashingColor();
                    break;
                case DeathState.SpinAnimation:
                    UpdateSpin();
                    break;
                case DeathState.GreyscaleEffect:
                    UpdateGreyscale();
                    break;
                case DeathState.DeathParticle:
                    deathParticle.Update();
                    currentDeathState = deathParticle.IsActive ? currentDeathState : DeathState.Complete;
                    break;
            }
        }

        private void UpdateFlashingColor()
        {
            if (flashingColorDuration <= 0)
            {
                color = Color.White;
                currentDeathState = DeathState.SpinAnimation;
                return;
            }
            flashingColorDuration--;
            color = (flashingColorDuration % 4 == 0 || flashingColorDuration % 4 == 1) ? Color.Red : Color.White;
        }

        private void UpdateSpin()
        {
            if (spinDuration <= 0)
            {
                currentDeathState = DeathState.GreyscaleEffect;
                return;
            }
            if (counter % 4 == 0)
            {
                spinDuration--;
                player.Sprite = spinSprites[spinDuration % spinSprites.Count];
            }
        }

        private void UpdateGreyscale()
        {
            if (greyscaleDuration <= 0)
            {
                currentDeathState = DeathState.DeathParticle;
                return;
            }
            greyscaleDuration--;
            color = Color.Gray * 0.9f;
        }

        public void Draw()
        {
            if (currentDeathState == DeathState.Complete) { return; }
            if (currentDeathState != DeathState.DeathParticle)
            {
                player.Sprite.Draw(player.Position.X, player.Position.Y, color);
                return;
            }
            deathParticle.Draw();
        }

        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public void MoveUp() { }
        public void Stop() { }
        public void TakeDamage(Direction sideHit) { }
        public void UseItem() { }
        public void UseSword() { }
    }
}
