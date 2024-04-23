using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace MainGame.Doors
{
	public static class DoorUtils
	{
		public static DoorTypes GetOpenedDoorVariant(DoorTypes closedDoor)
		{
			return closedDoor switch
			{
				DoorTypes.DiamondDoor => DoorTypes.OpenDoor,
				DoorTypes.WallDestructible => DoorTypes.DestroyedWall,
				DoorTypes.KeyDoor => DoorTypes.OpenDoor,
				_ => closedDoor
			};
		}

		public static IDoor CreateDungeonDoor(Vector2 position, Direction direction, DoorTypes doorType)
		{
			return direction switch
			{
				Direction.North => new NorthDungeonDoor(position, doorType),
				Direction.East => new EastDungeonDoor(position, doorType),
				Direction.South => new SouthDungeonDoor(position, doorType),
				Direction.West => new WestDungeonDoor(position, doorType),
				_ => null
			};
        }

		public static IDoor CreateBlankDoor() => new BlankDoor();

		public static IDoor CloneDoor(IDoor door) => CreateDungeonDoor(door.Position, door.Direction, door.DoorType);

		public static bool IsLockedDoorType(DoorTypes doorType)
		{
			List<DoorTypes> lockedDoorTypes = new()
			{
				DoorTypes.DiamondDoor, DoorTypes.WallNormal, DoorTypes.KeyDoor, DoorTypes.WallDestructible
			};

			return lockedDoorTypes.Contains(doorType);
		}
    }
}

 