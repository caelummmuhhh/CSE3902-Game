using System;
using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
	public class PlayerObtainBowCommand : ICommand
    {
        private readonly IPlayer player;
        public PlayerObtainBowCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            ItemTypes itemToObtain = ItemTypes.Bow;
            if (!player.Inventory.HasItem((int)itemToObtain))
            {
                player.Inventory.AddItem((int)itemToObtain, 1);
                Console.WriteLine($"Obtained {itemToObtain}!!");
                return;
            }
        }

        public void UnExecute() { /* not needed */ }
    }
}
