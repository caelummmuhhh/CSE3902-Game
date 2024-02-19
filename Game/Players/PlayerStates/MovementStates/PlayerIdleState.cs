using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Players.PlayerStates
{
	public enum Directions { Up, Down, Left, Right }

	public class PlayerIdleState : IPlayerState
    {
        private readonly Player player;
		public PlayerIdleState(Player player, Directions direction)
		{
            this.player = player;

            switch (direction)
            {
                case Directions.Up:
                    this.player.CurrentSprite = SpriteFactory.CreatePlayerIdleUpSprite();
                    break;
                case Directions.Down:
                    this.player.CurrentSprite = SpriteFactory.CreatePlayerIdleDownSprite();
                    break;
                case Directions.Right:
                    this.player.CurrentSprite = SpriteFactory.CreatePlayerIdleRightSprite();
                    break;
                case Directions.Left:
                    this.player.CurrentSprite = SpriteFactory.CreatePlayerIdleLeftSprite();
                    break;
            }
		}

        public void Draw()
        {
            player.CurrentSprite.Draw(player.Position.X, player.Position.Y, Color.White);
        }

        public void Update() { player.CurrentSprite.Update(); }
        public void Stop() { }

        public void MoveUp() { player.CurrentState = new PlayerMovingUpState(player); }
        public void MoveDown() { player.CurrentState = new PlayerMovingDownState(player); }
        public void MoveRight() { player.CurrentState = new PlayerMovingRightState(player); }
        public void MoveLeft() { player.CurrentState = new PlayerMovingLeftState(player); }

        public void UseSword() { }

        public void UseArrow() { }
        public void UseBoomerang() { }
        public void UseFire() { }
        public void UseBomb() { }
        public void UseSwordBeam() { }
    }
}

