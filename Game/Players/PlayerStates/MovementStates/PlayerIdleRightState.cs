using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Players.PlayerStates
{
    public class PlayerIdleRightState : IPlayerState
    {
        private readonly Player player;

        public PlayerIdleRightState(Player player)
        {
            this.player = player;
            this.player.CurrentSprite = SpriteFactory.CreatePlayerIdleRightSprite();
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
        public void UseSword() => player.CurrentState = new PlayerUsingSwordRightState(player);

        public void UseArrow() => player.CurrentState = new PlayerUsingItemRightState(player);
        public void UseBoomerang() => player.CurrentState = new PlayerUsingItemRightState(player);
        public void UseFire() => player.CurrentState = new PlayerUsingItemRightState(player);
        public void UseBomb() => player.CurrentState = new PlayerUsingItemRightState(player);
        public void UseSwordBeam() => player.CurrentState = new PlayerUsingSwordRightState(player);

    }
}
