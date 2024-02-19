using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
	public class PlayerUseFireCommand : ICommand
    {
        private readonly Player player;
        public PlayerUseFireCommand(Player player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.UseFire();
        }

        public void UnExecute() { /* not needed */ }
    }
}
