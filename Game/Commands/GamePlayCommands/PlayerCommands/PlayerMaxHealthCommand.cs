using System;
using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
	public class PlayerMaxHealthCommand : ICommand
    {
        private readonly IPlayer player;
        public PlayerMaxHealthCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.Heal(player.MaxHealth);
            Console.WriteLine("Healed player to max HP");
        }

        public void UnExecute() { /* not needed */ }
    }
}
