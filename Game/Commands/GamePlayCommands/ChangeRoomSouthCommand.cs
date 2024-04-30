namespace MainGame.Commands
{
    public class ChangeRoomSouthCommand : ICommand
    {
        private PlayGameState game;

        public ChangeRoomSouthCommand(PlayGameState game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.RoomManager.NextRoom(Direction.South);
        }

        public void UnExecute()
        {
            
        }
    }
}
