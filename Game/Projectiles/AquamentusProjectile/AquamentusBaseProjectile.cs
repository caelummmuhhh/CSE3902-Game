using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Projectiles
{
	public abstract class AquamentusBaseProjectile : IProjectile
	{
        public Vector2 Position { get => position; set => position = value; }
        public bool IsActive { get => isActive; }

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

		public abstract void Move();
		public abstract void InitialMovement();

		public static Vector2 CalculateDirectionVector(Vector2 start, Vector2 end)
        {
            double dx = end.X - start.X;
            double dy = end.Y - start.Y;

            double distance = Math.Sqrt(dx * dx + dy * dy);

            dx /= distance;
            dy /= distance;

            return new Vector2((float)dx, (float)dy);
        }
    }
}

