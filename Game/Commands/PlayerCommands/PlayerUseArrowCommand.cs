using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
	public class PlayerUseArrowCommand : ICommand
    {
        private readonly Player player;
        public PlayerUseArrowCommand(Player player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.CurrentState.UseArrow();
        }

        public void UnExecute() { /* not needed */ }
    }
}
