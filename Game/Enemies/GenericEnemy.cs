using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
	public abstract class GenericEnemy : IEnemy
	{
        public static readonly int ImmunityFrame = GameConstants.GenericEnemyImmunityFrame;
        public static readonly float MaxKnockedBackDistance = Constants.BlockSize;
        public static readonly float KnockBackSpeed = GameConstants.GenericEnemyKnockBackSpeed;
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
        protected int invulnerableTimer = GameConstants.GenericEnemyInitialInvulnerableTimer;
        protected int stunDuration = GameConstants.GenericEnemyInitialStunDuration;
        protected float knockedBackDistance = GameConstants.GenericEnemyInitialKnockedBackDistance;
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
            if (invulnerableTimer % GameConstants.GenericEnemyFlashColorFactor == 0 || invulnerableTimer % GameConstants.GenericEnemyFlashColorFactor == 1)
            {
                spriteColor = Color.IndianRed;
            }
        }
    }
}
