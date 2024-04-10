using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.ProjectileSprites
{
    public class BombExplodingSprite : AnimatedSpriteWithOffset
    {
        public override int AnimationFrameDuration
        {
            get
            {
                int totalDisplayTime = 0;
                foreach (int displayTime in frameDisplayTimeMap.Values)
                {
                    totalDisplayTime += displayTime;
                }
                return totalDisplayTime;
            }
        }

        /// <summary>
        /// The key is the current frame (starting at 0) and corresponds with currentFrame.
        /// The value is how many game seconds the frame should be displayed.
        /// </summary>
        private readonly Dictionary<int, int> frameDisplayTimeMap;
        private readonly SpriteBatch spriteBatch;
        private int spriteDisplayTimeLapse;

        public BombExplodingSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int numRows,
            int numColumns,
            int numberOfFrames,
    int frameHeight = GameConstants.BombExplodingSpriteDefaultFrameHeight,
    int frameWidth = GameConstants.BombExplodingSpriteDefaultFrameWidth,
    int textureStartingX = GameConstants.BombExplodingSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.BombExplodingSpriteDefaultTextureStartingY,
    int scale = GameConstants.BombExplodingSpriteDefaultScale,
    float layerDepth = GameConstants.BombExplodingSpriteDefaultLayerDepth)
    : base(texture, numRows, numColumns, frameWidth, frameHeight, numberOfFrames,
          textureStartingX, textureStartingY, scale, layerDepth)
{
    this.spriteBatch = spriteBatch;
    spriteDisplayTimeLapse = 0;
    frameDisplayTimeMap = new()
    {
        { 0, GameConstants.BombExplodingSpriteDefaultFrame0DisplayTime },
        { 1, GameConstants.BombExplodingSpriteDefaultFrame1DisplayTime },
        { 2, GameConstants.BombExplodingSpriteDefaultFrame2DisplayTime },
        { 3, GameConstants.BombExplodingSpriteDefaultFrame3DisplayTime }
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
            Rectangle destRectangle = GetDestinationRectangle(x, y);

            spriteBatch.Draw(Texture, destRectangle, srcRectangle, color, rotation, origin, SpriteEffects.None, layer);
        }
    }
}
