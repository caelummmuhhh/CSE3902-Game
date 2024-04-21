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
            if (!player.Inventory.HasItem((int)ItemTypes.Bow))
            {
                player.Inventory.AddItem((int)ItemTypes.Bow, 1);
                Console.WriteLine("Obtained boomerang");
                return;
            }

            if (!player.Inventory.HasItem((int)ItemTypes.Arrow))
            {
                player.Inventory.AddItem((int)ItemTypes.Arrow, 1);
                Console.WriteLine("Obtained arrow");
                return;
            }

            if (player.Inventory.Rupees.Quantity <= 0)
            {
                player.Inventory.Rupees.Add(100);
                Console.WriteLine("Obtained 100 rupees!");
            }

            Console.WriteLine("Equipped bow");
            player.Inventory.Equip((int)ItemTypes.Bow);
        }

        public void UnExecute() { /* not needed */ }
    }
}
