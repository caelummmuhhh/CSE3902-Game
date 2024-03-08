using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
	public interface IEnemy
	{
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public IEnemyState State { get; set; }

        public void Update();
		public void Draw();
        public void Move();
        public void TakeDamage();
    }
}
