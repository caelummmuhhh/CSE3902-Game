using System;
using Microsoft.Xna.Framework;
using MainGame.Players;

namespace MainGame.Projectiles
{
	public class AquamentusUpwardProjectile : AquamentusBaseProjectile
    {
        private readonly IPlayer player;
        private Vector2 startPosition;
        private Vector2 directionVector;

        public AquamentusUpwardProjectile(Vector2 startPosition, IPlayer player) : base(startPosition)
        {
            this.player = player;
            this.startPosition = startPosition;
            Position = startPosition;
        }

        public override void InitialMovement()
        {
            Position = new Vector2(Position.X, Position.Y - initalMovementSpeed);
            directionVector = CalculateDirectionVector(startPosition, player.Position);
        }

        public override void Move()
        {
            //float x = startPosition.X + directionVector.X * timePassed * mainMovementSpeed;
            //float y = startPosition.Y + (directionVector.Y - projectionOffset) * timePassed * mainMovementSpeed;

            float x = Position.X + directionVector.X * mainMovementSpeed;
            float y = Position.Y + ((directionVector.Y - projectionOffset) * mainMovementSpeed);

            Position = new Vector2(x, y);
        }
    }
}
