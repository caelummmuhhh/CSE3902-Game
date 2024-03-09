using Microsoft.Xna.Framework;
using MainGame.Players;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
	public class SpikeCrossEnemy : GenericEnemy
	{
        public override int MovementCoolDownFrame { get; protected set; } = 1;
        public readonly IPlayer Player;

        public SpikeCrossEnemy(Vector2 startingPosition, IPlayer player)
		{
			Position = startingPosition;
			Player = player;
			Sprite = SpriteFactory.CreateSpikeCrossSprite();
			State = new SpikeCrossIdleState(this);
		}

        public override void Update() => State.Update();

		public override void Move() => State.Move();
    }
}

