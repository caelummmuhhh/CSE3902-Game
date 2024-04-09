using MainGame.SpriteHandlers;
using Microsoft.Xna.Framework;

namespace MainGame.Particles
{
    public class GenericParticle : IParticle
    {
        public bool IsActive { get; set; }
        private readonly ISprite sprite;
        private Vector2 position;
        private int lifeTime;

        public GenericParticle(Vector2 spawnPosition, ISprite sprite, int lifeTime)
        {
            IsActive = true;
            this.lifeTime = lifeTime;
            position = spawnPosition;
            this.sprite = sprite;
        }

        public void Draw() => sprite.Draw(position.X, position.Y, Color.White);

        public void Update()
        {
            lifeTime--;
            IsActive = lifeTime > 0;
        }
    }
}
