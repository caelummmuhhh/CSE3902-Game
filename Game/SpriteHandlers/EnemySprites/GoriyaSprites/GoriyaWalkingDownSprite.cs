using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.EnemySprites
{
    public class GoriyaWalkingDownSprite : AnimatedSpriteWithOffset
    {
        /// <summary>
        /// The key is the current frame (starting at 0) and corresponds with currentFrame.
        /// The value is how many game seconds the frame should be displayed.
        /// </summary>
        private readonly Dictionary<int, int> frameDisplayTimeMap;
        private readonly SpriteBatch spriteBatch;
        private int spriteDisplayTimeLapse;
        bool spriteFlip;

        public GoriyaWalkingDownSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int numRows,
            int numColumns,
            int numberOfFrames,
    int frameHeight = GameConstants.GoriyaWalkingDownSpriteDefaultFrameHeight,
    int frameWidth = GameConstants.GoriyaWalkingDownSpriteDefaultFrameWidth,
    int textureStartingX = GameConstants.GoriyaWalkingDownSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.GoriyaWalkingDownSpriteDefaultTextureStartingY,
    int scale = GameConstants.GoriyaWalkingDownSpriteDefaultScale,
    float layerDepth = GameConstants.GoriyaWalkingDownSpriteDefaultLayerDepth)
    : base(texture, numRows, numColumns, frameWidth, frameHeight, numberOfFrames,
          textureStartingX, textureStartingY, scale, layerDepth)
{
    this.spriteBatch = spriteBatch;
    spriteDisplayTimeLapse = GameConstants.GoriyaWalkingDownSpriteInitialDisplayTimeLapse;
    spriteFlip = GameConstants.GoriyaWalkingDownSpriteInitialFlip;
    frameDisplayTimeMap = new()
    {
        { GameConstants.GoriyaWalkingDownSpriteInitialFrame, GameConstants.GoriyaWalkingDownSpriteFrameDisplayTime },
        { GameConstants.GoriyaWalkingDownSpriteNextFrame, GameConstants.GoriyaWalkingDownSpriteFrameDisplayTime },
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
            SpriteEffects spriteEffect = spriteFlip ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            Rectangle srcRectangle = GetSourceRectangle();
            Rectangle destRectangle = GetDestinationRectangle(x, y);

            spriteBatch.Draw(Texture, destRectangle, srcRectangle, color, rotation, origin, spriteEffect, layer);
        }
    }
}
