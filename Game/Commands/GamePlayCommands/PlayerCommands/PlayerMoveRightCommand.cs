using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
    public class PlayerMoveRightCommand : ICommand
    {
        private readonly PlayGameState game;
        public PlayerMoveRightCommand(PlayGameState game)
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

