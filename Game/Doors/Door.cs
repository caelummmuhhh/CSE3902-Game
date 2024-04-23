using MainGame.SpriteHandlers;
using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

namespace MainGame.Doors
{
    public class Door : IDoor
    {
        public Direction Direction { get; set; }
        public ISprite spriteTop;
        public ISprite spriteBottom;
        private readonly int BottomXOffset = 0;
        private readonly int BottomYOffset = 0;

        public DoorTypes DoorType { get; set; }

        public Vector2 Position { get; set; }

        public Rectangle HitBox{
            get { 
                Rectangle r = new Rectangle((int)Position.X + BottomXOffset, (int) Position.Y + BottomYOffset, 
                    spriteTop.DestinationRectangle.Width, spriteTop.DestinationRectangle.Height);

                return r; 
            }
        }


        public Door(Door door)
        {
            Position = door.Position;
            this.spriteTop = door.spriteTop;
            this.spriteBottom = door.spriteBottom;
            Direction = door.Direction;

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

        public void Unlock()
        {
            DoorTypes doorType = SpriteFactory.DoorTypeFromString("OpenDoor");
            this.DoorType = doorType;
            if(Direction == Direction.North) 
            {
                spriteTop = SpriteFactory.CreateDoorTopNorthSouth(Direction.North, doorType);
                spriteBottom = SpriteFactory.CreateDoorBottomNorthSouth(Direction.North, doorType);
            }else if(Direction == Direction.South)
            {
                spriteTop = SpriteFactory.CreateDoorTopNorthSouth(Direction.South, doorType);
                spriteBottom = SpriteFactory.CreateDoorBottomNorthSouth(Direction.South, doorType);
            }
            else if (Direction == Direction.East)
            {
                spriteTop = SpriteFactory.CreateDoorBottomWestEast(Direction.East, doorType);
                spriteBottom = SpriteFactory.CreateDoorBottomWestEast(Direction.East, doorType);
            }
            else if (Direction == Direction.West)
            {
                spriteTop = SpriteFactory.CreateDoorBottomWestEast(Direction.West, doorType);
                spriteBottom = SpriteFactory.CreateDoorBottomWestEast(Direction.West, doorType);
            }
        }
    }

    public class BlankDoor : IDoor
    {
        public Direction Direction { get; set; }
        public Rectangle HitBox { get; set; }
        public bool IsOpen { get { return false; } set { } }
        public DoorTypes DoorType { get; set; }
        public Vector2 Position { get; set; }
        // Nothing to do for a blank door
        public void Draw() { }

        public void Unlock(){ }

        public void Update() { }
    }
}