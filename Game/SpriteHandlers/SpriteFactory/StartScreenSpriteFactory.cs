using System.Diagnostics;

namespace MainGame.SpriteHandlers
{
    public static partial class SpriteFactory
    {
        public static ISprite CreateStartScreenSprite()
        {
            return new StartScreenSprites.StartScreenSprite(
                TextureMap["StartScreenSprites"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                frameHeight: 200,
                frameWidth: 256);
        }

        public static ISprite CreateStartScreenTextSprite(int pageNumber)
        {
            int StartingX = 1;
            int StartingY = 250;
            if (pageNumber > 4) { StartingY = 475; }
            if(pageNumber == 2 ||  pageNumber == 6) { StartingX = 257; }
            if (pageNumber == 3 || pageNumber == 7) { StartingX = 257+256; }
            if (pageNumber == 4 || pageNumber == 8) { StartingX = 257+256+256; }

            return new StartScreenSprites.TextPageSprite(
                TextureMap["StartScreenSprites"], SpriteBatch,
                textureStartingX: StartingX,
                textureStartingY: StartingY,
                scale: Constants.UniversalScale
                );
        }
    }
}
