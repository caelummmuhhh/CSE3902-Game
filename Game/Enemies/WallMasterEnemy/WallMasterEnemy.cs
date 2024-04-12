using Microsoft.Xna.Framework;
using MainGame.Players;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
	public class WallMasterEnemy : GenericEnemy
	{
		public override int MovementCoolDownFrame { get; protected set; } = 1;
        public readonly IPlayer Player;

        public WallMasterEnemy(Vector2 startingPosition, IPlayer player)
		{
			Sprite = SpriteFactory.CreateWallMasterSprite();
            Player = player;
            Position = startingPosition;
            PreviousPosition = new(Position.X, Position.Y);
        }

        public override void Move()
        {
            // TODO
        }
        public override void Draw() => Sprite.Draw(Position.X, Position.Y, SpriteColor);

    }
}

