using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.ProjectileSprites
{
    public class WoodenBoomerangSprite : AnimatedSpriteWithOffset
    {
        private struct CurrentSpriteInfo
        {
            public int frameIndex;
            public SpriteEffects spriteEffects;
        }

        /// <summary>
        /// The key is the current animation frame in the animation loop.
        /// The value is all the information for the frame that will be displayed
        /// in that frame.
        /// </summary>
        private readonly List<CurrentSpriteInfo> currentAnimationFrameData;
        private readonly SpriteBatch spriteBatch;
        private readonly int frameDisplayTime;
        private int spriteDisplayTimeLapse;
        private int currentAnimationFrame;

        public WoodenBoomerangSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int numRows,
            int numColumns,
            int numberOfFrames,
    int frameHeight = GameConstants.WoodenBoomerangSpriteDefaultFrameHeight,
    int frameWidth = GameConstants.WoodenBoomerangSpriteDefaultFrameWidth,
    int textureStartingX = GameConstants.WoodenBoomerangSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.WoodenBoomerangSpriteDefaultTextureStartingY,
    int scale = GameConstants.WoodenBoomerangSpriteDefaultScale,
    float layerDepth = GameConstants.WoodenBoomerangSpriteDefaultLayerDepth):            
    base(texture, numRows, numColumns, frameWidth, frameHeight, numberOfFrames,
                textureStartingX, textureStartingY, scale, layerDepth)
        {
            this.spriteBatch = spriteBatch;
            spriteDisplayTimeLapse = 0;
            currentAnimationFrame = 0;
            frameDisplayTime = 2;
            currentAnimationFrameData = new()
            {
                /* For some reason SpriteEffects appears a frame delayed  */
                new() { frameIndex = 0, spriteEffects = SpriteEffects.FlipVertically },
                new() { frameIndex = 1, spriteEffects = SpriteEffects.None },
                new() { frameIndex = 2, spriteEffects = SpriteEffects.None },
                new() { frameIndex = 1, spriteEffects = SpriteEffects.None },
                new() { frameIndex = 0, spriteEffects = SpriteEffects.FlipHorizontally },
                new() { frameIndex = 1, spriteEffects = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically },
                new() { frameIndex = 2, spriteEffects = SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically },
                new() { frameIndex = 1, spriteEffects = SpriteEffects.FlipVertically }
            };

            currentFrame = currentAnimationFrameData[currentAnimationFrame].frameIndex;
            totalFrameCount = currentAnimationFrameData.Count;
        }

        public override void Update()
        {
            if (spriteDisplayTimeLapse == frameDisplayTime)
            {
                spriteDisplayTimeLapse = 0;
                currentFrame = currentAnimationFrameData[currentAnimationFrame].frameIndex;
                currentAnimationFrame++;
                currentAnimationFrame %= totalFrameCount;
            }

            spriteDisplayTimeLapse++;
        }

        public override void Draw(float x, float y, Color color)
        {
            Rectangle srcRectangle = GetSourceRectangle();
            Rectangle destRectangle = GetDestinationRectangle(x, y);

            spriteBatch.Draw(
                Texture, destRectangle, srcRectangle, color, rotation, origin,
                currentAnimationFrameData[currentAnimationFrame].spriteEffects, layer
            );
        }
    }
}
