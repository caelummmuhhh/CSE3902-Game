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
                scale: Constants.UniversalScale
                );
        }
        public static ISprite CreateEmptyHudSprite()
        {
            return new EmptyHudSprite(
                TextureMap["HudAndMenuSprites"], SpriteBatch,
                textureStartingY: 184,
                scale: Constants.UniversalScale
                );
        }
        public static ISprite CreateFullHeartDisplaySprite()
        {
            return new HeartDisplaySprite(
                TextureMap["HudAndMenuSprites"], SpriteBatch,
                textureStartingY: 240,
                scale: Constants.UniversalScale
                );
        }
        public static ISprite CreateHalfHeartDisplaySprite()
        {
            return new HeartDisplaySprite(
                TextureMap["HudAndMenuSprites"], SpriteBatch,
                textureStartingY: 248,
                scale: Constants.UniversalScale
                );
        }
        public static ISprite CreateEmptyHeartDisplaySprite()
        {
            return new HeartDisplaySprite(
                TextureMap["HudAndMenuSprites"], SpriteBatch,
                textureStartingY: 256,
                scale: Constants.UniversalScale
                );
        }
        public static ISprite CreateSelectingBoxSprite()
        {
            return new SelectingBoxSprite(
                TextureMap["HudAndMenuSprites"], SpriteBatch,
                textureStartingY: 277,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                scale: Constants.UniversalScale);
        }
    }
}
