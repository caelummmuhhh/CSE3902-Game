using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.PlayerSprites
{
    public class PlayerWalkingRightSprite : AnimatedSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;
        private int spriteDisplayTimeLapse;

        /// <summary>
        /// The key is the current frame (starting at 0) and corresponds with currentFrame.
        /// The value is how many game seconds the frame should be displayed.
        /// </summary>
        private readonly Dictionary<int, int> frameDisplayTimeMap;

        public PlayerWalkingRightSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int numRows,
            int numColumns,
            int numberOfFrames,
    int frameHeight = GameConstants.PlayerWalkingRightSpriteDefaultFrameHeight,
    int frameWidth = GameConstants.PlayerWalkingRightSpriteDefaultFrameWidth,
    int textureStartingX = GameConstants.PlayerWalkingRightSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.PlayerWalkingRightSpriteDefaultTextureStartingY,
    int scale = GameConstants.PlayerWalkingRightSpriteDefaultScale,
    float layerDepth = GameConstants.PlayerWalkingRightSpriteDefaultLayerDepth)
    : base(texture, numRows, numColumns, frameWidth, frameHeight, numberOfFrames,
          textureStartingX, textureStartingY, scale, layerDepth)
{
    this.spriteBatch = spriteBatch;
    spriteDisplayTimeLapse = 0;
    frameDisplayTimeMap = new()
    {
        { 0, GameConstants.PlayerWalkingRightSpriteDefaultFrame0DisplayTime },
        { 1, GameConstants.PlayerWalkingRightSpriteDefaultFrame1DisplayTime },
        { 2, GameConstants.PlayerWalkingRightSpriteDefaultFrame2DisplayTime },
        { 3, GameConstants.PlayerWalkingRightSpriteDefaultFrame3DisplayTime }
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
