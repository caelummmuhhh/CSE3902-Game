using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers
{
    public abstract class AnimatedSprite : ISprite
    {
        public readonly Texture2D Texture;
        public readonly int RowCount;
        public readonly int ColumnCount;
        public readonly int Scale;
        public readonly int SpriteFrameWidth;
        public readonly int SpriteFrameHeight;


        protected int totalFrameCount;
        protected int currentFrame;

        protected AnimatedSprite(Texture2D texture, int numRows, int numColumns, int scale = 1)
        {
            Texture = texture;
            RowCount = numRows;
            ColumnCount = numColumns;
            Scale = scale;

            SpriteFrameWidth = Texture.Width / ColumnCount;
            SpriteFrameHeight = Texture.Height / RowCount;

            totalFrameCount = numColumns * numRows;
            currentFrame = 0;
        }

        public abstract void Update();

        public abstract void Draw(float x, float y, Color color);

        public virtual Rectangle GetSourceRectangle()
        {
            int currRow = currentFrame / ColumnCount;
            int currColumn = currentFrame % ColumnCount;

            return new Rectangle(
                SpriteFrameWidth * currColumn,
                SpriteFrameHeight * currRow,
                SpriteFrameWidth, SpriteFrameHeight);
        }

        public virtual void GetNextFrame()
        {

            currentFrame++;
            
            if (currentFrame >= totalFrameCount)
            {
                currentFrame = 0;
            }
        }
    }
}
