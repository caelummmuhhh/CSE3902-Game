using Microsoft.Xna.Framework;
using MainGame.Players.PlayerStates;
using MainGame.Players.Inventory;
using MainGame.SpriteHandlers;
using MainGame.WorldItems;

namespace MainGame.Players
{
    public interface IPlayer
    {
        public int MaxHealth { get; }
        public int CurrentHealth { get; }
        public bool IsDead { get; set; }
        public ILinkInventory Inventory { get; }

        public IPlayerState CurrentState { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 PreviousPosition { get; set; }
        public Color SpriteColor { get; set; }
        public ISprite Sprite { get; set; }
        public Direction FacingDirection { get; set; }
        public bool IsInvulnerable { get; }

        public Rectangle MainHitbox { get; }
        public Rectangle BottomHalfHitBox { get; }
        public Rectangle SwordHitBox { get; set; }

        public void MakeInvulnerable(int duration);
        public void TakeDamage(Direction sideHit, int damageAmount);
        public void Heal(int healAmount);

        public void Update();
        public void Draw();

        public void MoveUp();
        public void MoveDown();
        public void MoveLeft();
        public void MoveRight();
        public void Stop();
        public void UseSword();
        public void UseEquipment();
        public void IncreaseMaxHP(int amount = 2);
    }
}

