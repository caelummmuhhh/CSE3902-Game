using System;
using Microsoft.Xna.Framework;
using MainGame.Players;

namespace MainGame.Projectiles
{
    public class AquamentusForwardProjectile : AquamentusBaseProjectile
    {
        private readonly IPlayer player;
        private Vector2 startPosition;
        private Vector2 directionVector;

        public AquamentusForwardProjectile(Vector2 startPosition, IPlayer player) : base(startPosition)
        {
            this.player = player;
            this.startPosition = startPosition;
            Position = startPosition;
        }

        public override void InitialMovement()
        {
            directionVector = CalculateDirectionVector(startPosition, player.Position);
        }

        public override void Move()
        {
            //float x = mainMovementStartingPosition.X + directionVector.X * timePassed * mainMovementSpeed;
            //float y = mainMovementStartingPosition.Y + directionVector.Y * timePassed * mainMovementSpeed;

            float x = Position.X + directionVector.X * mainMovementSpeed;
            float y = Position.Y + directionVector.Y * mainMovementSpeed;

            Position = new Vector2(x, y);
        }
    }
}
