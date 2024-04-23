using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Doors
{
    public class WestDungeonDoor : BaseDoor
    {
        public WestDungeonDoor(Vector2 position, DoorTypes doorType)
            : base(position, doorType, Direction.West)
        {
            BottomXOffset = 16 * Constants.UniversalScale;
            SpriteTop = SpriteFactory.CreateDoorTopWestEast(Direction, DoorType);
            SpriteBottom = SpriteFactory.CreateDoorBottomWestEast(Direction, DoorType);
        }

        public override void Unlock()
        {
            if (!IsLocked) return;
            DoorType = DoorUtils.GetOpenedDoorVariant(DoorType);
            SpriteTop = SpriteFactory.CreateDoorTopWestEast(Direction, DoorType);
            SpriteBottom = SpriteFactory.CreateDoorBottomWestEast(Direction, DoorType);
        }
    }
}
