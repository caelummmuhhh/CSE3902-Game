using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame
{
	public static class GridHandler
	{
		public static readonly Point GridStart = new(GameConstants.GridStartValue);
		public static readonly Point CellSize = new(GameConstants.CellSizeFactor * Constants.UniversalScale);
		public static readonly Point GridEnd = new(
            GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width,
            GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);

		public static Point SnapToGridFullStep(Point position, bool centerAlign = true)
		{
			int roundedX = (int) Math.Floor((decimal)position.X / CellSize.X) * CellSize.X;
			int roundedY = (int) Math.Floor((decimal)position.Y / CellSize.Y) * CellSize.Y;

			if (centerAlign)
			{
				roundedX += CellSize.X / GameConstants.FullStepDivisor;
				roundedY += CellSize.Y / GameConstants.FullStepDivisor; // TODO: + or - ??
			}

			return new Point(roundedX, roundedY);
        }

        public static Point SnapToGridFullStep(Vector2 position, bool centerAlign = false)
        {
            Point pointPosition = new((int)position.X, (int)position.Y);
            return SnapToGridFullStep(pointPosition, centerAlign);
        }

        public static Point SnapToGridHalfStep(Point position)
		{
            int halfCellWidth = CellSize.X / GameConstants.HalfStepDivisor;
            int halfCellHeight = CellSize.Y / GameConstants.HalfStepDivisor;

            int roundedX = (int)Math.Round((decimal)position.X / halfCellWidth) * halfCellWidth;
            int roundedY = (int)Math.Round((decimal)position.Y / halfCellHeight) * halfCellHeight;

            return new Point(roundedX, roundedY);
        }

        public static Point SnapToGridHalfStep(Vector2 position)
        {
            Point pointPosition = new((int)position.X, (int)position.Y);
            return SnapToGridHalfStep(pointPosition);
        }

    }
}
