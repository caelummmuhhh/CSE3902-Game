using System;
namespace MainGame.Enemies
{
	public interface IEnemyState
	{
        public void Update();
        public void Draw();
        public void Move();
    }
}

