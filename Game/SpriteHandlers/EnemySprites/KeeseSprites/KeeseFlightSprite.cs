using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using MainGame.Enemies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.EnemySprites
{
    public class KeeseFlightSprite : AnimatedSpriteWithOffset
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
        public int threshold = 32;
        public int subThreshold = 8;
        public float posX = 0;
        public float posY = 0;

        /// <summary>
        /// The key is the current frame (starting at 0) and corresponds with currentFrame.
        /// The value is how many game seconds the frame should be displayed.
        /// </summary>
        private Dictionary<int, int> frameDisplayTimeMap;

        public KeeseFlightSprite(
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
            flying = true;
            this.spriteBatch = spriteBatch;
            
            spriteDisplayTimeLapse = 0;
            frameDisplayTimeMap = new()
            {
                { 0, 16},
                { 1, 16},
                { 2, 8},
                { 3, 8},
                { 4, 8},
                { 5, 8},
                { 6, 3},
                { 7, 3},
                { 8, 3},
                { 9, 3},
                { 10, 4},
                { 11, 8},
                { 12, 8},
                { 13, 8},
                { 14, 8},
                { 15, 16},
                { 16, 16},
            };


        }


        public override void Update()
        {


            

            // animation stage is specific part of animation (see #enemies channel in sprint 2)

            // for now (sprint 2 feb 18 (at 18th ave library 4th floor just vibing) just gonna do full animation but in future takeoff/landing will be controlled by state
          
            if (animationStage == 16)
            {
                animationStage = 0;
            }
           
            {
                if (spriteDisplayTimeLapse == frameDisplayTimeMap[animationStage])
                {

                    spriteDisplayTimeLapse = 0;

                    GetNextFrame();
                    animationStage++;
                   

                }
            } 
           
            spriteDisplayTimeLapse++;

            // movement xd

           
        }

        public override void Draw(float x, float y, Color color)
        {

            // fuckit doing it the scuffed way for now or else ill kill myself

            // only change direction if conditions are met
            // hoyl fuck there just no way this is a smart way to do this
            // could put in some sort of data structure but idc ill do it later this is due soon



            // only change pos if its within the window...

            
            
           
            


            if (count == threshold)
            {
                changedir = true;
                if  (count == 32)
                {
                    threshold = 64;
                    subThreshold = 4;
                } 
                if (count == 64)
                {
                    threshold = 80;
                    subThreshold = 2;
                }
                if (count == 80)
                {
                    threshold = 112;
                    subThreshold = 4;
                }
                if (count == 112)
                {
                    threshold = 144;
                    subThreshold = 8;
                }
                if (count == 144)
                {
                    threshold = 32;
                    count = 0;
                    subThreshold = 8;
                    //changedir = false;
                }
            }


            if (changedir)
            {
                dir = rnd.Next(1, 9);
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
                increment = false;
               
                
            }
            moveCount++;
            count++;

            // attempt to keep this dude out of bounds... works but some odd behaviour will need some tweaks... hes teleproting
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
