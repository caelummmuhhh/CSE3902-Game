using System;
namespace MainGame.Players.Inventory
{
	public class ArrowPassiveItem : IInventoryItem
	{
        public int Id => (int)itemType;
        public string Name => itemType.ToString();
        public bool Equippable { get; } = false;
        public bool Stackable { get; } = false;
        public bool IsUseable { get; } = true;
        public int MaxStack { get; } = 1;
        public int Quantity { get; } = 1;

        private readonly ItemTypes itemType = ItemTypes.Arrow;

        public ArrowPassiveItem() { }

        public void Add(int quantity) { }
        public void Remove(int quantity) { }

        public void Use() { }
    }
}

