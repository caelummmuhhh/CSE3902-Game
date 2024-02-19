using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
	public class PlayerUseBoomerangCommand : ICommand
    {
        private readonly Player player;
        public PlayerUseBoomerangCommand(Player player)
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
