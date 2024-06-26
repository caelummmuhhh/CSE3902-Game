﻿using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Audio;

namespace MainGame.Doors
{
	public class NorthDungeonDoor : BaseDoor
	{
        public NorthDungeonDoor(Vector2 position, DoorTypes doorType)
			: base(position, doorType, Direction.North)
        {
            BottomYOffset = 16 * Constants.UniversalScale;
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

