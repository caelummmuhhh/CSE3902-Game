using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
    public class PlayerUseSwordCommand : ICommand
    {
        private readonly IPlayer player;
        private readonly Game1 game;
        public PlayerUseSwordCommand(Game1 game, IPlayer player)
        {
            this.player = player;
            this.game = game;
        }

        public void Execute()
        {
            player.UseSword();
        }

        public void UnExecute() { /* not needed */ }
    }
}

