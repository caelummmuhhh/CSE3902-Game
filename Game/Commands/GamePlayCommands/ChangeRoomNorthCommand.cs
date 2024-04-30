namespace MainGame.Commands
{
    public class ChangeRoomNorthCommand : ICommand
    {
        private PlayGameState game;

        public ChangeRoomNorthCommand(PlayGameState game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.RoomManager.NextRoom(Direction.North);
        }

        public void UnExecute()
        {
            
        }
    }
}
