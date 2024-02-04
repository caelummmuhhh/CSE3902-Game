using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MainGame.SpriteHandlers
{
	public class PlayerAnimatedIdleSprite : ISprite
    {
        public readonly Texture2D Texture;
        private readonly SpriteBatch spriteBatch;
        private int currentFrame;
        private readonly int rows;
        private readonly int columns;
        private readonly int totalFrames;
        private readonly int frameRateDivider;
        private int currentUpdateVersion;
        private readonly int width;
        private readonly int height;
        private readonly int scale;

        public PlayerAnimatedIdleSprite(Texture2D texture, SpriteBatch spriteBatch, int rows, int columns)
        {
            Texture = texture;
            this.spriteBatch = spriteBatch;
            width = Texture.Width / columns;
            height = Texture.Height / rows;
            totalFrames = rows * columns;
            this.rows = rows;
            this.columns = columns;
            frameRateDivider = 10;
            currentUpdateVersion = 0;
            scale = 2;
        }

        public void Update()
        {
            currentUpdateVersion++;

            if (currentUpdateVersion == frameRateDivider)
            {
                currentFrame++;
                currentUpdateVersion = 0;
            }

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
        }

        public void Draw(float x, float y, Color color)
        {
            int currRow = currentFrame / columns;
            int currColumn = currentFrame % columns;

            Rectangle sourceRectangle = new Rectangle(
                width * currColumn,
                height * currRow,
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

