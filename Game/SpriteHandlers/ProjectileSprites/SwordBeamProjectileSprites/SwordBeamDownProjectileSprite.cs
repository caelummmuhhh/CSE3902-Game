using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.ProjectileSprites
{
	public class SwordBeamDownProjectileSprite : AnimatedSpriteWithOffset
    {
        /// <summary>
        /// The key is the current frame (starting at 0) and corresponds with currentFrame.
        /// The value is how many game seconds the frame should be displayed.
        /// </summary>
        private readonly Dictionary<int, int> frameDisplayTimeMap;
        private readonly SpriteBatch spriteBatch;
        private int spriteDisplayTimeLapse;

        public SwordBeamDownProjectileSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int numRows,
            int numColumns,
            int numberOfFrames,
    int frameHeight = GameConstants.SwordBeamDownProjectileSpriteDefaultFrameHeight,
    int frameWidth = GameConstants.SwordBeamDownProjectileSpriteDefaultFrameWidth,
    int textureStartingX = GameConstants.SwordBeamDownProjectileSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.SwordBeamDownProjectileSpriteDefaultTextureStartingY,
    int scale = GameConstants.SwordBeamDownProjectileSpriteDefaultScale,
    float layerDepth = GameConstants.SwordBeamDownProjectileSpriteDefaultLayerDepth)
    : base(texture, numRows, numColumns, frameWidth, frameHeight, numberOfFrames,
          textureStartingX, textureStartingY, scale, layerDepth)
{
    this.spriteBatch = spriteBatch;
    spriteDisplayTimeLapse = 0;
    rotation = MathHelper.ToRadians(GameConstants.SwordBeamDownProjectileSpriteDefaultRotation);
    origin = new(FrameWidth / 2f, FrameHeight / 2f);
    frameDisplayTimeMap = new()
    {
        { 0, GameConstants.SwordBeamDownProjectileSpriteDefaultFrame0DisplayTime },
        { 1, GameConstants.SwordBeamDownProjectileSpriteDefaultFrame1DisplayTime },
        { 2, GameConstants.SwordBeamDownProjectileSpriteDefaultFrame2DisplayTime },
        { 3, GameConstants.SwordBeamDownProjectileSpriteDefaultFrame3DisplayTime }
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
