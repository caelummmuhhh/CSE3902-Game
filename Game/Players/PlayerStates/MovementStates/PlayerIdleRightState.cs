﻿using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Projectiles;

namespace MainGame.Players.PlayerStates
{
    public class PlayerIdleRightState : IPlayerState
    {
        private readonly IPlayer player;

        public PlayerIdleRightState(IPlayer player)
        {
            this.player = player;
            this.player.Sprite = SpriteFactory.CreatePlayerIdleRightSprite();
        }

        public void Draw()
        {
            player.Sprite.Draw(player.Position.X, player.Position.Y, Color.White, TODO, TODO);
        }
        public void Update() => player.Sprite.Update();
        public void Stop() { }

        public void TakeDamage() => player.CurrentState = new PlayerDamagedRightState(player);

        public void MoveUp() => player.CurrentState = new PlayerMovingUpState(player);
        public void MoveDown() => player.CurrentState = new PlayerMovingDownState(player);
        public void MoveRight() => player.CurrentState = new PlayerMovingRightState(player);
        public void MoveLeft() => player.CurrentState = new PlayerMovingLeftState(player);
        public void UseSword() => player.CurrentState = new PlayerUsingSwordRightState(player);

        public void UseArrow()
        {
            player.UseArrow(Direction.Right);
            player.CurrentState = new PlayerUsingItemRightState(player);
        }

        public void UseBoomerang()
        {
            player.UseBoomerang(Direction.Right);
            player.CurrentState = new PlayerUsingItemRightState(player);
        }

        public void UseFire()
        {
            player.UseFire(Direction.Right);
            player.CurrentState = new PlayerUsingItemRightState(player);
        }

        public void UseBomb()
        {
            player.UseBomb(Direction.Right);
            player.CurrentState = new PlayerUsingItemRightState(player);
        }

        public void UseSwordBeam()
        {
            player.UseSwordBeam(Direction.Right);
            player.CurrentState = new PlayerUsingSwordRightState(player);
        }
    }
}
