using System;
using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
	public class PlayerObtainEquipBombCommand : ICommand
    {
        private readonly IPlayer player;
        public PlayerObtainEquipBombCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            if (player.Inventory.Bombs.Quantity <= 0)
            {
                player.Inventory.AddItem((int)ItemTypes.Bomb, 4);
                Console.WriteLine("Obtained 4 bomb");
                return;
            }
        }

        public void UnExecute() { /* not needed */ }
    }
}
