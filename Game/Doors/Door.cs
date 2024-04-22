using MainGame.SpriteHandlers;
using Microsoft.Xna.Framework;
using System;

namespace MainGame.Doors
{
    public class Door : IDoor
    {
        public Direction Direction;
        private readonly ISprite spriteTop;
        private readonly ISprite spriteBottom;
        private readonly int BottomXOffset = 0;
        private readonly int BottomYOffset = 0;

        public Vector2 Position { get; set; }

        public Rectangle HitBox{
            get { 
                Rectangle r = new Rectangle((int)Position.X + BottomXOffset, (int) Position.Y + BottomYOffset, 
                    spriteBottom.DestinationRectangle.Width, spriteBottom.DestinationRectangle.Height);

                return r; 
            }
        }
        
        public bool IsOpen { get; set; }

        public Door(Vector2 position, ISprite spriteTop, ISprite spriteBottom, Direction direction)
        {
            Position = position;
            this.spriteTop = spriteTop;
            this.spriteBottom = spriteBottom;
            Direction = direction;

            this.spriteTop.LayerDepth = 0f;
            this.spriteBottom.LayerDepth = 1.0f;

            if (Direction == Direction.North)
            {
                BottomYOffset = 16 * Constants.UniversalScale;
            }
            else if (Direction == Direction.South)
            {
                BottomYOffset = -16 * Constants.UniversalScale;
            }
            else if (Direction == Direction.West)
            {
                BottomXOffset = 16 * Constants.UniversalScale;
            }
            else if (Direction == Direction.East)
            {
                BottomXOffset = -16 * Constants.UniversalScale;
            }
        }

        public void Update()
        {
            spriteTop.Update();
            spriteBottom.Update();
        }

        public void Draw()
        {
            spriteTop.Draw(Position.X, Position.Y, Color.White);
            spriteBottom.Draw(Position.X + BottomXOffset, Position.Y + BottomYOffset, Color.White);
        }
    }

    public class BlankDoor : IDoor
    {
        public Rectangle HitBox { get; set; }
        public bool IsOpen { get; set; }
        public Vector2 Position { get; set; }
        // Nothing to do for a blank door
        public void Draw() { }
        public void Update() { }
    }
}