using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
	public class PlayerUseBoomerangCommand : ICommand
    {
        private readonly IPlayer player;
        public PlayerUseBoomerangCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.CurrentState.UseBoomerang();
        }

        public void UnExecute() { /* not needed */ }
    }
}
