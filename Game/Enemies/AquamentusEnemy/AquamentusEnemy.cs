using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Players;

namespace MainGame.Enemies
{
	public class AquamentusEnemy : GenericEnemy
	{
        public override int MovementCoolDownFrame { get; protected set; } = 8;
        public int MovedDistance = 0;
        public readonly int MaxMoveDistance = 16 * 10 * Constants.UniversalScale;
        public readonly IPlayer Player;
        public readonly AquamentusProjectilesManager ProjectilesManager = new();

        public AquamentusEnemy(Vector2 startingPosition, IPlayer player)
		{
            Position = startingPosition;
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
        }

        public override void Draw()
        {
            ProjectilesManager.Draw();
            base.Draw();
        }

        public override void Move() => State.Move();
    }
}

