using MainGame.SpriteHandlers;

namespace MainGame.Players.PlayerStates
{
    public class PlayerIdleUpState : IPlayerState
    {
        private readonly IPlayer player;

        public PlayerIdleUpState(IPlayer player)
        {
            this.player = player;
            this.player.FacingDirection = Direction.North;
            this.player.Sprite = SpriteFactory.CreatePlayerIdleUpSprite();
        }

        public void Draw()
        {
            player.Sprite.Draw(player.Position.X, player.Position.Y, player.SpriteColor);
        }
        public void Update() => player.Sprite.Update();
        public void Stop() { }

        public void TakeDamage(Direction sideHit)
            => player.CurrentState = new PlayerKnockedBackState(player, Utils.OppositeDirection(sideHit));

        public void MoveUp() => player.CurrentState = new PlayerMovingUpState(player);
        public void MoveDown() => player.CurrentState = new PlayerMovingDownState(player);
        public void MoveRight() => player.CurrentState = new PlayerMovingRightState(player);
        public void MoveLeft() => player.CurrentState = new PlayerMovingLeftState(player);
        public void UseSword() => player.CurrentState = new PlayerUsingSwordUpState(player);

        public void UseArrow()
        {
            player.UseArrow(Direction.North);
            player.CurrentState = new PlayerUsingItemUpState(player);
        }

        public void UseBoomerang()
        {
            player.UseBoomerang(Direction.North);
            player.CurrentState = new PlayerUsingItemUpState(player);
        }

        public void UseFire()
        {
            player.UseFire(Direction.North);
            player.CurrentState = new PlayerUsingItemUpState(player);
        }

        public void UseBomb()
        {
            player.UseBomb(Direction.North);
            player.CurrentState = new PlayerUsingItemUpState(player);
        }

        public void UseSwordBeam()
        {
            player.UseSwordBeam(Direction.North);
            player.CurrentState = new PlayerUsingSwordUpState(player);
        }
    }
}
