using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MainGame.SpriteHandlers
{
	public class PlayerStaticIdleSprite : ISprite
    {
        public readonly Texture2D Texture;
        private readonly SpriteBatch spriteBatch;
        private readonly int width;
        private readonly int height;
        private readonly int scale;

        public PlayerStaticIdleSprite(Texture2D texture, SpriteBatch spriteBatch)
        {
            Texture = texture;
            this.spriteBatch = spriteBatch;
            width = Texture.Width;
            height = Texture.Height;
            scale = 2;
        }

        public void Update()
        {
            // not needed
        }

        public void Draw(float x, float y, Color color)
        {

            Rectangle sourceRectangle = new Rectangle(
                0,
                0,
                width,
                height);
            Rectangle destinationRectangle = new Rectangle(
                (int)(x - width),
                (int)(y - height),
                width * scale,
                height * scale);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, color);
            spriteBatch.End();
        }
    }
}
