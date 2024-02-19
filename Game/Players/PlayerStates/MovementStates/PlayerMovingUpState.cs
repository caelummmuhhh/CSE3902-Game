using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Players.PlayerStates
{
	public class PlayerMovingUpState : IPlayerState
	{
		private readonly Player player;

		public PlayerMovingUpState(Player player)
		{
			this.player = player;
            player.CurrentSprite = SpriteFactory.CreatePlayerWalkingUpSprite();
		}

        public void Update() { player.CurrentSprite.Update(); }
        public void Draw()
        {
            player.CurrentSprite.Draw(player.Position.X, player.Position.Y, Color.White);
        }
        public void Stop() { player.CurrentState = new PlayerIdleState(player, Directions.Up); }

        public void MoveUp()
        {
            player.IsMoving = true;
            player.Position = new(player.Position.X, player.Position.Y - Player.Speed);
        }

        public void MoveDown() { player.CurrentState = new PlayerMovingDownState(player);  }
        public void MoveLeft() { player.CurrentState = new PlayerMovingLeftState(player);  }
        public void MoveRight() { player.CurrentState = new PlayerMovingRightState(player);  }

        public void UseSword() { }

        public void UseArrow() { }
        public void UseBoomerang() { }
        public void UseFire() { }
        public void UseBomb() { }
        public void UseSwordBeam() { }

    }
}

