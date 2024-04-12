using System;
using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
	public class PlayerObtainEquipBoomerang : ICommand
    {
        private readonly IPlayer player;
        public PlayerObtainEquipBoomerang(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            if (!player.Inventory.GetObtainedItems().Contains(ItemTypes.Boomerang))
            {
                player.Inventory.ObtainItem(ItemTypes.Boomerang);
                Console.WriteLine("Obtained boomerang");
                return;
            }
            Console.WriteLine("Equiped boomerang");
            player.Inventory.Equip(ItemTypes.Boomerang);
        }

        public void UnExecute() { /* not needed */ }
    }
}
