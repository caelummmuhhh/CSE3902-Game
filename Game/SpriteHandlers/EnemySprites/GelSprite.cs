﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.EnemySprites
{
    public class GelSprite : AnimatedSpriteWithOffset
    {
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
        Boolean on = true;
        public int flip = 0;

        private readonly SpriteBatch spriteBatch;
        private int spriteDisplayTimeLapse;

        public GelSprite(
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
                { 0, 2 },
                { 1, 2 },
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


            if (count % 16 == 0)
            {
                dir = rnd.Next(1, 9);
                if (on)
                {
                    on = false;
                } else
                {
                    on = true;
                }
            }

            if (on)
            {



                //up
                if (dir == 1)
                {
                    posY -= VerticalSpeed;

                }
                // diagonal up right
                if (dir == 2)
                {
                    posY -= VerticalSpeed;
                    posX += HorizontalSpeed;

                }
                // right
                if (dir == 3)
                {
                    posX += HorizontalSpeed;
                }
                // diagonal down right
                if (dir == 4)
                {
                    posY += VerticalSpeed;
                    posX += HorizontalSpeed;

                }
                // down
                if (dir == 5)
                {
                    posY += VerticalSpeed;

                }
                // diagonal down left
                if (dir == 6)
                {
                    posX -= HorizontalSpeed;
                    posY += VerticalSpeed;

                }
                // left
                if (dir == 7)
                {
                    posX -= HorizontalSpeed;

                }
                // diagonal up left
                if (dir == 8)
                {
                    posX -= HorizontalSpeed;
                    posY -= VerticalSpeed;

                }




            }
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




