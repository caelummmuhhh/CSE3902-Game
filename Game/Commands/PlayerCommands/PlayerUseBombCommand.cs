using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
	public class PlayerUseBombCommand : ICommand
    {
        private readonly Player player;
        public PlayerUseBombCommand(Player player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.UseBomb();
        }

        public void UnExecute() { /* not needed */ }
    }
}
