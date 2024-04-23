using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Audio;

namespace MainGame.Doors
{
	public class EastDungeonDoor : BaseDoor
	{
        public EastDungeonDoor(Vector2 position, DoorTypes doorType)
			: base(position, doorType, Direction.East)
        {
            BottomXOffset = -16 * Constants.UniversalScale;
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
