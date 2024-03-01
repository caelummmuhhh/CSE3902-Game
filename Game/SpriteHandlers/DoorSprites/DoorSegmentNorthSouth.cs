﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.ItemSprites
{
    public class DoorSegmentNorthSouth : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public DoorSegmentNorthSouth(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int spriteHeight = 16,
            int spriteWidth = 32,
            int textureStartingX = 0,
            int textureStartingY = 0,
            int scale = 1) : base(texture, spriteHeight, spriteWidth,
                                  textureStartingX, textureStartingY, scale)
        {
            this.spriteBatch = spriteBatch;
        }

        public override void Update() { /* not needed here */ }

        public override void Draw(float x, float y, Color color, float layerDepth)
        {
            Rectangle srcRectangle = GetSourceRectangle();
            Rectangle destRectangle = new Rectangle(
                (int)x,
                (int)y,
                FrameWidth * Scale,
                FrameHeight * Scale);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
            spriteBatch.Draw(Texture, destRectangle, srcRectangle, color, 0.0f, new Vector2(0, 0), SpriteEffects.None, layerDepth);
            spriteBatch.End();
        }
    }
}