using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Projectiles;

namespace MainGame.Players.PlayerStates
{
    public class PlayerIdleDownState : IPlayerState
    {
        private readonly Player player;

        public PlayerIdleDownState(Player player)
        {
            this.player = player;
            this.player.CurrentSprite = SpriteFactory.CreatePlayerIdleDownSprite();
        }

        public void Draw()
        {
            player.CurrentSprite.Draw(player.Position.X, player.Position.Y, Color.White);
        }
        public void Update() => player.CurrentSprite.Update();
        public void Stop() { }

        public void MoveUp() => player.CurrentState = new PlayerMovingUpState(player);
        public void MoveDown() => player.CurrentState = new PlayerMovingDownState(player);
        public void MoveRight() => player.CurrentState = new PlayerMovingRightState(player);
        public void MoveLeft() => player.CurrentState = new PlayerMovingLeftState(player);
        public void UseSword() => player.CurrentState = new PlayerUsingSwordDownState(player);

        public void UseArrow() => player.CurrentState = new PlayerUsingItemDownState(player);
        public void UseBoomerang()
        {
            player.UseBoomerang(Direction.Down);
            player.CurrentState = new PlayerUsingItemDownState(player);
        }
        public void UseFire() => player.CurrentState = new PlayerUsingItemDownState(player);
        public void UseBomb() => player.CurrentState = new PlayerUsingItemDownState(player);
        public void UseSwordBeam() => player.CurrentState = new PlayerUsingSwordDownState(player);
    }
}
