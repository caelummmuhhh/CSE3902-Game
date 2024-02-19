using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

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

        public void UseArrow() { }
        public void UseBoomerang() { }
        public void UseFire() { }
        public void UseBomb() { }
        public void UseSwordBeam() { }

    }
}
