namespace MainGame.SpriteHandlers
{
    public static partial class SpriteFactory
    {
        public static ISprite CreateStartScreenSprite()
        {
            return new StartScreenSprites.StartScreenSprite(
                TextureMap["StartScreenSpriteSheet"], SpriteBatch,
                numRows: 1,
                numColumns: 2,
                numberOfFrames: 2,
                frameHeight: 16,
                frameWidth: 16);
        }
    }
}
