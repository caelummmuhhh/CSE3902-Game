using Microsoft.Xna.Framework;
using MainGame.Players.PlayerStates;
using MainGame.Projectiles;
using MainGame.SpriteHandlers;

namespace MainGame.Players
{
    public interface IPlayer
    {
        public IPlayerState CurrentState { get; set; }
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public bool IsMoving { get; set; }

        public void Update();
        public void Draw();

        public void TakeDamage();

        public void MoveUp();
        public void MoveDown();
        public void MoveLeft();
        public void MoveRight();
        public void Stop();
        public void UseSword();
        public void UseBoomerang(Direction direction);
        public void UseArrow(Direction direction);
        public void UseFire(Direction direction);
        public void UseBomb(Direction direction);
        public void UseSwordBeam(Direction direction);
    }
}

