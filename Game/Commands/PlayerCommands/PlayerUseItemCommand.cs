using MainGame.Players;
using System;

namespace MainGame.Commands.PlayerCommands
{
	public class PlayerUseItemCommand : ICommand
    {
        private readonly IPlayer player;
        public PlayerUseItemCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.UseEquipment();
        }

        public void UnExecute() { /* not needed */ }
    }
}
