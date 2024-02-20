using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MainGame.SpriteHandlers;
using MainGame.Controllers;
using MainGame.Players;
using System.Collections.Generic;

namespace MainGame.Managers
{
    public class BlockManager
    {
        private List<ISprite> blocks;

        public BlockManager()
        {
            blocks = new List<ISprite>();
        }

        public void LoadBlocks()
        {
        blocks.Add(MainGame.SpriteHandlers.SpriteFactory.CreateBlueFloorSprite());
        blocks.Add(MainGame.SpriteHandlers.SpriteFactory.CreateSquareBlockSprite());
        blocks.Add(MainGame.SpriteHandlers.SpriteFactory.CreateStatueOneEntranceSprite());
        blocks.Add(MainGame.SpriteHandlers.SpriteFactory.CreateStatueTwoEntranceSprite());
        blocks.Add(MainGame.SpriteHandlers.SpriteFactory.CreateStatueOneEndSprite());
        blocks.Add(MainGame.SpriteHandlers.SpriteFactory.CreateStatueTwoEndSprite());
        blocks.Add(MainGame.SpriteHandlers.SpriteFactory.CreateBlackSquareSprite());
        blocks.Add(MainGame.SpriteHandlers.SpriteFactory.CreateBlueSandSprite());
        blocks.Add(MainGame.SpriteHandlers.SpriteFactory.CreateBlueGapSprite());
        blocks.Add(MainGame.SpriteHandlers.SpriteFactory.CreateStairsSprite());
        blocks.Add(MainGame.SpriteHandlers.SpriteFactory.CreateWhiteBrickSprite());
        blocks.Add(MainGame.SpriteHandlers.SpriteFactory.CreateWhiteLadderSprite());
        }

        public List<ISprite> GetBlocks()
        {
            return blocks;
        }
    }
}