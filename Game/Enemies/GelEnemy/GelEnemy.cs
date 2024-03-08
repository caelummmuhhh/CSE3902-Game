using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
	public class GelEnemy : GenericEnemy
	{
        public override int MovementCoolDownFrame { get; protected set; } = 1;

        public GelEnemy(Vector2 startingPosition)
		{
			Position = startingPosition; 
			Sprite = SpriteFactory.CreateGelSprite();
            State = new GelIdleState(this);
        }

        public override void Move() => State.Move();

        public override void Update()
        {
            State.Update();
            base.Update();
        }
    }
}

