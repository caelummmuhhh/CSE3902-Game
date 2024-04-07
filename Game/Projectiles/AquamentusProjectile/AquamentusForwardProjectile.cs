using System;
using Microsoft.Xna.Framework;
using MainGame.Players;

namespace MainGame.Projectiles
{
    public class AquamentusForwardProjectile : AquamentusBaseProjectile
    {
        public override Direction MovingDirection { get => movingDirection; }
        private readonly IPlayer player;
        private Vector2 startPosition;
        private Vector2 directionVector;
        private bool initialMoving = true;
        private Direction movingDirection;

        public AquamentusForwardProjectile(Vector2 startPosition, IPlayer player) : base(startPosition)
        {
            this.player = player;
            this.startPosition = startPosition;
            Position = startPosition;
            movingDirection = Direction.East;
        }

        public override void InitialMovement() { }

        public override void Move()
        {
            if (initialMoving)
            {
                // we only want to calculate this once atan2 expensive to calculate every update for multiple projectiles
                initialMoving = false;
                movingDirection = Utils.CalculateMoveDirection(directionVector.X, directionVector.Y + projectionOffset);
                directionVector = Utils.CalculateDirectionVector(startPosition, player.Position);
            }

            float x = Position.X + directionVector.X * mainMovementSpeed;
            float y = Position.Y + directionVector.Y * mainMovementSpeed;

            Position = new Vector2(x, y);
        }
    }
}
