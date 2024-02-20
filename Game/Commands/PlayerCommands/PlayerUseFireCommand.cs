using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
	public class PlayerUseFireCommand : ICommand
    {
        private readonly IPlayer player;
        public PlayerUseFireCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.CurrentState.UseFire();
        }

        public void UnExecute() { /* not needed */ }
    }
}
