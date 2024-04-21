namespace MainGame.Players.Inventory
{
	public interface IInventoryItem
	{
		public int Id { get; }
		public string Name { get; }
        public bool Equippable { get; }
        public bool Stackable { get; }
		public bool IsUseable { get; }
		public int MaxStack { get; }
		public int Quantity { get; }

		public void Add(int quantity);
		public void Remove(int quantity);
		public void Use();
	}
}
