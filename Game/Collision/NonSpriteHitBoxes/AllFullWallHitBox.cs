namespace MainGame.Collision
{
	public class AllFullWallHitBox : GenericHitBox
	{
		public AllFullWallHitBox()
		{
            Add(new TopFullHorizontalWallHitBox());
			Add(new RightFullVerticalWallHitBox());
            Add(new BottomFullHorizontalWallHitBox());
			Add(new LeftFullVerticalWallHitBox());
		}
	}
}

