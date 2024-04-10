using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.ProjectileSprites
{
    public class SwordBeamLeftProjectileSprite : AnimatedSpriteWithOffset
    {
        /// <summary>
        /// The key is the current frame (starting at 0) and corresponds with currentFrame.
        /// The value is how many game seconds the frame should be displayed.
        /// </summary>
        private readonly Dictionary<int, int> frameDisplayTimeMap;
        private readonly SpriteBatch spriteBatch;
        private int spriteDisplayTimeLapse;

        public SwordBeamLeftProjectileSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int numRows,
            int numColumns,
            int numberOfFrames,
     int frameHeight = GameConstants.SwordBeamLeftProjectileSpriteDefaultFrameHeight,
    int frameWidth = GameConstants.SwordBeamLeftProjectileSpriteDefaultFrameWidth,
    int textureStartingX = GameConstants.SwordBeamLeftProjectileSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.SwordBeamLeftProjectileSpriteDefaultTextureStartingY,
    int scale = GameConstants.SwordBeamLeftProjectileSpriteDefaultScale,
    float layerDepth = GameConstants.SwordBeamLeftProjectileSpriteDefaultLayerDepth)
    : base(texture, numRows, numColumns, frameWidth, frameHeight, numberOfFrames,
          textureStartingX, textureStartingY, scale, layerDepth)
{
    this.spriteBatch = spriteBatch;
    spriteDisplayTimeLapse = 0;
    rotation = MathHelper.ToRadians(GameConstants.SwordBeamLeftProjectileSpriteDefaultRotation);
    origin = new(FrameWidth / 2f, FrameHeight / 2f);
    frameDisplayTimeMap = new()
    {
        { 0, GameConstants.SwordBeamLeftProjectileSpriteDefaultFrame0DisplayTime },
        { 1, GameConstants.SwordBeamLeftProjectileSpriteDefaultFrame1DisplayTime },
        { 2, GameConstants.SwordBeamLeftProjectileSpriteDefaultFrame2DisplayTime },
        { 3, GameConstants.SwordBeamLeftProjectileSpriteDefaultFrame3DisplayTime }
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
            Rectangle destRectangle = GetDestinationRectangle(
                x + FrameWidth * Constants.UniversalScale / 2f,
                y + FrameHeight * Constants.UniversalScale / 2f);

            spriteBatch.Draw(Texture, destRectangle, srcRectangle, color, rotation, origin, SpriteEffects.None, layer);
        }
    }
}
