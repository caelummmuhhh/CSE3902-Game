using System;
using MainGame.SpriteHandlers;
using Microsoft.Xna.Framework;

namespace MainGame.Doors
{
    public abstract class BaseDoor : IDoor
    {
        public virtual Vector2 Position { get; set; }
        public virtual Direction Direction { get; protected set; }
        public virtual DoorTypes DoorType { get; protected set; }
        public bool IsLocked => DoorUtils.IsLockedDoorType(DoorType);
        public virtual Rectangle HitBox => IsLocked ? LockedHitBox : UnlockedHitbox;

        protected virtual ISprite SpriteTop { get; set; }
        protected virtual ISprite SpriteBottom { get; set; }
        protected int BottomXOffset = 0;
        protected int BottomYOffset = 0;

        protected virtual Rectangle LockedHitBox
        {
            get
            {
                Point pos = Position.ToPoint();
                pos.X += BottomXOffset;
                pos.Y += BottomYOffset;
                return new(pos, SpriteBottom.DestinationRectangle.Size);
            }
        }

        protected virtual Rectangle UnlockedHitbox
        {
            get
            {
                Point pos = Position.ToPoint();
                pos.X -= BottomXOffset + Math.Sign(BottomXOffset) * Constants.UniversalScale * 3;
                pos.Y -= BottomYOffset + Math.Sign(BottomXOffset) * Constants.UniversalScale * 3;
                return new(pos, SpriteTop.DestinationRectangle.Size);
            }
        }

        public BaseDoor(Vector2 position, DoorTypes doorType, Direction direction)
        {
            Position = position;
            Direction = direction;
            DoorType = doorType;
        }

        public virtual void Update()
        {
            SpriteTop.Update();
            SpriteBottom.Update();
        }

        public virtual void Draw()
        {
            SpriteTop.LayerDepth = 1.0f;
            SpriteBottom.LayerDepth = 0f;
            SpriteTop.Draw(Position.X, Position.Y, Color.White);
            SpriteBottom.Draw(Position.X + BottomXOffset, Position.Y + BottomYOffset, Color.White);
        }

        public abstract void Unlock();
    }
}