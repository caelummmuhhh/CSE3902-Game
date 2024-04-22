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
            if (!player.Inventory.HasItem((int)ItemTypes.Boomerang))
            {
                player.Inventory.AddItem((int)ItemTypes.Boomerang, 1);
                Console.WriteLine("Obtained boomerang");
                return;
            }
        }

        public void UnExecute() { /* not needed */ }
    }
}
