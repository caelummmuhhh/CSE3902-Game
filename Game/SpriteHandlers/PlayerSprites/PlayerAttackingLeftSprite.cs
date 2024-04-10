using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.PlayerSprites
{
    public class PlayerAttackingLeftSprite : AnimatedSpriteWithOffset
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

        public PlayerAttackingLeftSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int numRows,
            int numColumns,
            int numberOfFrames,
    int frameHeight = GameConstants.PlayerAttackingLeftSpriteDefaultFrameHeight,
    int frameWidth = GameConstants.PlayerAttackingLeftSpriteDefaultFrameWidth,
    int textureStartingX = GameConstants.PlayerAttackingLeftSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.PlayerAttackingLeftSpriteDefaultTextureStartingY,
    int scale = GameConstants.PlayerAttackingLeftSpriteDefaultScale,
    float layerDepth = GameConstants.PlayerAttackingLeftSpriteDefaultLayerDepth)
    : base(texture, numRows, numColumns, frameWidth, frameHeight, numberOfFrames,
          textureStartingX, textureStartingY, scale, layerDepth)
{
    this.spriteBatch = spriteBatch;
    origin = new(GameConstants.PlayerAttackingLeftSpriteOriginX, GameConstants.PlayerAttackingLeftSpriteOriginY);
    spriteDisplayTimeLapse = GameConstants.PlayerAttackingLeftSpriteInitialDisplayTimeLapse;
    frameDisplayTimeMap = new()
    {
        { GameConstants.PlayerAttackingLeftSpriteInitialFrame, GameConstants.PlayerAttackingLeftSpriteInitialFrameDisplayTime },
        { GameConstants.PlayerAttackingLeftSpriteNextFrame1, GameConstants.PlayerAttackingLeftSpriteNextFrame1DisplayTime },
        { GameConstants.PlayerAttackingLeftSpriteNextFrame2, GameConstants.PlayerAttackingLeftSpriteNextFrameDisplayTime },
        { GameConstants.PlayerAttackingLeftSpriteNextFrame3, GameConstants.PlayerAttackingLeftSpriteNextFrameDisplayTime },
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

            spriteBatch.Draw(Texture, destRectangle, srcRectangle, color, rotation, origin, SpriteEffects.FlipHorizontally, layer);
        }

        protected override Rectangle GetDestinationRectangle(float x, float y)
        {
            Rectangle rectangle = base.GetDestinationRectangle(x, y);
            DestinationRectangle = new(rectangle.X, rectangle.Y, 16 * Constants.UniversalScale, rectangle.Height);
            return rectangle;
        }
    }
}
