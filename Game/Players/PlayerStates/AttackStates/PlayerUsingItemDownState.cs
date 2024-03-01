using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Projectiles;

namespace MainGame.Players.PlayerStates
{
	public class PlayerUsingItemDownState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly int stateDuration;
        private int currentFrame = 0;

        public PlayerUsingItemDownState(IPlayer player)
        {
            this.player = player;
            this.player.Sprite = SpriteFactory.CreatePlayerInteractingDownSprite();
            stateDuration = Player.UsingItemsSpeed;
        }

        public void Update()
        {
            if (currentFrame == stateDuration)
            {
                player.CurrentState = new PlayerIdleDownState(player);
            }
            player.Sprite.Update();
        }

        public void Draw()
        {
            currentFrame++;
            player.Sprite.Draw(player.Position.X, player.Position.Y, Color.White);
        }

        public void TakeDamage() => player.CurrentState = new PlayerDamagedDownState(player);

        /* Not useable in this state, therefore not implemented. */
        public void Stop() { }
        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public void UseSword() { }
        public void UseBoomerang() { }
        public void UseFire() { }
        public void UseArrow() { }
        public void UseBomb() { }
        public void UseSwordBeam() { }
    }
}
