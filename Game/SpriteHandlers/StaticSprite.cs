using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers
{
    public abstract class StaticSprite : ISprite
    {
        public readonly Texture2D Texture;
        public readonly int Scale;

        public StaticSprite(Texture2D texture, int scale = 1)
        {
            Texture = texture;
            Scale = scale;
        }

        public abstract void Draw(float x, float y, Color color, float xMax, float yMax);

        public virtual void Update() { /* generally not needed */ }

        protected virtual Rectangle GetSourceRectangle()
        {
            return new Rectangle(0, 0, Texture.Width, Texture.Height);
        }
    }
}
