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
    }
}
