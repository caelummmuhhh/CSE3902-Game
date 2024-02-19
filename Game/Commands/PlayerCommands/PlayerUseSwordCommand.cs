using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
    public class PlayerUseSwordCommand : ICommand
    {
        private readonly Player player;
        public PlayerUseSwordCommand(Player player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.UseSword();
        }

        public void UnExecute() { /* not needed */ }
    }
}

