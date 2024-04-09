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
                Rectangle resized = new((int)Position.X, (int)Position.Y, destRect.Width / 2, destRect.Height / 2);
                return Utils.CentralizeRectangle(resized.X, resized.Y, resized);
            }
        }
        private readonly IPlayer player;
        private readonly ISprite sprite;
        private readonly ISprite collideEffect;
        private bool showCollideSprite = false;
        private int collideSpriteDuration = 10;
        private Vector2 collidePosition;
        private Vector2 position;
        private Vector2 startingPosition;
        private bool isActive = true;
        private bool returning = false;
        private readonly float acceleration = 0.02f;
        private float speed;
        private int timer = 0;
        private Direction direction;

        public PlayerBoomerangProjectile(IPlayer player, Direction direction)
        {
            this.player = player;
            startingPosition = player.Position;
            position = startingPosition;
            sprite = SpriteFactory.CreateWoodenBoomerangSprite();
            collideEffect = SpriteFactory.CreateArrowProjectileHitSprite();

            this.direction = direction;
            speed = 10;
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

            if (returning && Vector2.Distance(position, player.Position) < 10f)
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