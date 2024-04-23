namespace MainGame.Collision
{
	public class AllDoorWallHitBox : GenericHitBox
    {
		public AllDoorWallHitBox()
		{
            Add(new TopHorizontalDoorWallHitBox());
            Add(new RightVerticalDoorWallHitBox());
            Add(new BottomHorizontalDoorWallHitBox());
            Add(new LeftVerticalDoorWallHitBox());
        }
    }
}

