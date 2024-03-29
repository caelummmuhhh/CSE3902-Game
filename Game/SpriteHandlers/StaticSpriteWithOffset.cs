﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers
{
	public abstract class StaticSpriteWithOffset : StaticSprite
	{
        public readonly int StartXPosition;
        public readonly int StartYPosition;
        public virtual int FrameWidth { get => frameWidth; }
        public virtual int FrameHeight { get => frameHeight; }

        protected int frameWidth;
        protected int frameHeight;
        protected float rotation;
        protected Vector2 origin;

        public StaticSpriteWithOffset(
            Texture2D texture,
            int frameHeight,
            int frameWidth,
            int textureStartingX,
            int textureStartingY,
            int scale,
            float layerDepth)
            : base(texture, scale)
		{
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            StartXPosition = textureStartingX;
            StartYPosition = textureStartingY;
            origin = new(FrameWidth / 2f, FrameHeight / 2f);
            rotation = 0f;
            layer = layerDepth;
        }

        protected override Rectangle GetSourceRectangle()
        {
            return new Rectangle(StartXPosition, StartYPosition, FrameWidth, FrameHeight);
        }

        protected Rectangle GetDestinationRectangle(float x, float y)
        {
            return new(
                (int)(x - origin.X),
                (int)(y - origin.Y),
                FrameWidth * scale,
                FrameHeight * scale);
        }
    }
}

