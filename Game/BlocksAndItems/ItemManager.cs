using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MainGame.SpriteHandlers;
using MainGame.Controllers;
using MainGame.Players;
using System.Collections.Generic;


namespace MainGame.Managers
{
    public class ItemManager
    {
        private List<ISprite> items;

        public ItemManager()
        {
            items = new List<ISprite>();
        }

        public void LoadItems()
        {
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateHeartItemSprite());
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateHeartContainerItemSprite());
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateClockItemSprite());
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateFiveRupeesItemSprite());
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateRupeeItemSprite());
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateMapItemSprite());
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateWoodenBoomerangItemSprite());
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateBombItemSprite());
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateBowItemSprite());
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateArrowItemSprite());
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateKeyItemSprite());
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateCompassItemSprite());
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateTriforcePieceItemSprite());
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateFairyItemSprite());
        items.Add(MainGame.SpriteHandlers.SpriteFactory.CreateFireSprite());
        }

        public List<ISprite> GetItems()
        {
            return items;
        }
    }
}