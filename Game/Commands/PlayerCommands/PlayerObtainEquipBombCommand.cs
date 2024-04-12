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
            if (!player.Inventory.GetObtainedItems().Contains(ItemTypes.Bomb))
            {
                player.Inventory.ObtainItem(ItemTypes.Bomb, 10);
                Console.WriteLine("Obtained 3 bomb");
                return;
            }
            Console.WriteLine("Equipped bomb");
            player.Inventory.Equip(ItemTypes.Bomb);
        }

        public void UnExecute() { /* not needed */ }
    }
}
