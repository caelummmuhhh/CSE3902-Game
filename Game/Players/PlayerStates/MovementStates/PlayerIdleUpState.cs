using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Projectiles;

namespace MainGame.Players.PlayerStates
{
    public class PlayerIdleUpState : IPlayerState
    {
        private readonly Player player;

        public PlayerIdleUpState(Player player)
        {
            this.player = player;
            this.player.CurrentSprite = SpriteFactory.CreatePlayerIdleUpSprite();
        }

        public void Draw()
        {
            player.CurrentSprite.Draw(player.Position.X, player.Position.Y, Color.White);
        }
        public void Update() => player.CurrentSprite.Update();
        public void Stop() { }

        public void MoveUp() => player.CurrentState = new PlayerMovingUpState(player);
        public void MoveDown() => player.CurrentState = new PlayerUsingItemRightState(player);
        public void MoveRight() => player.CurrentState = new PlayerMovingRightState(player);
        public void MoveLeft() => player.CurrentState = new PlayerMovingLeftState(player);
        public void UseSword() => player.CurrentState = new PlayerUsingSwordUpState(player);

        public void UseArrow()
        {
            player.UseArrow(Direction.Up);
            player.CurrentState = new PlayerUsingItemUpState(player);
        }

        public void UseBoomerang()
        {
            player.UseBoomerang(Direction.Up);
            player.CurrentState = new PlayerUsingItemUpState(player);
        }

        public void UseFire()
        {
            player.UseFire(Direction.Up);
            player.CurrentState = new PlayerUsingItemUpState(player);
        }

        public void UseBomb()
        {
            player.UseBomb(Direction.Up);
            player.CurrentState = new PlayerUsingItemUpState(player);
        }

        public void UseSwordBeam()
        {
            player.UseSwordBeam(Direction.Up);
            player.CurrentState = new PlayerUsingSwordUpState(player);
        }
    }
}
