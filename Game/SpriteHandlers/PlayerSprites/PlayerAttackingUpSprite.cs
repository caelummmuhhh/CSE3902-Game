using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.PlayerSprites
{
    public class PlayerAttackingUpSprite : AnimatedSpriteWithOffset
    {
        public override int AnimationFrameDuration
        {
            get
            {
                int totalDuration = 0;
                foreach (int duration in frameDisplayTimeMap.Values)
                {
                    totalDuration += duration;
                }
                return totalDuration;
            }
        }

        /// <summary>
        /// The key is the current frame (starting at 0) and corresponds with currentFrame.
        /// The value is how many game seconds the frame should be displayed.
        /// </summary>
        private readonly Dictionary<int, int> frameDisplayTimeMap;
        private readonly SpriteBatch spriteBatch;
        private int spriteDisplayTimeLapse;

        public PlayerAttackingUpSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int numRows,
            int numColumns,
            int numberOfFrames,
    int frameHeight = GameConstants.PlayerAttackingUpSpriteDefaultFrameHeight,
    int frameWidth = GameConstants.PlayerAttackingUpSpriteDefaultFrameWidth,
    int textureStartingX = GameConstants.PlayerAttackingUpSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.PlayerAttackingUpSpriteDefaultTextureStartingY,
    int scale = GameConstants.PlayerAttackingUpSpriteDefaultScale,
    float layerDepth = GameConstants.PlayerAttackingUpSpriteDefaultLayerDepth)
    : base(texture, numRows, numColumns, frameWidth, frameHeight, numberOfFrames,
          textureStartingX, textureStartingY, scale, layerDepth)
{
    this.spriteBatch = spriteBatch;
    origin = new(GameConstants.PlayerAttackingUpSpriteOriginX, GameConstants.PlayerAttackingUpSpriteOriginY);
    spriteDisplayTimeLapse = GameConstants.PlayerAttackingUpSpriteInitialDisplayTimeLapse;
    frameDisplayTimeMap = new()
    {
        { GameConstants.PlayerAttackingUpSpriteInitialFrame, GameConstants.PlayerAttackingUpSpriteInitialFrameDisplayTime },
        { GameConstants.PlayerAttackingUpSpriteNextFrame1, GameConstants.PlayerAttackingUpSpriteNextFrame1DisplayTime },
        { GameConstants.PlayerAttackingUpSpriteNextFrame2, GameConstants.PlayerAttackingUpSpriteNextFrameDisplayTime },
        { GameConstants.PlayerAttackingUpSpriteNextFrame3, GameConstants.PlayerAttackingUpSpriteNextFrameDisplayTime },
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

        protected override Rectangle GetDestinationRectangle(float x, float y)
        {
            Rectangle rectangle = base.GetDestinationRectangle(x, y);
            DestinationRectangle = new(rectangle.X, rectangle.Y, rectangle.Width, 16 * Constants.UniversalScale);
            return rectangle;
        }
    }
}
