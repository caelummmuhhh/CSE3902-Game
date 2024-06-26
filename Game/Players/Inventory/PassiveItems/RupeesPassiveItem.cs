﻿using System;
namespace MainGame.Players.Inventory
{
	public class RupeesPassiveItem : IInventoryItem
    {
        public int Id => (int)itemType;
        public string Name => itemType.ToString();
        public bool Equippable { get; } = false;
        public bool Stackable { get; } = true;
        public bool IsUseable => Quantity > 0;
        public int MaxStack { get; } = 999;
        public int Quantity { get; private set; }

        private readonly ItemTypes itemType = ItemTypes.Rupee;

        public RupeesPassiveItem(int startingQuantity = 0)
        {
            Quantity = startingQuantity;
        }

        public void Add(int quantity) => Quantity = Quantity + quantity > MaxStack ? MaxStack : Quantity + quantity;
        public void Remove(int quantity) => Quantity = Quantity - quantity < 0 ? 0 : Quantity - quantity;
        public void Use() => Remove(1);
    }
}
