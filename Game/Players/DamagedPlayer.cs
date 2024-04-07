using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Players.PlayerStates;

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
        public Direction FacingDirection
        {
            get => undecoratedPlayer.FacingDirection;
            set => undecoratedPlayer.FacingDirection = value;
        }
        public Rectangle MainHitbox
        {
            get => undecoratedPlayer.MainHitbox;
            set => undecoratedPlayer.MainHitbox = value;
        }
        public Rectangle BottomHalfHitBox
        {
            get => undecoratedPlayer.BottomHalfHitBox;
            set => undecoratedPlayer.BottomHalfHitBox = value;
        }
        public Rectangle SwordHitBox
        {
            get => undecoratedPlayer.SwordHitBox;
            set => undecoratedPlayer.SwordHitBox = value;
        }
        public Vector2 PreviousPosition
        {
            get => undecoratedPlayer.PreviousPosition;
            set => undecoratedPlayer.PreviousPosition = value;
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
            undecoratedPlayer.Sprite.Draw(undecoratedPlayer.Position.X, undecoratedPlayer.Position.Y, color);
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
