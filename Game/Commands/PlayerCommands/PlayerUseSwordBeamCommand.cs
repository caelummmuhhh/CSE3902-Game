using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
	public class PlayerUseSwordBeamCommand : ICommand
    {
        private readonly Player player;
        public PlayerUseSwordBeamCommand(Player player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.CurrentState.UseSwordBeam();
        }

        public void UnExecute() { /* not needed */ }
    }
}
