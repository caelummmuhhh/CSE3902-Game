using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MainGame
{
	public static class GridHandler
	{
		public static readonly Point GridStart = new(0);
		public static readonly Point CellSize = new(16 * Constants.UniversalScale);
		public static readonly Point GridEnd = new(
            GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width,
            GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);

		public static Point SnapToGridFullStep(Point position, bool centerAlign = true)
		{
			int roundedX = (int) Math.Floor((decimal)position.X / CellSize.X) * CellSize.X;
			int roundedY = (int) Math.Floor((decimal)position.Y / CellSize.Y) * CellSize.Y;

			if (centerAlign)
			{
				roundedX += CellSize.X / 2;
				roundedY += CellSize.Y / 2; // TODO: + or - ??
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
            int halfCellWidth = CellSize.X / 2;
            int halfCellHeight = CellSize.Y / 2;

            int roundedX = (int)Math.Floor((decimal)position.X / halfCellWidth) * halfCellWidth;
            int roundedY = (int)Math.Floor((decimal)position.Y / halfCellHeight) * halfCellHeight;

            return new Point(roundedX, roundedY);
        }

        public static Point SnapToGridHalfStep(Vector2 position)
        {
            Point pointPosition = new((int)position.X, (int)position.Y);
            return SnapToGridHalfStep(pointPosition);
        }

    }
}
