using System;
using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
	public class PlayerObtainBoomerangCommand : ICommand
    {
        private readonly IPlayer player;
        public PlayerObtainBoomerangCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            ItemTypes itemToObtain = ItemTypes.Boomerang;
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
