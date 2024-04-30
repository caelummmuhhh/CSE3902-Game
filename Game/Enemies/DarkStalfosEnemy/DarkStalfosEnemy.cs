using Microsoft.Xna.Framework;
using MainGame.SpriteHandlers;
using MainGame.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MainGame.Enemies
{
	public class DarkStalfosEnemy : GenericEnemy
	{
        public override int Health { get; protected set; } = 3;
        public override int Damage => 1;
        public override int MovementCoolDownFrame { get; protected set; } = 2;

        private int still;
		public DarkStalfosEnemy(Vector2 startingPosition)
		{
			Position = startingPosition;
            PreviousPosition = new(Position.X, Position.Y);
            Sprite = SpriteFactory.CreateDarkStalfosSprite();
		}

		public override void Update()
		{
			
                KeyboardState keyboardState = Keyboard.GetState();
                // HOPEFULLY NOBODY SEES THE SHORTCUT IM TAKING HAHA THIS IS DEF HIGH QUALITY CODING PRACTICES (TIME CRUNCH)
                if (keyboardState.IsKeyDown(Keys.A))
                {
                    MovingDirection = Direction.West;
                    
                }
                else if (keyboardState.IsKeyDown(Keys.D))
                {
                    MovingDirection = Direction.East;
                }

                else if (keyboardState.IsKeyDown(Keys.W))
                {
                    MovingDirection = Direction.North;
                }
                else if (keyboardState.IsKeyDown(Keys.S))
                {
                    MovingDirection = Direction.South;
                } else
            {
                still = 1;
            }
                //HAHAHAH

              

			State?.Update();
          
			base.Update();
        }

        public override void Draw()
        {
            if (IsAlive)
            {
                Sprite.Draw(Position.X, Position.Y, SpriteColor);
                return;
            }
            State?.Draw();
        }

        public override void Move()
        {
            PreviousPosition = new(Position.X, Position.Y);
            
				
                

                if (still == 1)
                {
                    Position = PreviousPosition;
                    still = 0;
                } else
                {
                    Position = Utils.DirectionalMove(Position, MovingDirection, MovementSpeed);
                }
               
            
        }
    }
}

