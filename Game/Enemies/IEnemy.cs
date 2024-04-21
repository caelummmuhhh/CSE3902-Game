using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
	public interface IEnemy
	{
        public int Health { get; }
        public int Damage { get; }
        public bool IsAlive { get; }

        public Vector2 Position { get; set; }
        public Vector2 PreviousPosition { get; set; }
        public Direction MovingDirection { get; set; }
        public ISprite Sprite { get; set; }
        public IEnemyState State { get; set; }
        public Color SpriteColor { get; set; }
        public bool IsInvulnerable { get; set; }
        public bool IsStunned { get; set; }

        public Rectangle AttackHitBox { get; }
        public Rectangle MovementHitBox { get; }

        public void Update();
		public void Draw();
        public void Move();
        public void TakeDamage(Direction sideHit, int damage);
        public void Stun(int duration);
    }
}
