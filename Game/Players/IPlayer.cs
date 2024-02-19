using MainGame.Players.PlayerStates;

namespace MainGame.Players
{
    public interface IPlayer
    {
        public IPlayerState CurrentState { get; set; }
        public void Update();
        public void Draw();
    }
}

