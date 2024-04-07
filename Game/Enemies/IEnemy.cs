using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
	public interface IEnemy
	{
        public Vector2 Position { get; set; }
        public Vector2 PreviousPosition { get; set; }
        public Direction MovingDirection { get; set; }
        public ISprite Sprite { get; set; }
        public IEnemyState State { get; set; }

        public Rectangle AttackHitBox { get; }
        public Rectangle MovementHitBox { get; }

        public void Update();
		public void Draw();
        public void Move();
        public void TakeDamage();
    }
}
