using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers
{
    public abstract class StaticSprite : ISprite
    {
        public readonly Texture2D Texture;
        public int Scale { get => scale; }
        public abstract Rectangle DestinationRectangle { get; protected set; }
        public float LayerDepth
        {
            get => layer;
            set
            {
                // Protect setter; SpriteBatch.Draw only allows [0, 1]f values
                if (value < GameConstants.MinLayerDepth || value > GameConstants.MaxLayerDepth)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "Value must be between 0 and 1, inclusive.");
                }
                layer = value;
            }
        }

        protected int scale;
        protected float layer;

        public StaticSprite(Texture2D texture, int scale = 1)
        {
            Texture = texture;
            this.scale = scale;
        }

        public abstract void Draw(float x, float y, Color color);

        public virtual void Update() { /* generally not needed */ }

        protected virtual Rectangle GetSourceRectangle()
        {
            return new Rectangle(0, 0, Texture.Width, Texture.Height);
        }
    }
}
