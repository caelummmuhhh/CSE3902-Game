using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
    public class PlayerMoveDownCommand : ICommand
    {
        private readonly Player player;
        public PlayerMoveDownCommand(Player player)
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

