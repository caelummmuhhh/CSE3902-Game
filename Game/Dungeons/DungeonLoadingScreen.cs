using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MainGame.SpriteHandlers;

namespace MainGame.Dungeons
{
    public class DungeonLoadingScreen
    {
        private ISprite loadingTextSprite;
        private Game1 game;
        public bool IsLoading { get; private set; } = true;

        public DungeonLoadingScreen(Game1 game)
        {
            this.game = game;
        }

        public void Initialize()
        {
            loadingTextSprite = SpriteFactory.CreateTextSprite("Press 1 for Dungeon 1, Press 2 for Dungeon 1 Debug");
        }

        public void Update(GameTime gameTime)
        {
            if (!IsLoading) return;

            if (Keyboard.GetState().IsKeyDown(Keys.D1))
            {
                game.LoadSelectedDungeon("Dungeons_1.csv");
                IsLoading = false;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D2))
            {
                game.LoadSelectedDungeon("Dungeons_1_Debug.csv");
                IsLoading = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!IsLoading || loadingTextSprite == null) return;
            loadingTextSprite.Draw(0,0, Color.White);
        }
    }
}