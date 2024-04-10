using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.ProjectileSprites
{
    public class SwordBeamRightProjectileSprite : AnimatedSpriteWithOffset
    {
        /// <summary>
        /// The key is the current frame (starting at 0) and corresponds with currentFrame.
        /// The value is how many game seconds the frame should be displayed.
        /// </summary>
        private readonly Dictionary<int, int> frameDisplayTimeMap;
        private readonly SpriteBatch spriteBatch;
        private int spriteDisplayTimeLapse;

        public SwordBeamRightProjectileSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int numRows,
            int numColumns,
            int numberOfFrames,
    int frameHeight = GameConstants.SwordBeamRightProjectileSpriteDefaultFrameHeight,
    int frameWidth = GameConstants.SwordBeamRightProjectileSpriteDefaultFrameWidth,
    int textureStartingX = GameConstants.SwordBeamRightProjectileSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.SwordBeamRightProjectileSpriteDefaultTextureStartingY,
    int scale = GameConstants.SwordBeamRightProjectileSpriteDefaultScale,
    float layerDepth = GameConstants.SwordBeamRightProjectileSpriteDefaultLayerDepth)
    : base(texture, numRows, numColumns, frameWidth, frameHeight, numberOfFrames,
          textureStartingX, textureStartingY, scale, layerDepth)
{
    this.spriteBatch = spriteBatch;
    spriteDisplayTimeLapse = 0;
    rotation = GameConstants.SwordBeamRightProjectileSpriteDefaultRotation;
    frameDisplayTimeMap = new()
    {
        { 0, GameConstants.SwordBeamRightProjectileSpriteDefaultFrame0DisplayTime },
        { 1, GameConstants.SwordBeamRightProjectileSpriteDefaultFrame1DisplayTime },
        { 2, GameConstants.SwordBeamRightProjectileSpriteDefaultFrame2DisplayTime },
        { 3, GameConstants.SwordBeamRightProjectileSpriteDefaultFrame3DisplayTime }
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
