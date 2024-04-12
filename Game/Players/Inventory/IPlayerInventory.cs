using System.Collections.Generic;

namespace MainGame.Players.Inventory
{
	public interface IInventory
	{
        public ItemTypes? EquippedItem { get; }
        public IItemCounter Rupees { get; }
        public IItemCounter KeyCount { get; }
        public IItemCounter BombCount { get; }
        public bool HasArrow { get; }

        public void Update();
        public void Draw();

        public List<ItemTypes> GetObtainedItems();
        public List<IEquipment> GetActiveEquipments();
        public void Equip(ItemTypes item);
        public void ObtainItem(ItemTypes item, int amount = 1);
        public void UseEquippedItem();
        public void UseSwordBeam();
        public bool CanUseEquippedItem();
    }
}
