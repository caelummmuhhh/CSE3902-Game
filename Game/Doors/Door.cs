using MainGame.SpriteHandlers;
using Microsoft.Xna.Framework;
using System;

namespace MainGame.Doors
{
    public class Door : IDoor
    {
        public Vector2 Position;
        public Direction Direction;
        private readonly ISprite spriteTop;
        private readonly ISprite spriteBottom;
        private readonly int BottomXOffset = GameConstants.InitialOffsetX;
        private readonly int BottomYOffset = GameConstants.InitialOffsetY;
        public Door(Vector2 position, ISprite spriteTop, ISprite spriteBottom, Direction direction)
        {
            Position = position;
            this.spriteTop = spriteTop;
            this.spriteBottom = spriteBottom;
            Direction = direction;

            this.spriteTop.LayerDepth = GameConstants.TopSpriteLayerDepth;
            this.spriteBottom.LayerDepth = GameConstants.BottomSpriteLayerDepth;

            if (Direction == Direction.North)
            {
                BottomYOffset = GameConstants.DoorOffsetFactor * Constants.UniversalScale;
            }
            else if (Direction == Direction.South)
            {
                BottomYOffset = -GameConstants.DoorOffsetFactor * Constants.UniversalScale;
            }
            else if (Direction == Direction.West)
            {
                BottomXOffset = GameConstants.DoorOffsetFactor * Constants.UniversalScale;
            }
            else if (Direction == Direction.East)
            {
                BottomXOffset = -GameConstants.DoorOffsetFactor * Constants.UniversalScale;
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
        // Nothing to do for a blank door
        public void Draw() { }
        public void Update() { }
    }
}