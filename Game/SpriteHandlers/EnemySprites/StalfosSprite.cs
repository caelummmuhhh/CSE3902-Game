using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.EnemySprites
{
    public class StalfosSprite : AnimatedSpriteWithOffset
    {
        /// <summary>
        /// The key is the current animationframe (starting at 0).
        /// The value is how many game seconds the frame should be displayed.
        /// </summary>
        private readonly Dictionary<int, int> frameDisplayTimeMap;
        private readonly SpriteBatch spriteBatch;
        private int spriteDisplayTimeLapse;
        private bool spriteFlip;
        public override int AnimationFrameDuration => frameDisplayTimeMap.Count;

        public StalfosSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int numRows,
            int numColumns,
            int numberOfFrames,
    int frameHeight = GameConstants.StalfosSpriteDefaultFrameHeight,
    int frameWidth = GameConstants.StalfosSpriteDefaultFrameWidth,
    int textureStartingX = GameConstants.StalfosSpriteDefaultTextureStartingX,
    int textureStartingY = GameConstants.StalfosSpriteDefaultTextureStartingY,
    int scale = GameConstants.StalfosSpriteDefaultScale,
    float layerDepth = GameConstants.StalfosSpriteDefaultLayerDepth)
    : base(texture, numRows, numColumns, frameWidth, frameHeight, numberOfFrames,
          textureStartingX, textureStartingY, scale, layerDepth)
{
    this.spriteBatch = spriteBatch;
    spriteDisplayTimeLapse = GameConstants.StalfosSpriteInitialDisplayTimeLapse;
    spriteFlip = GameConstants.StalfosSpriteInitialFlipState;
    frameDisplayTimeMap = new()
    {
        { GameConstants.StalfosSpriteInitialFrame, GameConstants.StalfosSpriteFrameDisplayTime },
        { GameConstants.StalfosSpriteNextFrame, GameConstants.StalfosSpriteFrameDisplayTime },
    };
}
        public override void Update()
        {
            if (spriteDisplayTimeLapse != frameDisplayTimeMap[currentFrame])
            {
                spriteDisplayTimeLapse++;
                return;
            }
            spriteFlip = !spriteFlip;
            spriteDisplayTimeLapse = 0;
        }

        public override void Draw(float x, float y, Color color)
        {
            SpriteEffects spriteEffect = spriteFlip ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            Rectangle srcRectangle = GetSourceRectangle();
            Rectangle destRectangle = GetDestinationRectangle(x, y);

            spriteBatch.Draw(Texture, destRectangle, srcRectangle, color, rotation, origin, spriteEffect, layer);
        }
    }
}
