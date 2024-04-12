using System;
namespace MainGame.Players.Inventory
{
	public class StackableItemCounter : IItemCounter
	{
        public int StackMax => 999; // TODO: send this to a resource file
        public int Count => counter;

        private int counter;

        public StackableItemCounter(int startingRupees)
		{
            counter = startingRupees;
		}

        public bool CanUse(int amount = 1) => counter >= amount;

        public void Obtain(int amount = 1) => counter += amount;

        public bool Use(int cost)
        {
            bool spendable = CanUse(cost);
            if (spendable)
            {
                counter -= cost;
            }

            return spendable;
        }
    }
}

