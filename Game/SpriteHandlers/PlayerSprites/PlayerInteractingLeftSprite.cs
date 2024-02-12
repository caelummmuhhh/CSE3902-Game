﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers.PlayerSprites
{
    public class PlayerInteractingLeftSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public PlayerInteractingLeftSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int spriteHeight,
            int spriteWidth,
            int textureStartingX = 0,
            int textureStartingY = 0,
            int scale = 1) : base(texture, spriteHeight, spriteWidth,
                                  textureStartingX, textureStartingY, scale)
        {
            this.spriteBatch = spriteBatch;
        }

        public override void Update() { /* not needed here */ }

        public override void Draw(float x, float y, Color color)
        {
            Rectangle srcRectangle = GetSourceRectangle();
            Rectangle destRectangle = new Rectangle(
                (int)(x - (FrameHeight * Scale) / 2),
                (int)(y - (FrameWidth * Scale) / 2),
                FrameWidth * Scale,
                FrameHeight * Scale);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
            spriteBatch.Draw(Texture,
                destRectangle,
                srcRectangle,
                color,
                0f,
                new Vector2(0, 0),
                SpriteEffects.FlipHorizontally,
                0f);
            spriteBatch.End();
        }
    }
}

