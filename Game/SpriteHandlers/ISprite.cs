using Microsoft.Xna.Framework;

namespace MainGame.SpriteHandlers
{
    public interface ISprite
    {
        public Rectangle DestinationRectangle { get; set; }
        public float LayerDepth { get; set; }

        void Update();
        void Draw(float x, float y, Color color);
    }
}
