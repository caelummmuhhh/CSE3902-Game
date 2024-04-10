using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGame.SpriteHandlers.ParticleSprites
{
    
    public class DeathParticle : AnimatedSpriteWithOffset
    {
        private readonly Dictionary<int, int> frameDisplayTimeMap;
        private readonly SpriteBatch spriteBatch;
        private int spriteDisplayTimeLapse;
        //real values not present yet just framework atm
        public DeathParticle(Texture2D texture,
            SpriteBatch spriteBatch,
            int numRows,
            int numColumns,
            int numberOfFrames,
    int frameHeight = GameConstants.DeathParticleDefaultFrameHeight,
    int frameWidth = GameConstants.DeathParticleDefaultFrameWidth,
    int textureStartingX = GameConstants.DeathParticleDefaultTextureStartingX,
    int textureStartingY = GameConstants.DeathParticleDefaultTextureStartingY,
    int scale = GameConstants.DeathParticleDefaultScale,
    float layerDepth = GameConstants.DeathParticleDefaultLayerDepth)
    : base(texture, numRows, numColumns, frameWidth, frameHeight, numberOfFrames,
          textureStartingX, textureStartingY, scale, layerDepth)
{
    this.spriteBatch = spriteBatch;
    spriteDisplayTimeLapse = GameConstants.DeathParticleInitialDisplayTimeLapse;
    frameDisplayTimeMap = new()
    {
        { GameConstants.DeathParticleInitialFrame, GameConstants.DeathParticleFrameDisplayTime },
        { GameConstants.DeathParticleNextFrame, GameConstants.DeathParticleFrameDisplayTime },
    };
}
        public override void Draw(float x, float y, Color color)
        {
            Rectangle srcRectangle = GetSourceRectangle();
            Rectangle destRectangle = GetDestinationRectangle(x, y);

            spriteBatch.Draw(Texture, destRectangle, srcRectangle, color, rotation, origin, SpriteEffects.None, layer);
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
    }
    
}
