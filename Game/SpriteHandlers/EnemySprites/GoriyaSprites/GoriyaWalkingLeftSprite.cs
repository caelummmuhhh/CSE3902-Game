using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.EnemySprites
{
    public class GoriyaWalkingLeftSprite : AnimatedSpriteWithOffset
    {

        private readonly SpriteBatch spriteBatch;
        private int spriteDisplayTimeLapse;

        /// <summary>
        /// The key is the current frame (starting at 0) and corresponds with currentFrame.
        /// The value is how many game seconds the frame should be displayed.
        /// </summary>
        private Dictionary<int, int> frameDisplayTimeMap;
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

        public GoriyaWalkingLeftSprite(
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
                { 0, 6 },
                { 1, 6 },
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

        public override void Draw(float x, float y, Color color, float xMax, float yMax)
        {

            x -= HorizontalSpeed;
            if ((posX + HorizontalSpeed < (xMax / 2)) && ((x + posX + HorizontalSpeed) > 0))
            {
                x = x + posX;

            }
            else
            {
                if ((posX + x > xMax))
                {
                    posX = (xMax / 2) - HorizontalSpeed;
                    x = xMax - HorizontalSpeed;
                }
                else
                {
                    posX += HorizontalSpeed;
                    x = 0 + HorizontalSpeed;
                }
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
                SpriteEffects.FlipHorizontally,
                0f);
            spriteBatch.End();
        }
    }



}
