using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainGame.SpriteHandlers.StartScreenSprites
{
    public class StartScreenSprite : AnimatedSpriteWithOffset
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

        public StartScreenSprite(Texture2D texture,
            SpriteBatch spriteBatch,
            int numRows,
            int numColumns,
            int numberOfFrames,
            int frameHeight,
            int frameWidth,
            int textureStartingX = 1,
            int textureStartingY = 11,
            int scale = 1,
            float layerDepth = 0.5f)
            : base(texture, numRows, numColumns, frameWidth, frameHeight, numberOfFrames,
                  textureStartingX, textureStartingY, scale, layerDepth)
        {
            this.spriteBatch = spriteBatch;
            spriteDisplayTimeLapse = 0;
            frameDisplayTimeMap = new()
            {
                { 0, 10 },
                { 1, 10 },
            };
        }

        public override void Draw(float x, float y, Color color)
        {
            Rectangle srcRectangle = GetSourceRectangle();

            spriteBatch.Draw(Texture, new Rectangle((int)x, (int)y, (int)Constants.ScreenSize.X, (int)Constants.ScreenSize.Y), 
                srcRectangle, color, rotation, origin, SpriteEffects.None, layer);
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
