namespace MainGame.Commands
{
    public class NextRoomCommand : ICommand
    {
        private PlayGameState game;

        public NextRoomCommand(PlayGameState game)
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
