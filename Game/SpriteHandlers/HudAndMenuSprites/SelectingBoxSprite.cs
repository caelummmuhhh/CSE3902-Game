﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.ItemSprites
{
	public class SelectingBoxSprite : AnimatedSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;
        private int spriteDisplayTimeLapse;

        /// <summary>
        /// The key is the current frame (starting at 0) and corresponds with currentFrame.
        /// The value is how many game seconds the frame should be displayed.
        /// </summary>
        private readonly Dictionary<int, int> frameDisplayTimeMap;

        public SelectingBoxSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int numRows,
            int numColumns,
            int numberOfFrames,
            int frameHeight = 16,
            int frameWidth = 16,
            int textureStartingX = 0,
            int textureStartingY = 0,
            int scale = 1,
            float layerDepth = 0.5f)
            : base(texture, numRows, numColumns, frameWidth, frameHeight, numberOfFrames,
                  textureStartingX, textureStartingY, scale, layerDepth)
        {
            this.spriteBatch = spriteBatch;
            spriteDisplayTimeLapse = 0;
            frameDisplayTimeMap = new()
            {
                { 0, 8 },
                { 1, 8 },
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
            Rectangle srcRectangle = GetSourceRectangle();
            Rectangle destRectangle = GetDestinationRectangle(x, y);

            spriteBatch.Draw(Texture, destRectangle, srcRectangle, color, rotation, origin, SpriteEffects.None, layer);
        }
    }
}

