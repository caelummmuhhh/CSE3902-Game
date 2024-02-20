using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
	public class PlayerUseBombCommand : ICommand
    {
        private readonly IPlayer player;
        public PlayerUseBombCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.CurrentState.UseBomb();
        }

        public void UnExecute() { /* not needed */ }
    }
}
