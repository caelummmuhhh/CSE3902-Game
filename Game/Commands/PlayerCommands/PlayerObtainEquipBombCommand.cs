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
            if (!player.Inventory.HasItem((int)ItemTypes.Bomb))
            {
                player.Inventory.AddItem((int)ItemTypes.Bomb, 10);
                Console.WriteLine("Obtained 3 bomb");
                return;
            }
            Console.WriteLine("Equipped bomb");
            player.Inventory.Equip((int)ItemTypes.Bomb);
        }

        public void UnExecute() { /* not needed */ }
    }
}
