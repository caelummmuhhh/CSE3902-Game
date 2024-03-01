using Microsoft.Xna.Framework;


namespace MainGame.SpriteHandlers
{
    public interface ISprite
    {
        void Update();
        void Draw(float x, float y, Color color, float layerDepth = 0f);
    }
}

