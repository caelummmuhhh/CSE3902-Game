using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.ParticleSprites
{
    public class SwordBeamParticle : AnimatedSpriteWithOffset
    {
        private readonly Dictionary<int, int> frameDisplayTimeMap;
        private readonly SpriteBatch spriteBatch;
        private int spriteDisplayTimeLapse;
        private readonly SpriteEffects effects;

        public SwordBeamParticle(Texture2D texture,
            SpriteBatch spriteBatch,
            int numRows,
            int numColumns,
            int numberOfFrames,
            int frameHeight,
            int frameWidth,
            Direction facingDirection,
            int textureStartingX = 0,
            int textureStartingY = 0,
            int scale = 1,
            float layerDepth = 0.5f)
            : base(texture, numRows, numColumns, frameWidth, frameHeight, numberOfFrames,
                  textureStartingX, textureStartingY, scale, layerDepth)
        {
            this.spriteBatch = spriteBatch;
            spriteDisplayTimeLapse = 0;
            frameDisplayTimeMap = new()
            {
                { 0, 1 },
                { 1, 1 },
                { 2, 1 },
                { 3, 1 }
            };

            origin = new(FrameWidth / 2f, FrameHeight / 2f);
            effects = facingDirection switch
            {
                Direction.NorthWest => SpriteEffects.None,
                Direction.NorthEast => SpriteEffects.FlipHorizontally,
                Direction.SouthEast => SpriteEffects.FlipVertically | SpriteEffects.FlipHorizontally,
                Direction.SouthWest => SpriteEffects.FlipVertically,
                _ => SpriteEffects.None
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

            spriteBatch.Draw(Texture, destRectangle, srcRectangle, color, rotation, origin, effects, layer);
        }
    }
}
