using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.EnemySprites
{
    public class GoriyaWalkingUpSprite : AnimatedSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;
        private int spriteDisplayTimeLapse;
        bool spriteFlip;
        Random rnd = new Random();
        public float VerticalSpeed = 5f;
        public float HorizontalSpeed = 4f;
        int dir = 0;
        bool changedir = true;
        bool increment = true;
        public int count = 0;
        public int moveCount = 0;
        public int threshold = 16;
        public int subThreshold = 1;
        public float posX = 0;
        public float posY = 0;

        /// <summary>
        /// The key is the current frame (starting at 0) and corresponds with currentFrame.
        /// The value is how many game seconds the frame should be displayed.
        /// </summary>
        private Dictionary<int, int> frameDisplayTimeMap;

        public GoriyaWalkingUpSprite(
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
            spriteFlip = false;
            frameDisplayTimeMap = new()
            {
                { 0, 6 },
                { 1, 6 },
            };
        }


        public override void Update()
        {
            if (spriteDisplayTimeLapse != frameDisplayTimeMap[currentFrame])
            {
                spriteDisplayTimeLapse++;
                return;
            }
            spriteFlip = !spriteFlip;
            spriteDisplayTimeLapse = 0;
        }

        public override void Draw(float x, float y, Color color, float xMax, float yMax)
        {

            y += VerticalSpeed;
            var spriteEffect = SpriteEffects.None;
            if (spriteFlip)
            {
                spriteEffect = SpriteEffects.FlipHorizontally;
            }

            Rectangle srcRectangle = GetSourceRectangle();
            Rectangle destRectangle = new Rectangle(
                (int)(x - FrameWidth),
                (int)(y - FrameHeight),
                FrameWidth * Scale,
                FrameHeight * Scale
            );
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
            spriteBatch.Draw(Texture,
                destRectangle,
                srcRectangle,
                color,
                0f,
                new Vector2(0, 0),
                spriteEffect,
                0f);
            spriteBatch.End();
        }
    }
}
