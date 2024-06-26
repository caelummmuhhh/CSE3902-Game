﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers
{
    public abstract class AnimatedSpriteWithOffset : AnimatedSprite
    {
        public readonly int StartXPosition;
        public readonly int StartYPosition;
        public override Rectangle DestinationRectangle { get; protected set; }

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
            origin = new(0, 0);
            rotation = 0f;
            layer = layerDepth;
            DestinationRectangle = new(0, 0, FrameWidth * Scale, FrameHeight * Scale);
        }

        protected override Rectangle GetSourceRectangle()
        {
            return new Rectangle(
                currentFrame * FrameWidth + StartXPosition,
                StartYPosition,
                FrameWidth,
                FrameHeight);
        }

        protected override Rectangle GetDestinationRectangle(float x, float y)
        {
            Rectangle destRect =  new(
                (int)x, (int)y,
                FrameWidth * Scale,
                FrameHeight * Scale);
            DestinationRectangle = destRect;
            return destRect;
        }
    }
}
