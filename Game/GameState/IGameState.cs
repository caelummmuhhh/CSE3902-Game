using Microsoft.Xna.Framework;

namespace MainGame;

public interface IGameState
{
    public void Update(GameTime gameTime);
    public void Draw(GameTime gameTime);
}
