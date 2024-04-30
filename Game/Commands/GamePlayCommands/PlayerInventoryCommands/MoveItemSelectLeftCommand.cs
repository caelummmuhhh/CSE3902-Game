namespace MainGame.Commands.MenuCommands
{
	public class MoveItemSelectLeftCommand : ICommand
    {
        private readonly PlayGameState game;
        public MoveItemSelectLeftCommand(PlayGameState game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Menu.MoveSelectingBoxLeft();
        }

        public void UnExecute() { }
    }
}
