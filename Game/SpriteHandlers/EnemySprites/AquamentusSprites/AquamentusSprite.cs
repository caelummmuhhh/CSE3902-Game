using System;
using System.Collections.Generic;
using MainGame.Enemies;
using MainGame.SpriteHandlers.EnemySprites.AquamentusSprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.EnemySprites
{
    public class AquamentusSprite : AnimatedSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;
        private int spriteDisplayTimeLapse;
        public int animationStage = 0;
        // temp mock state variable for animation
        bool flying;
        public Enemy enemy;
        Random rnd = new Random();
        public float VerticalSpeed = 5f;
        public float HorizontalSpeed = 4f;
        int dir = 0;
        bool changedir = true;
        bool increment = true;
        public int count = 0;
        public int moveCount = 0;
        public int threshold = 64;
        public int subThreshold = 8;
        public float posX = 0;
        public float posY = 0;

        /// <summary>
        /// The key is the current frame (starting at 0) and corresponds with currentFrame.
        /// The value is how many game seconds the frame should be displayed.
        /// </summary>
        private Dictionary<int, int> frameDisplayTimeMap;

        public AquamentusSprite(
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
                { 0, 16 },
                { 1, 16 },
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
            if (count == threshold)
            {
                changedir = true;
                if (count == 64)
                {
                    threshold = 128;
                    subThreshold = 8;
                }
                if (count == 128)
                {
                    int temp;
                    temp = rnd.Next(0, 2);
                    if (temp == 0)
                    {
                        //attack
                        threshold = 160;
                        subThreshold = 8;
                        // spawn projectiles (confused how to within this class)
                      


                    }
                    else
                    {
                        count = 0;
                        threshold = 64;
                        subThreshold = 8;
                    }
                }

            }


            if (changedir)
            {
                dir = rnd.Next(1, 3);
                changedir = false;
            }
            // only change position if conditions are met

            if (moveCount >= subThreshold)
            {
                increment = true;
                moveCount = 0;
            }
            //
            if (increment)
            {
                dir = rnd.Next(1, 3);
                if (dir == 1)
                {
                    posX += HorizontalSpeed;

                }

                if (dir == 2)
                {

                    posX -= HorizontalSpeed;

                }
                increment = false;

            }
            moveCount++;
            count++;

            if ((x + posX + HorizontalSpeed < (xMax)) && ((x + posX + HorizontalSpeed) > 0))
            {
                x = x + posX;

            }
            else
            {
                if ((HorizontalSpeed + posX + x) >= xMax)
                {
                    posX -= (HorizontalSpeed * 2);
                    x = xMax - HorizontalSpeed * 2;
                }
                else
                {
                    posX += HorizontalSpeed;
                    x = 0 + HorizontalSpeed;
                }
            }
            if ((y + posY + VerticalSpeed < (yMax)) && ((y + posY + VerticalSpeed) > 0))
            {
                y = y + posY;
            }
            else
            {
                if ((posY + y + VerticalSpeed) >= yMax)
                {
                    posY -= VerticalSpeed * 2;
                    y = yMax - VerticalSpeed * 2;
                }
                else
                {
                    posY += VerticalSpeed * 2;
                    y = 0 + VerticalSpeed;
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
            spriteBatch.Draw(Texture, destRectangle, srcRectangle, color);
            spriteBatch.End();
        }
    }
}
