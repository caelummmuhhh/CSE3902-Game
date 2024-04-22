using System;
using Microsoft.Xna.Framework;
using MainGame.Audio;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
	public abstract class GenericEnemy : IEnemy
	{
        public static readonly int ImmunityFrame = 32;
        public static readonly float MaxKnockedBackDistance = Constants.BlockSize;
        public static readonly float KnockBackSpeed = 10f;

        public abstract int Health { get; protected set; }
        public abstract int Damage { get; }
        public virtual bool IsAlive => Health > 0;

        public abstract int MovementCoolDownFrame {  get; protected set; }

        public virtual Rectangle AttackHitBox
            => IsAlive ? new(Position.ToPoint(), Sprite.DestinationRectangle.Size) : new Rectangle();
        public virtual Rectangle MovementHitBox
            => IsAlive ? new(Position.ToPoint(), Sprite.DestinationRectangle.Size) : new Rectangle();

        public virtual bool IsInvulnerable { get; set; }
        public virtual bool IsStunned { get; set; }
        public virtual Color SpriteColor { get; set; } = Color.White;

        public virtual Vector2 PreviousPosition { get; set; }
        public virtual Direction MovingDirection { get; set; }

        public virtual int MovementSpeed { get; protected set; } = Constants.UniversalScale;
        public virtual ISprite Sprite { get; set; }
        public virtual Vector2 Position { get; set; }
        public virtual IEnemyState State { get; set; }
        protected virtual IEnemyState DamageState { get; set; }

        public GenericEnemy() { }

        public virtual void Update()
        {
            if (!IsAlive) { return; }

            Sprite.Update();
            DamageState?.Update();

            if (!IsStunned)
            {
                Move();
            }

            if (!IsInvulnerable && DamageState is not null)
            {
                DamageState = null;
            }
        }

        public virtual void Draw() => State.Draw();

        public abstract void Move();

        public virtual void TakeDamage(Direction sideHit, int damage)
        {
            if (!IsInvulnerable)
            {
                DamageState = new EnemyDamagedState(this, sideHit, true);
                Health -= damage;
                CheckForDeath();
                AudioManager.PlaySFX("Enemy_Hit", 0);
            }
        }

        public virtual void Stun(int duration)
        {
            if (!IsStunned)
            {
                State = new EnemyStunnedState(this, State, duration);
            }
        }

        protected void CheckForDeath()
        {
            if (!IsAlive)
            {
                AudioManager.PlaySFX("Enemy_Die", 0);
                State = new EnemyDeathState(this);
            }
        }
    }
}
