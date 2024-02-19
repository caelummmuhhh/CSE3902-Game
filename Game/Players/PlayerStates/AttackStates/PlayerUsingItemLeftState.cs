﻿using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Players.PlayerStates
{
	public class PlayerUsingItemLeftState : IPlayerState
    {
        private readonly Player player;
        private readonly int stateDuration;
        private int currentFrame = 0;

        public PlayerUsingItemLeftState(Player player)
        {
            this.player = player;
            this.player.CurrentSprite = SpriteFactory.CreatePlayerInteractingLeftSprite();
            stateDuration = Player.UsingItemsSpeed;
        }

        public void Update()
        {
            if (currentFrame == stateDuration)
            {
                Stop();
            }
            player.CurrentSprite.Update();
        }

        public void Draw()
        {
            currentFrame++;
            player.CurrentSprite.Draw(player.Position.X, player.Position.Y, Color.White);
        }

        public void Stop() => player.CurrentState = new PlayerIdleLeftState(player);

        /* Not useable in this state, therefore not implemented. */
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
    }
}
