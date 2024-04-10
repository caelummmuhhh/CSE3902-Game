using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.EnemySprites.AquamentusSprites
{
    public class AquamentusAttackProjectileSprite : AnimatedSpriteWithOffset
    {
        /// <summary>
        /// The key is the current frame (starting at 0) and corresponds with currentFrame.
        /// The value is how many game seconds the frame should be displayed.
        /// </summary>
        private readonly Dictionary<int, int> frameDisplayTimeMap;
        private readonly SpriteBatch spriteBatch;
        private int spriteDisplayTimeLapse;

        public AquamentusAttackProjectileSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int numRows,
            int numColumns,
            int numberOfFrames,
int frameHeight = GameConstants.AquamentusAttackProjectileSpriteDefaultFrameHeight,
    int frameWidth = GameConstants.AquamentusAttackProjectileSpriteDefaultFrameWidth,
    int textureStartingX = GameConstants.AquamentusAttackProjectileSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.AquamentusAttackProjectileSpriteDefaultTextureStartingY,
    int scale = GameConstants.AquamentusAttackProjectileSpriteDefaultScale,
    float layerDepth = GameConstants.AquamentusAttackProjectileSpriteDefaultLayerDepth)
    : base(texture, numRows, numColumns, frameWidth, frameHeight, numberOfFrames,
          textureStartingX, textureStartingY, scale, layerDepth)
{
    this.spriteBatch = spriteBatch;
    spriteDisplayTimeLapse = GameConstants.AquamentusAttackProjectileSpriteInitialDisplayTimeLapse;
    frameDisplayTimeMap = new()
    {
        { GameConstants.AquamentusAttackProjectileSpriteInitialFrame, GameConstants.AquamentusAttackProjectileSpriteFrameDisplayTime },
        { GameConstants.AquamentusAttackProjectileSpriteNextFrame1, GameConstants.AquamentusAttackProjectileSpriteFrameDisplayTime },
        { GameConstants.AquamentusAttackProjectileSpriteNextFrame2, GameConstants.AquamentusAttackProjectileSpriteFrameDisplayTime },
        { GameConstants.AquamentusAttackProjectileSpriteNextFrame3, GameConstants.AquamentusAttackProjectileSpriteFrameDisplayTime },
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
