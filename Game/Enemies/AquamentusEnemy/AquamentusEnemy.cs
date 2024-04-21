using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Players;
using MainGame.Audio;

namespace MainGame.Enemies
{
	public class AquamentusEnemy : GenericEnemy
	{
        public override int Health { get; protected set; } = 10;
        public override int Damage => 2;

        public override int MovementCoolDownFrame { get; protected set; } = 8;
        public int MovedDistance = 0;
        public readonly int MaxMoveDistance = 16 * 10 * Constants.UniversalScale;
        public readonly IPlayer Player;
        public readonly AquamentusProjectilesManager ProjectilesManager = new();

        private int RoarTime = 160;

        public AquamentusEnemy(Vector2 startingPosition, AudioManager audioManager, IPlayer player)
		{
            Position = startingPosition;
            AudioManager = audioManager;
            PreviousPosition = new(Position.X, Position.Y);
            Sprite = SpriteFactory.CreateAquamentusSprite();
            Player = player;
            State = new AquamentusAttackingState(new AquamentusMovingState(this), this);
		}

        public override void Update()
        {
            State.Update();
            ProjectilesManager.Update();
            base.Update();

            if(RoarTime <= 0)
            {
                AudioManager.PlaySFX("Boss_Roar", 0);
                RoarTime = 160;
            }
            --RoarTime;
        }

        public override void Draw()
        {
            ProjectilesManager.Draw();
            base.Draw();
        }

        public override void Move() => State.Move();

        public override void TakeDamage(Direction sideHit, int damage)
        {
            if (!IsInvulnerable)
            {
                DamageState = new EnemyDamagedState(this, sideHit, false);
                Health -= damage;
                CheckForDeath();
            }
        }
    }
}

