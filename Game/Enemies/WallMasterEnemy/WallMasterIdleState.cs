using MainGame.Players;
using Microsoft.Xna.Framework;
using System;
namespace MainGame.Enemies
{
	public class WallMasterIdleState : IEnemyState
	{
		private readonly GenericEnemy entity;
        private readonly IPlayer Player;

        public WallMasterIdleState(GenericEnemy enemy, IPlayer player)
		{
			entity = enemy;
            Player = player;

            // Should not be visible while idling
            entity.Position = new Vector2(0, 0);
        }

		public void Update()
		{
            entity.PreviousPosition = new(entity.Position.X, entity.Position.Y);
            if (Player.Position.X == 32 * Constants.UniversalScale)
			{
				entity.State = new WallMasterMovingState(entity, Player, Direction.East);
			} 
            else if (Player.Position.X == 208 * Constants.UniversalScale)
			{
                entity.State = new WallMasterMovingState(entity, Player, Direction.West);
            }
            else if (Player.Position.Y == 32 * Constants.UniversalScale + Constants.HudAndMenuHeight)
            {
                entity.State = new WallMasterMovingState(entity, Player, Direction.South);
            }
            else if (Player.Position.Y == 128 * Constants.UniversalScale + Constants.HudAndMenuHeight)
            {
                entity.State = new WallMasterMovingState(entity, Player, Direction.North);
            }

        }

		public void Draw() => entity.Draw();

		public void Move() { /* no movement during idle... */ }
	}
}

