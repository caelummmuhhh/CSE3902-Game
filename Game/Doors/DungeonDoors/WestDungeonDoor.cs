using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Audio;

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
            AudioManager.PlaySFX("Door_Unlock", 0);
            DoorType = DoorUtils.GetOpenedDoorVariant(DoorType);
            SpriteTop = SpriteFactory.CreateDoorTopWestEast(Direction, DoorType);
            SpriteBottom = SpriteFactory.CreateDoorBottomWestEast(Direction, DoorType);
        }
    }
}
