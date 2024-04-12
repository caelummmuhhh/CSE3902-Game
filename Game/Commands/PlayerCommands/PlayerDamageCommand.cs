using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
    public class PlayerDamageCommand : ICommand
    {
        private readonly Game1 game;
        public PlayerDamageCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Player.TakeDamage(game.Player.FacingDirection, 0);
        }

        public void UnExecute()
        {
        }
    }
}

