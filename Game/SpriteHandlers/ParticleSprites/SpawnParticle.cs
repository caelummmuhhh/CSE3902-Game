using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MainGame.SpriteHandlers.ParticleSprites
{
    public class SpawnParticle : AnimatedSpriteWithOffset
    {

        private readonly Dictionary<int, int> frameDisplayTimeMap;
        private readonly SpriteBatch spriteBatch;
        private int spriteDisplayTimeLapse;

        public SpawnParticle(Texture2D texture,
            SpriteBatch spriteBatch,
            int numRows,
            int numColumns,
            int numberOfFrames,
            int frameHeight,
            int frameWidth,
    int textureStartingX = GameConstants.SpawnParticleDefaultTextureStartingX,
    int textureStartingY = GameConstants.SpawnParticleDefaultTextureStartingY,
    int scale = GameConstants.SpawnParticleDefaultScale,
    float layerDepth = GameConstants.SpawnParticleDefaultLayerDepth)
    : base(texture, numRows, numColumns, frameWidth, frameHeight, numberOfFrames,
          textureStartingX, textureStartingY, scale, layerDepth)
{
    this.spriteBatch = spriteBatch;
    spriteDisplayTimeLapse = GameConstants.SpawnParticleInitialDisplayTimeLapse;
    frameDisplayTimeMap = new()
    {
        { GameConstants.SpawnParticleInitialFrame, GameConstants.SpawnParticleInitialFrameDisplayTime },
        { GameConstants.SpawnParticleNextFrame1, GameConstants.SpawnParticleNextFrameDisplayTime },
        { GameConstants.SpawnParticleNextFrame2, GameConstants.SpawnParticleNextFrameDisplayTime },
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
