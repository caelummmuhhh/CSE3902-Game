using Microsoft.Xna.Framework;
using MainGame.Players;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
	public class WallMasterEnemy : GenericEnemy
	{
		public override int MovementCoolDownFrame { get; protected set; } = 3;
        public readonly IPlayer Player;

        public override Rectangle MovementHitBox { get => new(); }

        public WallMasterEnemy(Vector2 startingPosition, IPlayer player)
		{
			Sprite = SpriteFactory.CreateWallMasterSprite();
            Player = player;
            Position = startingPosition;
            PreviousPosition = new(Position.X, Position.Y);
            State = new WallMasterIdleState(this, Player);
        }
        public override void Update()
        {
            State.Update();
            base.Update();
        }
        public override void Move() => State.Move();
    }
}

