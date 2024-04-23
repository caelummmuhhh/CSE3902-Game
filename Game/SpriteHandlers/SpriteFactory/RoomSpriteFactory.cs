using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MainGame.SpriteHandlers.ItemSprites;

namespace MainGame.SpriteHandlers
{
    public static partial class SpriteFactory
    {
        public static ISprite CreateUndergroundRoomSprite()
        {
            return new UndergroundRoomSprite(
                TextureMap["RoomSprites"], SpriteBatch,
                textureStartingY: 0,
                scale: Constants.UniversalScale
                );
        }
        public static ISprite CreateRoomOuterBorderSprite()
        {
            return new RoomOuterBorderSprite(
                TextureMap["RoomSprites"], SpriteBatch,
                textureStartingY: 176,
                layerDepth: DefaultSpriteLayerDepths.HudLayer - 0.1f,
                scale: Constants.UniversalScale
                );
        }
        public static ISprite CreateRoomInnerBorderSprite()
        {
            return new RoomInnerBorderSprite(
                TextureMap["RoomSprites"], SpriteBatch,
                textureStartingY: 352,
                layerDepth: DefaultSpriteLayerDepths.RoomBaseLayer,
                scale: Constants.UniversalScale
                );
        }
        public static ISprite CreateDungeonTilesSprite()
        {
            return new RoomDungeonTilesSprite(
                TextureMap["RoomSprites"], SpriteBatch,
                textureStartingY: 528,
                layerDepth: DefaultSpriteLayerDepths.RoomBaseLayer,
                scale: Constants.UniversalScale
                );
        }

        public static ISprite CreateEmptyRoomSprite()
        {
            return new EmptyRoomSprite(
                TextureMap["RoomSprites"], SpriteBatch,
                textureStartingY: 0,
                layerDepth: DefaultSpriteLayerDepths.RoomBaseLayer,
                scale: Constants.UniversalScale
                );
        }
    }
}
