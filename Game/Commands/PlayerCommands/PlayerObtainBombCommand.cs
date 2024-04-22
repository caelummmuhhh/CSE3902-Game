using System;
using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
	public class PlayerObtainBombCommand : ICommand
    {
        private readonly IPlayer player;
        public PlayerObtainBombCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            ItemTypes itemToObtain = ItemTypes.Bomb;
            player.Inventory.AddItem((int)itemToObtain, 1);
            Console.WriteLine($"Obtained 1 {itemToObtain}!!");
        }

        public void UnExecute() { /* not needed */ }
    }
}
