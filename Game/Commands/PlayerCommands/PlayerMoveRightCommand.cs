using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
    public class PlayerMoveRightCommand : ICommand
    {
        private readonly Player player;
        public PlayerMoveRightCommand(Player player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.MoveRight();
        }

        public void UnExecute()
        {
            player.Stop();
        }
    }
}

