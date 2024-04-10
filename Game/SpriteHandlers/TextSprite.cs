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
                if (value < GameConstants.MinLayerDepth || value > GameConstants.MaxLayerDepth)
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
            layer = GameConstants.TextSpriteInitialLayerDepth;
            Text = text;
		}

        public void Update() { /* not needed */ }

        public void Draw(float x, float y, Color color)
        {
            DestinationRectangle = new((int)x, (int)y, GameConstants.TextSpriteInitialXPosition, GameConstants.TextSpriteInitialYPosition);
            spriteBatch.Begin();
            spriteBatch.DrawString(font, Text, new Vector2(x, y), color);
            spriteBatch.End();
        }

    }
}
