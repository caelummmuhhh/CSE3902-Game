using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame.SpriteHandlers
{
    public abstract class AnimatedSprite : ISprite
    {
        public readonly Texture2D Texture;
        public readonly int RowCount;
        public readonly int ColumnCount;

        public virtual int AnimationFrameDuration { get => totalFrameCount; }
        public virtual int FrameWidth { get => frameWidth; }
        public virtual int FrameHeight { get => frameHeight; }
        public virtual int Scale { get => scale; }
        public float LayerDepth
        {
            get => layer;
            set
            {
                // Protect setter; SpriteBatch.Draw only allows [0, 1]f values
                if (value < 0.0f || value > 1.0f)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "Value must be between 0 and 1, inclusive.");
                }
                layer = value;
            }
        }

        protected int totalFrameCount;
        protected int currentFrame;
        protected int frameWidth;
        protected int frameHeight;
        protected int scale;
        protected float layer;

        protected AnimatedSprite(Texture2D texture, int numRows, int numColumns, int scale = 1)
        {
            Texture = texture;
            RowCount = numRows;
            ColumnCount = numColumns;
            this.scale = scale;

            frameWidth = Texture.Width / ColumnCount;
            frameHeight = Texture.Height / RowCount;

            totalFrameCount = numColumns * numRows;
            currentFrame = 0;
        }

        public abstract void Update();

        public abstract void Draw(float x, float y, Color color);

        protected virtual Rectangle GetSourceRectangle()
        {
            int currRow = currentFrame / ColumnCount;
            int currColumn = currentFrame % ColumnCount;

            return new Rectangle(
                frameWidth * currColumn,
                frameHeight * currRow,
                frameWidth, frameHeight);
        }

        protected virtual void GetNextFrame()
        {
            currentFrame++;
            
            if (currentFrame >= totalFrameCount)
            {
                currentFrame = 0;
            }
        }
    }
}
