using System.Linq;
using System.Collections.Generic;
using MainGame.Players.Inventory.Equipment;

namespace MainGame.Players.Inventory
{
	public class PlayerInventory : IInventory
	{
        public ItemTypes? EquippedItem { get; private set; } = null;
        public IItemCounter Rupees { get; private set; }
        public IItemCounter KeyCount { get; private set; }
        public IItemCounter BombCount { get; private set; }
        public bool HasArrow { get; private set; } = false;

        private readonly IPlayer player;
        private readonly Dictionary<ItemTypes, IEquipment> equips = new();
        private readonly IEquipment swordBeam;

        public PlayerInventory(IPlayer player, ItemTypes[] obtainedItems, int startRupees, int keyCount, int bombCount)
		{
            this.player = player;
            equips[ItemTypes.Candle] = new CandleEquipment(this.player); // isn't actually obtainable rn
            swordBeam = new SwordBeamEquipment(this.player);
            foreach (ItemTypes obtainedItem in obtainedItems)
            {
                ObtainItem(obtainedItem, 1);
            }
            Rupees = new StackableItemCounter(startRupees);
            KeyCount = new StackableItemCounter(keyCount);
            BombCount = new StackableItemCounter(bombCount);
        }

        public void Equip(ItemTypes item)
        {
            if (equips.TryGetValue(item, out _))
            {
                EquippedItem = item;
            }
        }

        public void ObtainItem(ItemTypes item, int amount = 1)
        {
            if (item is ItemTypes.Arrow)
            {
                HasArrow = true;
                return;
            }

            equips.Add(item, EquipmentFactory.GetEquipment(item, player));
            if (item is ItemTypes.Bomb)
            {
                BombCount.Obtain(amount);
            }
        }

        public List<IEquipment> GetActiveEquipments()
        {
            List<IEquipment> inUse = equips.Values.Where(equipment => equipment.IsActive).ToList();
            if (swordBeam.IsActive)
            {
                inUse.Add(swordBeam);
            }
            return inUse;
        }

        public List<ItemTypes> GetObtainedItems() => new (equips.Keys);

        public void Update() => GetActiveEquipments().ForEach(item => item.Update());

        public void Draw() => GetActiveEquipments().ForEach(item => item.Draw());

        public void UseSwordBeam() => swordBeam.Use();

        public void UseEquippedItem()
        {
            bool hasEquip = equips.TryGetValue(EquippedItem.Value, out IEquipment equipment);
            if (!hasEquip || equipment.IsActive) { return; }

            if (EquippedItem is not ItemTypes.Bow || (HasArrow && Rupees.Use(1)))
            {
                equipment.Use();
            }

            if (EquippedItem is ItemTypes.Bomb && !BombCount.Use(1))
            {
                equips.Remove(ItemTypes.Bomb);
                EquippedItem = equips.Count > 0 ? equips.Keys.First() : null;
            }
        }

        public bool CanUseEquippedItem()
            => EquippedItem.HasValue && equips.TryGetValue(EquippedItem.Value, out IEquipment equipment)
                && (EquippedItem is not ItemTypes.Bow || (HasArrow && Rupees.CanUse(1)))
                && !equipment.IsActive;
    }
}
