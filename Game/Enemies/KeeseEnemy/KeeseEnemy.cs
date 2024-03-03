using Microsoft.Xna.Framework;

namespace MainGame.Enemies
{
	public class KeeseEnemy : GenericEnemy
	{
        public override int MovementCoolDownFrame { get; protected set; } = 2;

        public KeeseEnemy(Vector2 spawnPosition)
        {
            Position = spawnPosition;
            State = new KeeseTakeOffState(this);
        }

        public override void Update()
        {
            State.Update();
            base.Update();
        }

        public override void Move() => State.Move();
    }
}

