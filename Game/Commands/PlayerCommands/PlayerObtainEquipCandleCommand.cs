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
            if (!player.Inventory.HasItem((int)ItemTypes.Candle))
            {
                player.Inventory.AddItem((int)ItemTypes.Candle, 1);
            }
            player.Inventory.Equip((int)ItemTypes.Candle);
        }

        public void UnExecute() { /* not needed */ }
    }
}
