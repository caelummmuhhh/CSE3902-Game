namespace MainGame.Commands.MenuCommands
{
	public class MoveItemSelectRightCommand : ICommand
    {
		private readonly Game1 game;
        public MoveItemSelectRightCommand(Game1 game)
		{
			this.game = game;
		}

        public void Execute()
        {
            game.Menu.MoveSelectingBoxRight();
        }

        public void UnExecute() { }
    }
}
