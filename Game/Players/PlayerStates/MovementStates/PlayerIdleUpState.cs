using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Projectiles;

namespace MainGame.Players.PlayerStates
{
    public class PlayerIdleUpState : IPlayerState
    {
        private readonly IPlayer player;

        public PlayerIdleUpState(IPlayer player)
        {
            this.player = player;
            this.player.Sprite = SpriteFactory.CreatePlayerIdleUpSprite();
        }

        public void Draw()
        {
            player.Sprite.Draw(player.Position.X, player.Position.Y, Color.White);
        }
        public void Update() => player.Sprite.Update();
        public void Stop() { }

        public void TakeDamage() => player.CurrentState = new PlayerDamagedUpState(player);

        public void MoveUp() => player.CurrentState = new PlayerMovingUpState(player);
        public void MoveDown() => player.CurrentState = new PlayerMovingDownState(player);
        public void MoveRight() => player.CurrentState = new PlayerMovingRightState(player);
        public void MoveLeft() => player.CurrentState = new PlayerMovingLeftState(player);
        public void UseSword() => player.CurrentState = new PlayerUsingSwordUpState(player);

        public void UseArrow()
        {
            player.UseArrow(CardinalDirections.North);
            player.CurrentState = new PlayerUsingItemUpState(player);
        }

        public void UseBoomerang()
        {
            player.UseBoomerang(CardinalDirections.North);
            player.CurrentState = new PlayerUsingItemUpState(player);
        }

        public void UseFire()
        {
            player.UseFire(CardinalDirections.North);
            player.CurrentState = new PlayerUsingItemUpState(player);
        }

        public void UseBomb()
        {
            player.UseBomb(CardinalDirections.North);
            player.CurrentState = new PlayerUsingItemUpState(player);
        }

        public void UseSwordBeam()
        {
            player.UseSwordBeam(CardinalDirections.North);
            player.CurrentState = new PlayerUsingSwordUpState(player);
        }
    }
}
