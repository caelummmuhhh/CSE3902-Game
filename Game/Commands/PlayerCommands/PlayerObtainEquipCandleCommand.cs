using System;
using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
	public class PlayerObtainEquipCandleCommand : ICommand
    {
        private readonly IPlayer player;
        public PlayerObtainEquipCandleCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            Console.WriteLine("Equiped candle");
            player.Inventory.Equip(ItemTypes.Candle);
        }

        public void UnExecute() { /* not needed */ }
    }
}
