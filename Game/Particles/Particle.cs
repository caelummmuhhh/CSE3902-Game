using MainGame.SpriteHandlers;
using Microsoft.Xna.Framework;

namespace MainGame.Particles
{
    public class GenericParticle : IParticle
    {
        public bool IsActive { get; set; }
        public Vector2 Position { get; set; }
        private readonly ISprite sprite;
        private int lifeTime;

        public GenericParticle(Vector2 spawnPosition, ISprite sprite, int lifeTime)
        {
            IsActive = true;
            this.lifeTime = lifeTime;
            Position = spawnPosition;
            this.sprite = sprite;
        }

        public void Draw() => sprite.Draw(Position.X, Position.Y, Color.White);

        public void Update()
        {
            lifeTime--;
            IsActive = lifeTime > 0;
        }
    }
}
