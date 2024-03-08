using MainGame.SpriteHandlers;
using Microsoft.Xna.Framework;
using System;

namespace MainGame.Doors
{
    public class Door
    {
        public ISprite SpriteTop;
        public ISprite SpriteBottom;
        public Vector2 Position;
        public CardinalDirections Direction;
        public int BottomXOffset = 0;
        public int BottomYOffset = 0;
        public Rectangle HitBox { get => SpriteTop.DestinationRectangle; }

        public Door(Vector2 position, ISprite spriteTop, ISprite spriteBottom, String direction)
        {
            Position = position;
            SpriteTop = spriteTop;
            SpriteBottom = spriteBottom;                                                                                                                              
            Direction = (CardinalDirections)Enum.Parse(typeof(CardinalDirections), direction);

            SpriteTop.LayerDepth = 0f;
            SpriteBottom.LayerDepth = 1.0f;

            if (Direction == CardinalDirections.North)
            {
                BottomYOffset = 48;
            }
            else if (Direction == CardinalDirections.South)
            {
                BottomYOffset = -48;
            }
            else if (Direction == CardinalDirections.West)
            {
                BottomXOffset = 48;
            }
            else if (Direction == CardinalDirections.East)
            {
                BottomXOffset = -48;
            }
        }

        public void Update()
        {
            SpriteTop.Update();
            SpriteBottom.Update();

        }

        public void Draw()
        {
            SpriteTop.Draw(Position.X, Position.Y, Color.White);
            SpriteBottom.Draw(Position.X + BottomXOffset, Position.Y + BottomYOffset, Color.White);
        }
    }
}
