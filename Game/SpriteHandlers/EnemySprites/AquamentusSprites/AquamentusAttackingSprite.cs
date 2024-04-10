using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.EnemySprites
{
    public class AquamentusAttackingSprite : AnimatedSpriteWithOffset
    {
        /// <summary>
        /// The key is the current frame (starting at 0) and corresponds with currentFrame.
        /// The value is how many game seconds the frame should be displayed.
        /// </summary>
        private readonly Dictionary<int, int> frameDisplayTimeMap;
        private readonly SpriteBatch spriteBatch;
        private int spriteDisplayTimeLapse;

        public AquamentusAttackingSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int numRows,
            int numColumns,
            int numberOfFrames,
            int frameHeight = GameConstants.AquamentusAttackingSpriteDefaultFrameHeight,
    int frameWidth = GameConstants.AquamentusAttackingSpriteDefaultFrameWidth,
    int textureStartingX = GameConstants.AquamentusAttackingSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.AquamentusAttackingSpriteDefaultTextureStartingY,
    int scale = GameConstants.AquamentusAttackingSpriteDefaultScale,
    float layerDepth = GameConstants.AquamentusAttackingSpriteDefaultLayerDepth)
    : base(texture, numRows, numColumns, frameWidth, frameHeight, numberOfFrames,
          textureStartingX, textureStartingY, scale, layerDepth)
{
    this.spriteBatch = spriteBatch;
    spriteDisplayTimeLapse = GameConstants.AquamentusAttackingSpriteInitialDisplayTimeLapse;
    frameDisplayTimeMap = new()
    {
        { GameConstants.AquamentusAttackingSpriteInitialFrame, GameConstants.AquamentusAttackingSpriteFrameDisplayTime },
        { GameConstants.AquamentusAttackingSpriteNextFrame, GameConstants.AquamentusAttackingSpriteFrameDisplayTime },
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
