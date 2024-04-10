using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.EnemySprites
{
    public class KeeseLandingSprite : AnimatedSpriteWithOffset
    {
        public override int AnimationFrameDuration
        {
            get
            {
                int totalDuration = 0;
                foreach (CurrentSpriteInfo spriteInfo in currentAnimationFrameData)
                {
                    totalDuration += spriteInfo.duration;
                }
                return totalDuration;
            }
        }

        private struct CurrentSpriteInfo
        {
            public int frameIndex;
            public int duration;
        }

        /// <summary>
        /// The key is the current frame (starting at 0) and corresponds with currentFrame.
        /// The value is how many game seconds the frame should be displayed and what frame to display.
        /// </summary>
        private readonly List<CurrentSpriteInfo> currentAnimationFrameData;
        private readonly SpriteBatch spriteBatch;
        private int spriteDisplayTimer;

        public KeeseLandingSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int numRows,
            int numColumns,
            int numberOfFrames,
    int frameHeight = GameConstants.KeeseLandingSpriteDefaultFrameHeight,
    int frameWidth = GameConstants.KeeseLandingSpriteDefaultFrameWidth,
    int textureStartingX = GameConstants.KeeseLandingSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.KeeseLandingSpriteDefaultTextureStartingY,
    int scale = GameConstants.KeeseLandingSpriteDefaultScale,
    float layerDepth = GameConstants.KeeseLandingSpriteDefaultLayerDepth)
    : base(texture, numRows, numColumns, frameWidth, frameHeight, numberOfFrames,
          textureStartingX, textureStartingY, scale, layerDepth)
{
            this.spriteBatch = spriteBatch;
            currentAnimationFrameData = new()
            {
                new() {frameIndex = 0, duration = 4 },
                new() {frameIndex = 1, duration = 4 },
                new() {frameIndex = 0, duration = 8 },
                new() {frameIndex = 1, duration = 8 },
                new() {frameIndex = 0, duration = 16 },
                new() {frameIndex = 1, duration = 16 },

            };
            totalFrameCount = currentAnimationFrameData.Count;
            spriteDisplayTimer = currentAnimationFrameData[currentFrame].duration;
        }

        public override void Update()
        {
            if (spriteDisplayTimer <= 0)
            {
                GetNextFrame();
                spriteDisplayTimer = currentAnimationFrameData[currentFrame].duration;
            }

            spriteDisplayTimer--;
        }

        public override void Draw(float x, float y, Color color)
        {
            Rectangle srcRectangle = GetSourceRectangle();
            Rectangle destRectangle = GetDestinationRectangle(x, y);

            spriteBatch.Draw(Texture, destRectangle, srcRectangle, color, rotation, origin, SpriteEffects.None, layer);
        }

        protected override Rectangle GetSourceRectangle()
        {
            return new Rectangle(
                currentAnimationFrameData[currentFrame].frameIndex * FrameWidth + StartXPosition,
                StartYPosition,
                FrameWidth,
                FrameHeight);
        }
    }
}