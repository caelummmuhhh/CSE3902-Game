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
        public virtual Rectangle AttackHitBox
        {
            get => new(Position.ToPoint(), Sprite.DestinationRectangle.Size);
        }

        public virtual Rectangle MovementHitBox
        {
            get => new(Position.ToPoint(), Sprite.DestinationRectangle.Size);
            /*{
                // Shrink the sprite size by one pixel around

                Rectangle hitbox = new(Sprite.DestinationRectangle.Location, Sprite.DestinationRectangle.Size);
                hitbox.Width -= Constants.UniversalScale * 2;
                hitbox.Height -= Constants.UniversalScale * 2;
                hitbox.X += Constants.UniversalScale;
                hitbox.Y += Constants.UniversalScale;

                return hitbox;
            }*/
        }

        public virtual Vector2 PreviousPosition { get; set; }
        public virtual Direction MovingDirection { get; set; }

        public virtual int MovementSpeed { get; protected set; } = Constants.UniversalScale;
        public virtual ISprite Sprite { get; set; }
        public virtual Vector2 Position { get; set; }
        public virtual IEnemyState State { get; set; }

        public GenericEnemy() { }

        public virtual void Update()
        {
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

