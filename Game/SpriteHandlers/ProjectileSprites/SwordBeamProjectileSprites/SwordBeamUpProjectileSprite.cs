using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.ProjectileSprites
{
    public class SwordBeamUpProjectileSprite : AnimatedSpriteWithOffset
    {
        /// <summary>
        /// The key is the current frame (starting at 0) and corresponds with currentFrame.
        /// The value is how many game seconds the frame should be displayed.
        /// </summary>
        private readonly Dictionary<int, int> frameDisplayTimeMap;
        private readonly SpriteBatch spriteBatch;
        private int spriteDisplayTimeLapse;

        public SwordBeamUpProjectileSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int numRows,
            int numColumns,
            int numberOfFrames,
    int frameHeight = GameConstants.SwordBeamUpProjectileSpriteDefaultFrameHeight,
    int frameWidth = GameConstants.SwordBeamUpProjectileSpriteDefaultFrameWidth,
    int textureStartingX = GameConstants.SwordBeamUpProjectileSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.SwordBeamUpProjectileSpriteDefaultTextureStartingY,
    int scale = GameConstants.SwordBeamUpProjectileSpriteDefaultScale,
    float layerDepth = GameConstants.SwordBeamUpProjectileSpriteDefaultLayerDepth)
    : base(texture, numRows, numColumns, frameWidth, frameHeight, numberOfFrames,
          textureStartingX, textureStartingY, scale, layerDepth)
{
    this.spriteBatch = spriteBatch;
    spriteDisplayTimeLapse = 0;
    rotation = MathHelper.ToRadians(GameConstants.SwordBeamUpProjectileSpriteDefaultRotation);
    origin = new(FrameWidth / 2f, FrameHeight / 2f);
    frameDisplayTimeMap = new()
    {
        { 0, GameConstants.SwordBeamUpProjectileSpriteDefaultFrame0DisplayTime },
        { 1, GameConstants.SwordBeamUpProjectileSpriteDefaultFrame1DisplayTime },
        { 2, GameConstants.SwordBeamUpProjectileSpriteDefaultFrame2DisplayTime },
        { 3, GameConstants.SwordBeamUpProjectileSpriteDefaultFrame3DisplayTime }
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
