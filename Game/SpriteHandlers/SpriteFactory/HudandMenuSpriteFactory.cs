using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MainGame.SpriteHandlers.ItemSprites;
using MainGame.SpriteHandlers.HudAndMenuSprites;

namespace MainGame.SpriteHandlers
{
    public static partial class SpriteFactory
    {
        public static ISprite CreateEmptyMenuSprite()
        {
            return new EmptyMenuSprite(
                TextureMap["HudAndMenuSprites"], SpriteBatch,
                textureStartingY: 0,
                scale: 3
                );
        }
        public static ISprite CreateEmptyHudSprite()
        {
            return new EmptyHudSprite(
                TextureMap["HudAndMenuSprites"], SpriteBatch,
                textureStartingY: 184,
                scale: 3
                );
        }
        public static ISprite CreateFullHeartDisplaySprite()
        {
            return new HeartDisplaySprite(
                TextureMap["HudAndMenuSprites"], SpriteBatch,
                textureStartingY: 240,
                scale: 3
                );
        }
        public static ISprite CreateHalfHeartDisplaySprite()
        {
            return new HeartDisplaySprite(
                TextureMap["HudAndMenuSprites"], SpriteBatch,
                textureStartingY: 248,
                scale: 3
                );
        }
        public static ISprite CreateEmptyHeartDisplaySprite()
        {
            return new HeartDisplaySprite(
                TextureMap["HudAndMenuSprites"], SpriteBatch,
                textureStartingY: 256,
                scale: 3
                );
        }
    }
}
