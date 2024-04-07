using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Projectiles;

namespace MainGame.Players.PlayerStates
{
    public class PlayerDamagedUpState : IPlayerState
    {
        private readonly IPlayer player;
        private int damageTimeRemaining = Player.KnockedBackDuration;

        public PlayerDamagedUpState(IPlayer player)
        {
            this.player = player;
            this.player.FacingDirection = Direction.North;
        }

        public void Stop() => player.CurrentState = new PlayerIdleUpState(player);
        public void Update()
        {
            if (damageTimeRemaining <= 0)
            {
                Stop();
            }
            player.Position = new(player.Position.X, player.Position.Y + Player.KnockedBackSpeed);
            damageTimeRemaining--;
        }

        public void Draw() { }

        /* Cannot do while damaged */
        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public void UseSword() { }
        public void TakeDamage() { }
        public void UseArrow() { }
        public void UseBoomerang() { }
        public void UseFire() { }
        public void UseBomb() { }
        public void UseSwordBeam() { }
    }
}

