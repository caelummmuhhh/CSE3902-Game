using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.EnemySprites
{
    public class GoriyaWalkingRightSprite : AnimatedSpriteWithOffset
    {
        /// <summary>
        /// The key is the current frame (starting at 0) and corresponds with currentFrame.
        /// The value is how many game seconds the frame should be displayed.
        /// </summary>
        private readonly Dictionary<int, int> frameDisplayTimeMap;
        private readonly SpriteBatch spriteBatch;
        private int spriteDisplayTimeLapse;

        public GoriyaWalkingRightSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int numRows,
            int numColumns,
            int numberOfFrames,
    int frameHeight = GameConstants.GoriyaWalkingRightSpriteDefaultFrameHeight,
    int frameWidth = GameConstants.GoriyaWalkingRightSpriteDefaultFrameWidth,
    int textureStartingX = GameConstants.GoriyaWalkingRightSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.GoriyaWalkingRightSpriteDefaultTextureStartingY,
    int scale = GameConstants.GoriyaWalkingRightSpriteDefaultScale,
    float layerDepth = GameConstants.GoriyaWalkingRightSpriteDefaultLayerDepth)
    : base(texture, numRows, numColumns, frameWidth, frameHeight, numberOfFrames,
          textureStartingX, textureStartingY, scale, layerDepth)
{
    this.spriteBatch = spriteBatch;
    spriteDisplayTimeLapse = GameConstants.GoriyaWalkingRightSpriteInitialDisplayTimeLapse;
    frameDisplayTimeMap = new()
    {
        { GameConstants.GoriyaWalkingRightSpriteInitialFrame, GameConstants.GoriyaWalkingRightSpriteFrameDisplayTime },
        { GameConstants.GoriyaWalkingRightSpriteNextFrame, GameConstants.GoriyaWalkingRightSpriteFrameDisplayTime },
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
