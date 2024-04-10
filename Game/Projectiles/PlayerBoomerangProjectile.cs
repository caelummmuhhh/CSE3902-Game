using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Players;

namespace MainGame.Projectiles
{
    public class PlayerBoomerangProjectile : IProjectile
    {
        public Vector2 Position { get => position; }
        public bool IsActive { get => isActive; }
        public Direction MovingDirection { get => direction; }
        public Rectangle HitBox
        {
            get
            {
                Rectangle destRect = sprite.DestinationRectangle;
                Rectangle resized = new((int)Position.X, (int)Position.Y, destRect.Width / GameConstants.PlayerBoomerangProjectileHitBoxDivisor, destRect.Height / GameConstants.PlayerBoomerangProjectileHitBoxDivisor);
                return Utils.CentralizeRectangle(resized.X, resized.Y, resized);
            }
        }
        private readonly IPlayer player;
        private readonly ISprite sprite;
        private readonly ISprite collideEffect;
        private bool showCollideSprite = GameConstants.PlayerBoomerangProjectileInitialShowCollideSprite;
        private int collideSpriteDuration = GameConstants.PlayerBoomerangProjectileCollideSpriteDuration;
        private Vector2 collidePosition;
        private Vector2 position;
        private Vector2 startingPosition;
        private bool isActive = GameConstants.PlayerBoomerangProjectileInitialIsActive;
        private bool returning = GameConstants.PlayerBoomerangProjectileInitialReturning;
        private readonly float acceleration = GameConstants.PlayerBoomerangProjectileAcceleration;
        private float speed;
        private int timer = GameConstants.PlayerBoomerangProjectileInitialTimer;
        private Direction direction;

        public PlayerBoomerangProjectile(IPlayer player, Direction direction)
        {
            this.player = player;
            startingPosition = player.Position;
            position = startingPosition;
            sprite = SpriteFactory.CreateWoodenBoomerangSprite();
            collideEffect = SpriteFactory.CreateArrowProjectileHitSprite();

            this.direction = direction;
            speed = GameConstants.PlayerBoomerangProjectileInitialSpeed;
        }

        public void Update()
        {
            sprite.Update();
            Move();

            if (showCollideSprite)
            {
                collideSpriteDuration--;
                showCollideSprite = collideSpriteDuration > 0;
            }

            if (returning && Vector2.Distance(position, player.Position) < GameConstants.PlayerBoomerangProjectileReturnDistance)
            {
                isActive = false;
            }

            timer++;
        }

        public void Draw()
        {
            sprite.Draw(Position.X, Position.Y, Color.White);
            if (showCollideSprite)
            {
                collideEffect.Draw(collidePosition.X, collidePosition.Y, Color.White);
            }
        }

        public void Collide()
        {
            if (!returning)
            {
                showCollideSprite = true;
                returning = true;
                collidePosition = position;
            }
        }

        private void Move()
        {
            if (!returning)
            {
                speed -= acceleration * timer;
                position = Utils.DirectionalMove(position, direction, speed);
                if (speed < 0)
                {
                    returning = true;
                }
            }
            else
            {
                Vector2 directionalVector = Utils.CalculateDirectionVector(position, player.Position);
                direction = Utils.CalculateMoveDirection(position.X - player.Position.X, position.Y - player.Position.Y);
                speed += acceleration * timer;
                position.X += directionalVector.X * speed;
                position.Y += directionalVector.Y * speed;
            }
        }
    }
}