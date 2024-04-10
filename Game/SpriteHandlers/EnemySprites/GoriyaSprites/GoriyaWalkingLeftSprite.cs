using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.EnemySprites
{
    public class GoriyaWalkingLeftSprite : AnimatedSpriteWithOffset
    {
        /// <summary>
        /// The key is the current frame (starting at 0) and corresponds with currentFrame.
        /// The value is how many game seconds the frame should be displayed.
        /// </summary>
        private readonly Dictionary<int, int> frameDisplayTimeMap;
        private readonly SpriteBatch spriteBatch;
        private int spriteDisplayTimeLapse;

        public GoriyaWalkingLeftSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int numRows,
            int numColumns,
            int numberOfFrames,
    int frameHeight = GameConstants.GoriyaWalkingLeftSpriteDefaultFrameHeight,
    int frameWidth = GameConstants.GoriyaWalkingLeftSpriteDefaultFrameWidth,
    int textureStartingX = GameConstants.GoriyaWalkingLeftSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.GoriyaWalkingLeftSpriteDefaultTextureStartingY,
    int scale = GameConstants.GoriyaWalkingLeftSpriteDefaultScale,
    float layerDepth = GameConstants.GoriyaWalkingLeftSpriteDefaultLayerDepth)
    : base(texture, numRows, numColumns, frameWidth, frameHeight, numberOfFrames,
          textureStartingX, textureStartingY, scale, layerDepth)
{
    this.spriteBatch = spriteBatch;
    spriteDisplayTimeLapse = GameConstants.GoriyaWalkingLeftSpriteInitialDisplayTimeLapse;
    frameDisplayTimeMap = new()
    {
        { GameConstants.GoriyaWalkingLeftSpriteInitialFrame, GameConstants.GoriyaWalkingLeftSpriteFrameDisplayTime },
        { GameConstants.GoriyaWalkingLeftSpriteNextFrame, GameConstants.GoriyaWalkingLeftSpriteFrameDisplayTime },
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

            spriteBatch.Draw(Texture, destRectangle, srcRectangle, color, rotation, origin, SpriteEffects.FlipHorizontally, layer);
        }
    }
}
