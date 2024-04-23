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
        public override int AnimationFrameDuration
        {
            get
            {
                int totalDisplayTime = 0;
                foreach (int displayTime in frameDisplayTimeMap.Values)
                {
                    totalDisplayTime += displayTime;
                }
                return totalDisplayTime;
            }
        }

        private readonly Dictionary<int, int> frameDisplayTimeMap;
        private readonly SpriteBatch spriteBatch;
        private int spriteDisplayTimeLapse;
        //real values not present yet just framework atm
        public DeathParticle(Texture2D texture,
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
            spriteDisplayTimeLapse = 0;
            frameDisplayTimeMap = new()
            {
                { 0, 6 },
                { 1, 6 },
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
