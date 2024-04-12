using System;
using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
	public class PlayerObtainEquipBowCommand : ICommand
    {
        private readonly IPlayer player;
        public PlayerObtainEquipBowCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            if (!player.Inventory.GetObtainedItems().Contains(ItemTypes.Bow))
            {
                player.Inventory.ObtainItem(ItemTypes.Bow);
                Console.WriteLine("Obtained boomerang");
                return;
            }

            if (!player.Inventory.HasArrow)
            {
                player.Inventory.ObtainItem(ItemTypes.Arrow);
                Console.WriteLine("Obtained arrow");
                return;
            }

            if (player.Inventory.Rupees.Count <= 0)
            {
                player.Inventory.Rupees.Obtain(100);
                Console.WriteLine("Obtained 100 rupees!");
            }

            Console.WriteLine("Equipped bow");
            player.Inventory.Equip(ItemTypes.Bow);
        }

        public void UnExecute() { /* not needed */ }
    }
}
