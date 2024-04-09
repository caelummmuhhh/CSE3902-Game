using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers
{
	public class TextSprite : ISprite
    {
        public string Text;
        public float LayerDepth
        {
            get => layer;
            set
            {
                // Protect setter; SpriteBatch.Draw only allows [0, 1]f values
                if (value < 0.0f || value > 1.0f)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "Value must be between 0 and 1, inclusive.");
                }
                layer = value;
            }
        }
        public Rectangle DestinationRectangle { get; protected set; }


        private readonly SpriteBatch spriteBatch;
        private readonly SpriteFont font;
        protected float layer;

		public TextSprite(SpriteBatch spriteBatch, SpriteFont font, string text)
		{
            this.spriteBatch = spriteBatch;
            this.font = font;
            layer = 0.5f;
            Text = text;
		}

        public void Update() { /* not needed */ }

        public void Draw(float x, float y, Color color)
        {
            DestinationRectangle = new((int)x, (int)y, 0, 0);
            spriteBatch.Begin();
            spriteBatch.DrawString(font, Text, new Vector2(x, y), color);
            spriteBatch.End();
        }

    }
}

