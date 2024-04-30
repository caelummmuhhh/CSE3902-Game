namespace MainGame.Commands
{
    public class ChangeRoomEastCommand : ICommand
    {
        private PlayGameState game;

        public ChangeRoomEastCommand(PlayGameState game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.RoomManager.NextRoom(Direction.East);
        }

        public void UnExecute()
        {
            
        }
    }
}
