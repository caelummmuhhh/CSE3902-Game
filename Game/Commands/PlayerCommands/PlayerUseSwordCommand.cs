using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
    public class PlayerUseSwordCommand : ICommand
    {
        private readonly IPlayer player;
        public PlayerUseSwordCommand(IPlayer player)
        {
            this.player = player;
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

