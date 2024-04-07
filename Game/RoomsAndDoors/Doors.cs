using MainGame.SpriteHandlers;
using Microsoft.Xna.Framework;
using System;

namespace MainGame.Doors
{
    public interface IDoor
    {
        public void Update();
        public void Draw();
    }

    public class Door : IDoor
    {
        public ISprite SpriteTop;
        public ISprite SpriteBottom;
        public Vector2 Position;
        public Direction Direction;
        public int BottomXOffset = 0;
        public int BottomYOffset = 0;

        public Door(Vector2 position, ISprite spriteTop, ISprite spriteBottom, string direction)
        {
            Position = position;
            SpriteTop = spriteTop;
            SpriteBottom = spriteBottom;
            Direction = (Direction)Enum.Parse(typeof(Direction), direction);

            SpriteTop.LayerDepth = 0f;
            SpriteBottom.LayerDepth = 1.0f;

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
            SpriteTop.Update();
            SpriteBottom.Update();

        }

        public void Draw()
        {
            SpriteTop.Draw(Position.X, Position.Y, Color.White);
            SpriteBottom.Draw(Position.X + BottomXOffset, Position.Y + BottomYOffset, Color.White);
        }
    }

    public class BlankDoor : IDoor
    {
        // Nothing to do for a blank door
        public void Draw() { }
        public void Update() { }
    }
}