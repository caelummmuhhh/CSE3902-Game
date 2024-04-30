using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
    public class PlayerDamageCommand : ICommand
    {
        private readonly PlayGameState game;
        public PlayerDamageCommand(PlayGameState game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Player.TakeDamage(game.Player.FacingDirection, 2);
        }

        public void UnExecute()
        {
        }
    }
}

