using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Players.PlayerStates;
using MainGame.Projectiles;

namespace MainGame.Players
{
    public class DamagedPlayer : IPlayer
    {
        public IPlayerState CurrentState
        {
            get => undecoratedPlayer.CurrentState;
            set => undecoratedPlayer.CurrentState = value;
        }
        public Vector2 Position
        {
            get => undecoratedPlayer.Position;
            set => undecoratedPlayer.Position = value;
        }
        public ISprite Sprite
        {
            get => undecoratedPlayer.Sprite;
            set => undecoratedPlayer.Sprite = value;
        }
        public bool IsMoving
        {
            get => undecoratedPlayer.IsMoving;
            set => undecoratedPlayer.IsMoving = value;
        }

        private readonly Game1 game;
        private readonly IPlayer undecoratedPlayer;
        private int debounceTimer = 50;

        public DamagedPlayer(IPlayer undecoratedPlayer, Game1 game)
        {
            this.game = game;
            this.undecoratedPlayer = undecoratedPlayer;
        }

        public void Draw()
        {
            Color color = Color.White;
            if (debounceTimer % 4 == 0 || debounceTimer % 3 == 0)
            {
                color = Color.IndianRed;
            }
            undecoratedPlayer.Draw();
            undecoratedPlayer.Sprite.Draw(undecoratedPlayer.Position.X, undecoratedPlayer.Position.Y, color, debounceTimer, debounceTimer);
        }

        public void Update()
        {
            if (debounceTimer <= 0)
            {
                UnDecorate();
            }

            debounceTimer--;
            undecoratedPlayer.Update();
        }

        private void UnDecorate()
        {
            game.Player = undecoratedPlayer;
        }

        public void TakeDamage() { /* not needed */ }
        public void Stop() => undecoratedPlayer.Stop();
        public void MoveUp() => undecoratedPlayer.MoveUp();
        public void MoveDown() => undecoratedPlayer.MoveDown();
        public void MoveLeft() => undecoratedPlayer.MoveLeft();
        public void MoveRight() => undecoratedPlayer.MoveRight();
        public void UseSword() => undecoratedPlayer.UseSword();
        public void UseBoomerang(Direction direction) => undecoratedPlayer.UseBoomerang(direction);
        public void UseArrow(Direction direction) => undecoratedPlayer.UseArrow(direction);
        public void UseFire(Direction direction) => undecoratedPlayer.UseFire(direction);
        public void UseBomb(Direction direction) => undecoratedPlayer.UseBomb(direction);
        public void UseSwordBeam(Direction direction) => undecoratedPlayer.UseSwordBeam(direction);
    }
}

