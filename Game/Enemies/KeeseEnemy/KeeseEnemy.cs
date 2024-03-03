using Microsoft.Xna.Framework;

namespace MainGame.Enemies
{
	public class KeeseEnemy : GenericEnemy
	{
        public static readonly int Speed = 1;

        public KeeseEnemy()
        {
            Position = new Vector2(400, 200);
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

