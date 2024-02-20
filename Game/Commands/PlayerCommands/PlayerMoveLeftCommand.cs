using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
    public class PlayerMoveLeftCommand : ICommand
    {
        private readonly IPlayer player;
        public PlayerMoveLeftCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.MoveLeft();
        }

        public void UnExecute()
        {
            player.Stop();
        }
    }
}

