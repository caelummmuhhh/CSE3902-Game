using System;
namespace MainGame.Players.Inventory
{
	public interface IItemCounter
	{
		public int StackMax { get; }
		public int Count { get; }

		public bool CanUse(int amount);

		/// <summary>
		/// Decrease Count by cost amount iff the difference is >0.
		/// </summary>
		/// <param name="cost">The amount to decrease Cost by</param>
		/// <returns>If Count was successfully decreased, i.e. if Use was successful</returns>
		public bool Use(int cost);
		public void Obtain(int amount);
	}
}

