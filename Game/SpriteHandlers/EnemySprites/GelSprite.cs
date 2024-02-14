using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.EnemySprites
{
    public class GelSprite : AnimatedSpriteWithOffset
    {

        private readonly SpriteBatch spriteBatch;
        private int spriteDisplayTimeLapse;

        /// <summary>
        /// The key is the current frame (starting at 0) and corresponds with currentFrame.
        /// The value is how many game seconds the frame should be displayed.
        /// </summary>
        private Dictionary<int, int> frameDisplayTimeMap;

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
