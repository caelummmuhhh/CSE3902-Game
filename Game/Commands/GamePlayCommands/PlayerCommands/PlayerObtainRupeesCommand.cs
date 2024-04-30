using System;
using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
	public class PlayerObtainRupeesCommand : ICommand
    {
        private readonly IPlayer player;
        public PlayerObtainRupeesCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            ItemTypes itemToObtain = ItemTypes.Rupee;
            player.Inventory.AddItem((int)itemToObtain, 1);
            Console.WriteLine($"Obtained 1 {itemToObtain}!!");
        }

        public void UnExecute() { /* not needed */ }
    }
}
