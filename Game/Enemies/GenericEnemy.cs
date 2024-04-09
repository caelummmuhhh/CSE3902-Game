using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
	public abstract class GenericEnemy : IEnemy
	{
        public static readonly int ImmunityFrame = 10;
        public static readonly float MaxKnockedBackDistance = Constants.BlockSize;
        public static readonly float KnockBackSpeed = 10f;
        /// <summary>
        /// If moving, the entity can only move once every MovementCoolDownFrame.
        /// </summary>
        public abstract int MovementCoolDownFrame {  get; protected set; }
        public virtual Rectangle AttackHitBox { get => new(Position.ToPoint(), Sprite.DestinationRectangle.Size); }
        public virtual Rectangle MovementHitBox { get => new(Position.ToPoint(), Sprite.DestinationRectangle.Size); }
        public virtual bool IsInvulnerable { get => invulnerableTimer > 0; }
        public bool IsStunned { get => stunDuration > 0; }

        public virtual Vector2 PreviousPosition { get; set; }
        public virtual Direction MovingDirection { get; set; }

        public virtual int MovementSpeed { get; protected set; } = Constants.UniversalScale;
        public virtual ISprite Sprite { get; set; }
        public virtual Vector2 Position { get; set; }
        public virtual IEnemyState State { get; set; }

        protected Color spriteColor = Color.White;
        protected int invulnerableTimer = 0;
        protected int stunDuration = 0;
        protected float knockedBackDistance = 0f;
        protected Direction knockBackDirection;

        public GenericEnemy() { }

        public virtual void Update()
        {
            if (invulnerableTimer > 0)
            {
                invulnerableTimer--;
                FlashColors();
                KnockBack();
            }
            else
            {
                spriteColor = Color.White;
                knockedBackDistance = 0f;
            }

            Sprite.Update();
            if (stunDuration > 0)
            {
                stunDuration--;
                return;
            }
            Move();
        }

        public virtual void Draw() => Sprite.Draw(Position.X, Position.Y, spriteColor);

        public abstract void Move();

        public virtual void TakeDamage(Direction sideHit)
        {
            if (invulnerableTimer <= 0)
            {
                knockBackDirection = Utils.OppositeDirection(sideHit);
                invulnerableTimer = ImmunityFrame;
            }
        }

        public virtual void Stun(int duration) => stunDuration = duration;

        protected virtual void KnockBack()
        {
            if (knockedBackDistance < MaxKnockedBackDistance)
            {
                Vector2 newPos = Utils.DirectionalMove(Position, knockBackDirection, KnockBackSpeed);
                knockedBackDistance += Vector2.Distance(newPos, Position);
                Position = newPos;
            }
        }

        protected virtual void FlashColors()
        {
            spriteColor = Color.White;
            if (invulnerableTimer % 4 == 0 || invulnerableTimer % 4 == 1)
            {
                spriteColor = Color.IndianRed;
            }
        }
    }
}
