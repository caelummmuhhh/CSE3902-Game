using Microsoft.Xna.Framework;

namespace MainGame.SpriteHandlers
{
    public interface ISprite
    {
        public float LayerDepth { get; set; }
        void Update();
        void Draw(float x, float y, Color color);
    }
}
