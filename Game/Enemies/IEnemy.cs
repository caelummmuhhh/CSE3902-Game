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

    public enum CardinalAndOrdinalDirection
    {
        North,
        NorthEast,
        East,
        SouthEast,
        South,
        SouthWest,
        West,
        NorthWest
    }

    public enum CardinalDirections
    {
        North,
        East,
        South,
        West
    }
}
