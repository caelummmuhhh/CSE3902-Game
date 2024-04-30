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
                layerDepth: DefaultSpriteLayerDepths.MenuLayer,
                scale: Constants.UniversalScale
                );
        }
        public static ISprite CreateEmptyHudSprite()
        {
            return new EmptyHudSprite(
                TextureMap["HudAndMenuSprites"], SpriteBatch,
                textureStartingY: 184,
                layerDepth: DefaultSpriteLayerDepths.HudLayer,
                scale: Constants.UniversalScale
                );
        }
        public static ISprite CreateFullHeartDisplaySprite()
        {
            return new HeartDisplaySprite(
                TextureMap["HudAndMenuSprites"], SpriteBatch,
                textureStartingY: 240,
                layerDepth: DefaultSpriteLayerDepths.HudLayer + 0.01f,
                scale: Constants.UniversalScale
                );
        }
        public static ISprite CreateHalfHeartDisplaySprite()
        {
            return new HeartDisplaySprite(
                TextureMap["HudAndMenuSprites"], SpriteBatch,
                textureStartingY: 248,
                layerDepth: DefaultSpriteLayerDepths.HudLayer + 0.01f,
                scale: Constants.UniversalScale
                );
        }
        public static ISprite CreateEmptyHeartDisplaySprite()
        {
            return new HeartDisplaySprite(
                TextureMap["HudAndMenuSprites"], SpriteBatch,
                textureStartingY: 256,
                layerDepth: DefaultSpriteLayerDepths.HudLayer + 0.01f,
                scale: Constants.UniversalScale
                );
        }
        public static ISprite CreateMapLayoutPieceSprite()
        {
            return new MapLayoutPieceSprite(
                TextureMap["HudAndMenuSprites"], SpriteBatch,
                textureStartingY: 264,
                layerDepth: DefaultSpriteLayerDepths.HudLayer + 0.01f,
                scale: Constants.UniversalScale
                );
        }
        public static ISprite CreateMapPlayerTrackerSprite()
        {
            return new MapLayoutTrackerSprite(
                TextureMap["HudAndMenuSprites"], SpriteBatch,
                textureStartingY: 268,
                layerDepth: DefaultSpriteLayerDepths.HudLayer + 0.03f,
                scale: Constants.UniversalScale
                );
        }
        public static ISprite CreateMapTriforceTrackerSprite()
        {
            return new MapLayoutTrackerSprite(
                TextureMap["HudAndMenuSprites"], SpriteBatch,
                textureStartingY: 271,
                layerDepth: DefaultSpriteLayerDepths.HudLayer + 0.02f,
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
                layerDepth: DefaultSpriteLayerDepths.MenuLayer + 0.01f,
                scale: Constants.UniversalScale);
        }
    }
}
