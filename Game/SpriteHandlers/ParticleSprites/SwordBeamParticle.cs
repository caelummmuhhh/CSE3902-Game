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
                int textureStartingX = GameConstants.SwordBeamParticleDefaultTextureStartingX,
    int textureStartingY = GameConstants.SwordBeamParticleDefaultTextureStartingY,
    int scale = GameConstants.SwordBeamParticleDefaultScale,
    float layerDepth = GameConstants.SwordBeamParticleDefaultLayerDepth)
    : base(texture, numRows, numColumns, frameWidth, frameHeight, numberOfFrames,
          textureStartingX, textureStartingY, scale, layerDepth)
        {
            this.spriteBatch = spriteBatch;
            spriteDisplayTimeLapse = GameConstants.SwordBeamParticleInitialDisplayTimeLapse;
            frameDisplayTimeMap = new()
    {
        { GameConstants.SwordBeamParticleInitialFrame, GameConstants.SwordBeamParticleFrameDisplayTime },
        { GameConstants.SwordBeamParticleNextFrame1, GameConstants.SwordBeamParticleFrameDisplayTime },
        { GameConstants.SwordBeamParticleNextFrame2, GameConstants.SwordBeamParticleFrameDisplayTime },
        { GameConstants.SwordBeamParticleNextFrame3, GameConstants.SwordBeamParticleFrameDisplayTime },
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
