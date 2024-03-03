using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Projectiles;

namespace MainGame.Enemies
{
	public abstract class GenericEnemy : IEnemy
	{
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

        /// <summary>
        /// Move enemy based on a movement pattern
        /// </summary>
        public virtual void Move() { }

        public virtual void TakeDamage()
        {
            
        }
    }
}

