using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static System.Net.Mime.MediaTypeNames;

namespace MainGame.SpriteHandlers
{
	public class TextSprite : ISprite
    {
        public string Text;

        private readonly SpriteBatch spriteBatch;
        private SpriteFont font;

		public TextSprite(SpriteBatch spriteBatch, SpriteFont font, string text)
		{
            this.spriteBatch = spriteBatch;
            this.font = font;
            Text = text;
		}

        public void Update()
        {
            // not needed
        }

        public void Draw(float x, float y, Color color, float xMax, float yMax)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, Text, new Vector2(x, y), color);
            spriteBatch.End();
        }

    }
}

