using System;
namespace MainGame.Players.Inventory.Equipment
{
	public static class EquipmentFactory
	{
		public static IEquipment GetEquipment(ItemTypes item, IPlayer player)
		{
            return item switch
            {
                ItemTypes.Boomerang => new BoomerangEquipment(player),
                ItemTypes.Bomb => new BombEquipment(player),
                ItemTypes.Bow => new BowEquipment(player),
                _ => null
            };
        }
    }
}

