using Microsoft.Xna.Framework;

namespace MainGame.Enemies
{
	public class GoriyaEnemy : GenericEnemy
	{
		public CardinalDirections FacingDirection { get; set; }
		public override int MovementCoolDownFrame { get; protected set; } = 2;

        public GoriyaEnemy(Vector2 startingPosition)
		{
			Position = startingPosition;
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

