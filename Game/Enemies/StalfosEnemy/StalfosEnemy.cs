using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
	public class StalfosEnemy : GenericEnemy
	{
		public override int MovementCoolDownFrame { get; protected set; } = 2;

		private int moveDuration;
		private readonly int maxMoveDuration = 32;

		public StalfosEnemy(Vector2 startingPosition)
		{
			Position = startingPosition;
            PreviousPosition = new(Position.X, Position.Y);
            Sprite = SpriteFactory.CreateStalfosSprite();
		}

		public override void Update()
		{
			if (moveDuration <= 0)
			{
                MovingDirection = Utils.GetRandomCardinalDirection();
                moveDuration = maxMoveDuration;
            }

			State?.Update();
            moveDuration--;
			base.Update();
        }

        public override void Draw() => Sprite.Draw(Position.X, Position.Y, SpriteColor);

        public override void Move()
        {
            PreviousPosition = new(Position.X, Position.Y);
            if (moveDuration % MovementCoolDownFrame == 0)
			{
				Position = Utils.DirectionalMove(Position, MovingDirection, MovementSpeed);
			}
        }
    }
}

