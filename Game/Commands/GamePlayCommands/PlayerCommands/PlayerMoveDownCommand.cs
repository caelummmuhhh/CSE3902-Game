using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
    public class PlayerMoveDownCommand : ICommand
    {
        private readonly IPlayer player;
        public PlayerMoveDownCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.MoveDown();
        }

        public void UnExecute()
        {
            player.Stop();
        }
    }
}

