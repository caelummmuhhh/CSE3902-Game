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
            if (player.CurrentHealth == player.MaxHealth)
            {
                player.CurrentState.UseSwordBeam();
            }
            else
            {
                player.CurrentState.UseSword();
            }
        }

        public void UnExecute() { /* not needed */ }
    }
}

