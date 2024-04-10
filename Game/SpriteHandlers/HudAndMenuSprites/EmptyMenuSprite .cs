﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MainGame.SpriteHandlers.HudAndMenuSprites
{
    internal class EmptyMenuSprite : StaticSpriteWithOffset
    {
        private readonly SpriteBatch spriteBatch;

        public EmptyMenuSprite(
            Texture2D texture,
            SpriteBatch spriteBatch,
            int spriteHeight = 176,
            int spriteWidth = 256,
            int textureStartingX = 0,
            int textureStartingY = 0,
            int scale = 1,
            float layerDepth = 1.0f)
            : base(texture, spriteHeight, spriteWidth, textureStartingX, textureStartingY, scale, layerDepth)
        {
            this.spriteBatch = spriteBatch;
            origin = new Vector2(0, 0);
            rotation = 0f;
        }

        public override void Update() { /* not needed here */ }

        public override void Draw(float x, float y, Color color)
        {
            Rectangle srcRectangle = GetSourceRectangle();
            Rectangle destRectangle = new(
                (int)x,
                (int)y,
                FrameWidth * scale,
                FrameHeight * scale);

            spriteBatch.Draw(Texture, destRectangle, srcRectangle, color, rotation, origin, SpriteEffects.None, layer);
        }
    }
}
