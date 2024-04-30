namespace MainGame.Commands.MenuCommands
{
	public class MoveItemSelectRightCommand : ICommand
    {
		private readonly PlayGameState game;
        public MoveItemSelectRightCommand(PlayGameState game)
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
