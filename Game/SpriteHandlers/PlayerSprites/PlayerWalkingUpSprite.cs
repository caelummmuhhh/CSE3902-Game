using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.PlayerSprites
{
    public class PlayerWalkingUpSprite : AnimatedSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;
        private int spriteDisplayTimeLapse;

        /// <summary>
        /// The key is the current frame (starting at 0) and corresponds with currentFrame.
        /// The value is how many game seconds the frame should be displayed.
        /// </summary>
        private readonly Dictionary<int, int> frameDisplayTimeMap;

        public PlayerWalkingUpSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int numRows,
            int numColumns,
            int numberOfFrames,
    int frameHeight = GameConstants.PlayerWalkingUpSpriteDefaultFrameHeight,
    int frameWidth = GameConstants.PlayerWalkingUpSpriteDefaultFrameWidth,
    int textureStartingX = GameConstants.PlayerWalkingUpSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.PlayerWalkingUpSpriteDefaultTextureStartingY,
    int scale = GameConstants.PlayerWalkingUpSpriteDefaultScale,
    float layerDepth = GameConstants.PlayerWalkingUpSpriteDefaultLayerDepth)
    : base(texture, numRows, numColumns, frameWidth, frameHeight, numberOfFrames,
          textureStartingX, textureStartingY, scale, layerDepth)
{
    this.spriteBatch = spriteBatch;
    spriteDisplayTimeLapse = 0;
    frameDisplayTimeMap = new()
    {
        { 0, GameConstants.PlayerWalkingUpSpriteDefaultFrame0DisplayTime },
        { 1, GameConstants.PlayerWalkingUpSpriteDefaultFrame1DisplayTime },
        { 2, GameConstants.PlayerWalkingUpSpriteDefaultFrame2DisplayTime },
        { 3, GameConstants.PlayerWalkingUpSpriteDefaultFrame3DisplayTime }
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
