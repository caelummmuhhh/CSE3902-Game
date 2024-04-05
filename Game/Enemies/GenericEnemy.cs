using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
	public abstract class GenericEnemy : IEnemy
	{
        /// <summary>
        /// If moving, the entity can only move once every MovementCoolDownFrame.
        /// </summary>
        public abstract int MovementCoolDownFrame {  get; protected set; }
        public virtual Rectangle HitBox
        {
            get
            {
                // Shrink the sprite size by one pixel
                Rectangle hitbox = new(Sprite.DestinationRectangle.Location, Sprite.DestinationRectangle.Size);
                hitbox.Width -= Constants.UniversalScale;
                hitbox.Height -= Constants.UniversalScale;

                return hitbox;
            }
        }
        public virtual Vector2 PreviousPosition { get; set; } 

        public virtual int MovementSpeed { get; protected set; } = Constants.UniversalScale;
        public virtual ISprite Sprite { get; set; }
        public virtual Vector2 Position { get; set; }
        public virtual IEnemyState State { get; set; }

        public GenericEnemy() { }

        public virtual void Update()
        {
            PreviousPosition = Position;
            Move();
            Sprite.Update();
        }

        public virtual void Draw()
        {
            Sprite.Draw(Position.X, Position.Y, Color.White);
        }

        public abstract void Move();

        public virtual void TakeDamage() { }
    }
}

