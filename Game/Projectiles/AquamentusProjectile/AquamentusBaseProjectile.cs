using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Projectiles
{
	public abstract class AquamentusBaseProjectile : IProjectile
	{
        public Vector2 Position { get => position; set => position = value; }
        public bool IsActive { get => isActive; }
		public abstract Direction MovingDirection { get; }
        public Rectangle HitBox
        {
            get
            {
				if (!isActive)
				{
					return new();
				}
                Rectangle destRect = sprite.DestinationRectangle;
                Rectangle resized = new(destRect.X, destRect.Y, destRect.Width / 2, destRect.Height / 2);
                return Utils.CentralizeRectangle((int)Position.X, (int)Position.Y, resized);
            }
        }

        private bool isActive = true;
		private Vector2 position;
		protected readonly ISprite sprite;
		protected int horizontalSpeed = Constants.UniversalScale;
		protected int initialMovementDuration = 20;
		protected int movementDuration = 500; // TODO: or until it hits something

		protected float initalMovementSpeed = 1f;
		protected float mainMovementSpeed = Constants.UniversalScale * 2;
		protected float projectionOffset = (float)Math.Sin(15d * Math.PI / 180d);

        public AquamentusBaseProjectile(Vector2 spawnPosition)
		{
			position = spawnPosition;
			sprite = SpriteFactory.CreateAquamentusAttackSprite();
        }

		public virtual void Update()
		{
			sprite.Update();
			if (movementDuration <= 0)
			{
				isActive = false;
				return;
			}
			if (initialMovementDuration <= 0)
			{
				Move();
				movementDuration--;
				return;
			}
			InitialMovement();
			initialMovementDuration--;
		}

		public virtual void Draw()
		{
			sprite.Draw(position.X, position.Y, Color.White);
		}

		public virtual void Collide() => isActive = false;
		public abstract void Move();
		public abstract void InitialMovement();
    }
}
