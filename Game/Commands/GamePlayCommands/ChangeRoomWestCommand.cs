namespace MainGame.Commands
{
    public class ChangeRoomWestCommand : ICommand
    {
        private PlayGameState game;

        public ChangeRoomWestCommand(PlayGameState game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.RoomManager.NextRoom(Direction.West);
        }

        public void UnExecute()
        {
            
        }
    }
}
