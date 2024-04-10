using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
    public class PlayerMoveRightCommand : ICommand
    {
        private readonly Game1 game;
        public PlayerMoveRightCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Player.MoveRight();
        }

        public void UnExecute()
        {
            game.Player.Stop();
        }
    }
}

