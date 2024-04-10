using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Blocks
{
    public class PushableBlock : IBlock
    {
        public Vector2 Position { get; set; }
        public Rectangle HitBox { get => sprite.DestinationRectangle; }

        private readonly ISprite sprite;
        private readonly Vector2 originalPosition;
        private readonly int maxMoveDistance = Constants.BlockSize;

        private bool canPush = GameConstants.InitialCanPush;
        private Direction pushDirection;
        private int pushedDuration;

        private int notCollidingTimer;
        private bool isBeingPushed = GameConstants.InitialIsBeingPushed;

        public PushableBlock(Vector2 position, ISprite sprite)
        {
            Position = position;
            originalPosition = position;
            this.sprite = sprite;
            pushedDuration = GameConstants.MaxPushDuration;
            notCollidingTimer = GameConstants.MaxNotCollisionTimer;
        }

        public void Update()
        {
            // If the block is not pushed within the collideChecker
            if (isBeingPushed)
            {
                notCollidingTimer--;
            }
            if (notCollidingTimer <= 0 && pushedDuration > 0)
            {
                notCollidingTimer = GameConstants.MaxNotCollisionTimer;

                isBeingPushed = GameConstants.InitialIsBeingPushed;
                pushedDuration = GameConstants.MaxPushDuration;
            }


            sprite.Update();
            if (pushedDuration <= 0 && Vector2.Distance(originalPosition, Position) < maxMoveDistance)
            {
                Move();
            }
        }

        public void Draw()
        {
            sprite.Draw(Position.X, Position.Y, Color.White);
        }

        public void Collide(Direction pushDirection, Vector2 pusherPosition)
        {
            if (canPush &&
                   ((pushDirection == Direction.North || pushDirection == Direction.South) && pusherPosition.X == originalPosition.X
                || (pushDirection == Direction.East || pushDirection == Direction.West) && pusherPosition.Y == originalPosition.Y))
            {
                this.pushDirection = pushDirection;
                isBeingPushed = true;
                notCollidingTimer = GameConstants.MaxNotCollisionTimer;
                pushedDuration--;
            }
        }

        public void MakePushable() => canPush = true;

        public void Move() => Position = Utils.DirectionalMove(Position, pushDirection, GameConstants.PushableBlockSpeed);
    }
}
