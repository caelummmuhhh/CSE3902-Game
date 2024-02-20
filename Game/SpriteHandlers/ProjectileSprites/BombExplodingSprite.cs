﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.ProjectileSprites
{
    public class BombExplodingSprite : AnimatedSpriteWithOffset
    {
        public override int AnimationFrameDuration
        {
            get
            {
                int totalDisplayTime = 0;
                foreach (int displayTime in frameDisplayTimeMap.Values)
                {
                    totalDisplayTime += displayTime;
                }
                return totalDisplayTime;
            }
        }

        /// <summary>
        /// The key is the current frame (starting at 0) and corresponds with currentFrame.
        /// The value is how many game seconds the frame should be displayed.
        /// </summary>
        private Dictionary<int, int> frameDisplayTimeMap;
        private readonly SpriteBatch spriteBatch;
        private int spriteDisplayTimeLapse;

        public BombExplodingSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int numRows,
            int numColumns,
            int numberOfFrames,
            int frameHeight = 16,
            int frameWidth = 16,
            int textureStartingX = 0,
            int textureStartingY = 0,
            int scale = 1) : base(texture, numRows, numColumns, frameWidth,
                                  frameHeight, numberOfFrames, textureStartingX,
                                  textureStartingY, scale)
        {
            this.spriteBatch = spriteBatch;
            spriteDisplayTimeLapse = 0;
            frameDisplayTimeMap = new()
            {
                { 0, 1 },
                { 1, 8 },
                { 2, 4 },
                { 3, 2 }
            };
        }


        public override void Update()
        {
            if (spriteDisplayTimeLapse == frameDisplayTimeMap[currentFrame])
            {
                spriteDisplayTimeLapse = 0;
                GetNextFrame();
            }

            spriteDisplayTimeLapse++;
        }

        public override void Draw(float x, float y, Color color)
        {
            Vector2 origin = new(FrameWidth / 2f, FrameHeight / 2f);
            float rotation = 0f;

            Rectangle srcRectangle = GetSourceRectangle();
            Rectangle destRectangle = new(
                (int)(x - origin.X),
                (int)(y - origin.Y),
                FrameWidth * Scale,
                FrameHeight * Scale);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
            spriteBatch.Draw(Texture, destRectangle, srcRectangle, color, rotation, origin, SpriteEffects.None, 0f);
            spriteBatch.End();
        }
    }
}