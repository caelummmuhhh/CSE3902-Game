using MainGame.Players;
using Microsoft.Xna.Framework;
using System;

namespace MainGame.Enemies
{
	public class WallMasterMovingState : IEnemyState
	{
        private readonly GenericEnemy entity;
		private int stateDuration = 31;
        private enum WallMasterStates
        {
            Emerging, Travelling, Retreating
        }
        private WallMasterStates movementState = WallMasterStates.Emerging;

        private readonly IPlayer Player;
		private readonly Direction playerDirection;
        private Direction turnDirection;

        public WallMasterMovingState(GenericEnemy enemy, IPlayer player, Direction direction)
		{
            entity = enemy;
            stateDuration = 31 * enemy.MovementCoolDownFrame;

        Player = player;
			playerDirection = player.FacingDirection;
            entity.MovingDirection = direction;

            SetPosition();
        }
        public void Update()
		{
			if (stateDuration <= 0)
			{
                if (movementState == WallMasterStates.Emerging)
                {
                    Direction tempDir = entity.MovingDirection;
                    entity.MovingDirection = turnDirection;
                    turnDirection = Utils.OppositeDirection(tempDir);

                    movementState = WallMasterStates.Travelling;
                    stateDuration = 47 * entity.MovementCoolDownFrame; ;
                } else if (movementState == WallMasterStates.Travelling)
                {
                    entity.MovingDirection = turnDirection;

                    movementState = WallMasterStates.Retreating;
                    stateDuration = 31 * entity.MovementCoolDownFrame; ;
                } else if (movementState == WallMasterStates.Retreating)
                {
                    entity.State = new WallMasterIdleState(entity, Player);
                }
            } 
			stateDuration--;
		}

		public void Draw() => entity.Draw();

		public void Move()
		{
			if (stateDuration % entity.MovementCoolDownFrame == 0)
			{
				entity.Position = Utils.DirectionalMove(
					entity.Position, entity.MovingDirection, entity.MovementSpeed
				);
            }
        }
        private void SetPosition()
        {
            if (entity.MovingDirection == Direction.West)
            {
                if (playerDirection == Direction.North)
                {
                    entity.Position = new Vector2(Player.Position.X + (32 * Constants.UniversalScale), Player.Position.Y - (48 * Constants.UniversalScale));
                    turnDirection = Direction.South;
                }
                else
                {
                    entity.Position = new Vector2(Player.Position.X + (32 * Constants.UniversalScale), Player.Position.Y + (48 * Constants.UniversalScale));
                    turnDirection = Direction.North;
                }
            }
            else if (entity.MovingDirection == Direction.East)
            {
                if (playerDirection == Direction.North)
                {
                    entity.Position = new Vector2(Player.Position.X - (32 * Constants.UniversalScale), Player.Position.Y - (48 * Constants.UniversalScale));
                    turnDirection = Direction.South;
                }
                else
                {
                    entity.Position = new Vector2(Player.Position.X - (32 * Constants.UniversalScale), Player.Position.Y + (48 * Constants.UniversalScale));
                    turnDirection = Direction.North;
                }
            }
            else if (entity.MovingDirection == Direction.South)
            {
                if (playerDirection == Direction.West)
                {
                    entity.Position = new Vector2(Player.Position.X - (48 * Constants.UniversalScale), Player.Position.Y - (32 * Constants.UniversalScale));
                    turnDirection = Direction.East;
                }
                else
                {
                    entity.Position = new Vector2(Player.Position.X + (48 * Constants.UniversalScale), Player.Position.Y - (32 * Constants.UniversalScale));
                    turnDirection = Direction.West;
                }
            }
            else if (entity.MovingDirection == Direction.North)
            {
                if (playerDirection == Direction.West)
                {
                    entity.Position = new Vector2(Player.Position.X - (48 * Constants.UniversalScale), Player.Position.Y + (32 * Constants.UniversalScale));
                    turnDirection = Direction.East;
                }
                else
                {
                    entity.Position = new Vector2(Player.Position.X + (48 * Constants.UniversalScale), Player.Position.Y + (32 * Constants.UniversalScale));
                    turnDirection = Direction.West;
                }
            }
        }
    }
}
