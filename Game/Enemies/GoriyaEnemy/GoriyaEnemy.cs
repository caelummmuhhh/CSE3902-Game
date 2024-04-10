using Microsoft.Xna.Framework;

namespace MainGame.Enemies
{
	public class GoriyaEnemy : GenericEnemy
	{
		public Direction FacingDirection { get; set; }
		public override int MovementCoolDownFrame { get; protected set; } = GameConstants.GoriyaMovementCoolDownFrame;

        public GoriyaEnemy(Vector2 startingPosition)
		{
			Position = startingPosition;
            PreviousPosition = new(Position.X, Position.Y);
            State = new GoriyaMovingState(this);
		}

        public override void Update()
        {
			State.Update();
            base.Update();
        }

        public override void Draw()
        {
			State.Draw();
            base.Draw();
        }

        public override void Move()
		{
			State.Move();
		}
	}
}
