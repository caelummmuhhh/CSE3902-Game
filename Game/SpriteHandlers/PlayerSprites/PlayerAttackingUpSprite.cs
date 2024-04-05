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
            int frameHeight = 16,
            int frameWidth = 16,
            int textureStartingX = 0,
            int textureStartingY = 0,
            int scale = 1,
            float layerDepth = 0.5f)
            : base(texture, numRows, numColumns, frameWidth, frameHeight, numberOfFrames,
                  textureStartingX, textureStartingY, scale, layerDepth)
        {
            this.spriteBatch = spriteBatch;
            origin = new(0f, 11f);
            spriteDisplayTimeLapse = 0;
            frameDisplayTimeMap = new()
            {
                { 0, 4 },
                { 1, 8 },
                { 2, 1 },
                { 3, 1 }
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
