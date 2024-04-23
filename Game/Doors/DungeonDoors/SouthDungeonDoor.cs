using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Audio;

namespace MainGame.Doors
{
	public class SouthDungeonDoor : BaseDoor
	{
        public SouthDungeonDoor(Vector2 position, DoorTypes doorType)
			: base(position, doorType, Direction.South)
        {
            BottomYOffset = -16 * Constants.UniversalScale;
            SpriteTop = SpriteFactory.CreateDoorTopNorthSouth(Direction, DoorType);
            SpriteBottom = SpriteFactory.CreateDoorBottomNorthSouth(Direction, DoorType);
        }

        public override void Unlock()
        {
            if (!IsLocked) return;
            AudioManager.PlaySFX("Door_Unlock", 0);
            DoorType = DoorUtils.GetOpenedDoorVariant(DoorType);
            SpriteTop = SpriteFactory.CreateDoorTopNorthSouth(Direction, DoorType);
            SpriteBottom = SpriteFactory.CreateDoorBottomNorthSouth(Direction, DoorType);
        }
    }
}

