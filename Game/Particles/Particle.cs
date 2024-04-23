using MainGame.SpriteHandlers;
using Microsoft.Xna.Framework;

namespace MainGame.Particles
{
    public class GenericParticle : IParticle
    {
        public bool IsActive { get; private set; } = true;
        private readonly ISprite sprite;
        private Vector2 position;
        private int lifeTime = 12;

        public GenericParticle(Vector2 spawnPosition, ISprite sprite, int lifeSpan = -1)
        {
            IsActive = true;
            position = spawnPosition;
            this.sprite = sprite;
            lifeTime = lifeSpan;
            if (lifeTime <= 0 && sprite is AnimatedSprite animatedSprite)
            {
                lifeTime = animatedSprite.AnimationFrameDuration;
            }
        }

        public void Draw() => sprite.Draw(position.X, position.Y, Color.White);

        public void Update()
        {
            sprite.Update();
            if (lifeTime <= 0)
            {
                IsActive = false;
            }
            lifeTime--;
        }
    }
}
