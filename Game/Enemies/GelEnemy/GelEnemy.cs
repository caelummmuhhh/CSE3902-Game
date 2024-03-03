using System;
using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;

namespace MainGame.Enemies
{
	public class GelEnemy : GenericEnemy
	{
		public GelEnemy()
		{
			Position = new Vector2(400, 200);
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

