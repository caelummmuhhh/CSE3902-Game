using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.EnemySprites
{
    public class KeeseFlightSprite : AnimatedSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;
        private int spriteDisplayTimeLapse;
        int animationStage = 0;
        // temp mock state variable for animation
        bool flying;

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
                { 8, 8},
                { 9, 8},
                { 10, 8},
                { 11, 8},
                { 12, 16},
                { 13, 16},
            };


        }


        public override void Update()
        {




            // animation stage is specific part of animation (see #enemies channel in sprint 2)

            // for now (sprint 2 feb 18 (at 18th ave library 4th floor just vibing) just gonna do full animation but in future takeoff/landing will be controlled by state
            if (animationStage == 7)
            {
                flying = false;
            }
            if (animationStage == 13)
            {
                animationStage = 0;
            }
            if (flying)
            {
                if (spriteDisplayTimeLapse == frameDisplayTimeMap[animationStage])
                {

                    spriteDisplayTimeLapse = 0;

                    GetNextFrame();
                    animationStage++;
                   

                }
            } else
            {
                if (spriteDisplayTimeLapse == frameDisplayTimeMap[animationStage])
                {

                    spriteDisplayTimeLapse = 0;

                    GetNextFrame();
                    animationStage++;

                }
            }
           
            spriteDisplayTimeLapse++;
        }

        public override void Draw(float x, float y, Color color)
        {
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
