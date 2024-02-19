using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.ItemSprites
{
    public class FireSprite : AnimatedSpriteWithOffset
    {
        /// <summary>
        /// The key is the current animationframe (starting at 0).
        /// The value is how many game seconds the frame should be displayed.
        /// </summary>
        private Dictionary<int, int> frameDisplayTimeMap;
        private readonly SpriteBatch spriteBatch;
        private int spriteDisplayTimeLapse;
        private bool spriteFlip;
        public override int AnimationFrameDuration => frameDisplayTimeMap.Count;

        public FireSprite(
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

        public override void Draw(float x, float y, Color color)
        {
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
