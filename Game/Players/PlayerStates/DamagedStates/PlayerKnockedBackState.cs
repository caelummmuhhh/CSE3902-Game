using Microsoft.Xna.Framework;

namespace MainGame.Players.PlayerStates
{
    public class PlayerKnockedBackState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly Vector2 origPosition;
        private readonly Direction kbDirection;
        private Vector2 prevPosition = new();

        public PlayerKnockedBackState(IPlayer player, Direction knockBackDirection)
        {
            this.player = player;
            origPosition = player.Position;
            kbDirection = knockBackDirection;
        }

        public void Stop()
        {
            player.CurrentState = player.FacingDirection switch
            {
                Direction.North => new PlayerIdleUpState(player),
                Direction.East => new PlayerIdleRightState(player),
                Direction.South => new PlayerIdleDownState(player),
                Direction.West => new PlayerIdleLeftState(player),
                _ => new PlayerIdleUpState(player)
            };
        }

        public void Update()
        {
            if (Vector2.Distance(player.Position, origPosition) >= Player.KnockedBackDistance
                || Vector2.Distance(prevPosition, player.Position) == 0)
            {
                Stop();
            }
            prevPosition = player.Position;
            player.Position = Utils.DirectionalMove(player.Position, kbDirection, Player.KnockedBackSpeed);
        }

        public void Draw() => player.Sprite.Draw(player.Position.X, player.Position.Y, player.SpriteColor);

        /* Cannot do while damaged */
        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public void UseSword() { }
        public void TakeDamage(Direction sideHit) { }
        public void UseItem() { }
    }
}

