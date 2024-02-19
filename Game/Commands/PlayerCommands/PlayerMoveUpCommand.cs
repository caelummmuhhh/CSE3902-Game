using MainGame.Players;

namespace MainGame.Commands.PlayerCommands
{
	public class PlayerMoveUpCommand : ICommand
	{
		private readonly Player player;
		public PlayerMoveUpCommand(Player player)
		{
			this.player = player;
		}

		public void Execute()
		{
			player.MoveUp();
		}

		public void UnExecute()
		{
            player.Stop();
        }
    }
}

