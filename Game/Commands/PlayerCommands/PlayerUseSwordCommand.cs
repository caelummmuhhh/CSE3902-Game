using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
    public class PlayerUseSwordCommand : ICommand
    {
        private readonly IPlayer player;
        public PlayerUseSwordCommand(IPlayer player)
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

