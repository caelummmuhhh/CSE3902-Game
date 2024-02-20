using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Players.PlayerStates
{
	public class PlayerUsingItemUpState : IPlayerState
	{
        private readonly IPlayer player;
        private readonly int stateDuration;
        private int currentFrame = 0;

        public PlayerUsingItemUpState(IPlayer player)
		{
            this.player = player;
            this.player.Sprite = SpriteFactory.CreatePlayerInteractingUpSprite();
            stateDuration = Player.UsingItemsSpeed;
        }

        public void Update()
        {
            if (currentFrame == stateDuration)
            {
                Stop();
            }
            player.Sprite.Update();
        }

        public void Draw()
        {
            currentFrame++;
            player.Sprite.Draw(player.Position.X, player.Position.Y, Color.White, 0, 0);
        }

        public void TakeDamage() => player.CurrentState = new PlayerDamagedUpState(player);
        public void Stop() => player.CurrentState = new PlayerIdleUpState(player);

        /* Not useable in this state, therefore not implemented. */
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
