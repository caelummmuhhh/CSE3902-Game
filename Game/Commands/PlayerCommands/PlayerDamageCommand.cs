using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
    public class PlayerDamageCommand : ICommand
    {
        private readonly IPlayer player;
        public PlayerDamageCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.TakeDamage();
        }

        public void UnExecute()
        {
        }
    }
}

