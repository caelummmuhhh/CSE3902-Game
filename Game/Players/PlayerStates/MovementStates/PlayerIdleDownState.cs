using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Projectiles;

namespace MainGame.Players.PlayerStates
{
    public class PlayerIdleDownState : IPlayerState
    {
        private readonly IPlayer player;

        public PlayerIdleDownState(IPlayer player)
        {
            this.player = player;
            this.player.Sprite = SpriteFactory.CreatePlayerIdleDownSprite();
        }

        public void Draw()
        {
            player.Sprite.Draw(player.Position.X, player.Position.Y, Color.White);
        }
        public void Update() => player.Sprite.Update();
        public void Stop() { }

        public void TakeDamage() => player.CurrentState = new PlayerDamagedDownState(player);

        public void MoveUp() => player.CurrentState = new PlayerMovingUpState(player);
        public void MoveDown() => player.CurrentState = new PlayerMovingDownState(player);
        public void MoveRight() => player.CurrentState = new PlayerMovingRightState(player);
        public void MoveLeft() => player.CurrentState = new PlayerMovingLeftState(player);
        public void UseSword() => player.CurrentState = new PlayerUsingSwordDownState(player);

        public void UseArrow()
        {
            player.UseArrow(CardinalDirections.South);
            player.CurrentState = new PlayerUsingItemDownState(player);
        }

        public void UseBoomerang()
        {
            player.UseBoomerang(CardinalDirections.South);
            player.CurrentState = new PlayerUsingItemDownState(player);
        }

        public void UseFire()
        {
            player.UseFire(CardinalDirections.South);
            player.CurrentState = new PlayerUsingItemDownState(player);
        }

        public void UseBomb()
        {
            player.UseBomb(CardinalDirections.South);
            player.CurrentState = new PlayerUsingItemDownState(player);
        }

        public void UseSwordBeam()
        {
            player.UseSwordBeam(CardinalDirections.South);
            player.CurrentState = new PlayerUsingSwordDownState(player);
        }
    }
}
