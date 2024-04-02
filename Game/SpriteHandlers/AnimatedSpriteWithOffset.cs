using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers
{
    public abstract class AnimatedSpriteWithOffset : AnimatedSprite
    {
        public readonly int StartXPosition;
        public readonly int StartYPosition;

        protected float rotation;
        protected Vector2 origin;

        public AnimatedSpriteWithOffset(
            Texture2D texture,
            int numRows,
            int numColumns,
            int frameWidth,
            int frameHeight,
            int numberOfFrames,
            int textureStartingX,
            int textureStartingY,
            int scale,
            float layerDepth)
            : base(texture, numRows, numColumns, scale)
        {
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            totalFrameCount = numberOfFrames;
            StartXPosition = textureStartingX;
            StartYPosition = textureStartingY;
            origin = new Vector2(FrameWidth / 2f, FrameHeight / 2f);
            rotation = 0f;
            layer = layerDepth;
        }

        protected override Rectangle GetSourceRectangle()
        {
            return new Rectangle(
                currentFrame * FrameWidth + StartXPosition,
                StartYPosition,
                FrameWidth,
                FrameHeight);
        }

        protected Rectangle GetDestinationRectangle(float x, float y)
        {
            return new Rectangle(
                (int)(x - origin.X),
                (int)(y - origin.Y),
                FrameWidth * Scale,
                FrameHeight * Scale);
        }
    }
}
