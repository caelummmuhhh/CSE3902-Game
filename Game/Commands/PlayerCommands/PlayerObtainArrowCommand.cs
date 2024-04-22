using System;
using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
	public class PlayerObtainArrowCommand : ICommand
    {
        private readonly IPlayer player;
        public PlayerObtainArrowCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            ItemTypes itemToObtain = ItemTypes.Arrow;
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
