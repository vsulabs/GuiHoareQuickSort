using System;
using System.Drawing;

namespace csTask4_ex5a_QuickSort.Source
{
    public enum EnDrawingColor
    {
        Background,
        Partition,
        Comparing,
        Bearing,
        Default
    }

    public static class DrawingUtils
    {
        public static int Speed { get; set; } = 0;

        #region COLORS
        public static Color BackColor { get; } = Color.FromArgb(255, 255, 255); // white
        public static int[] RgbBackground { get; } = { 255, 255, 255 };

        public static Color PartitionColor { get; } = Color.FromArgb(85, 115, 170); // RoyalBlue
        public static int[] RgbPartition { get; } = {85, 115, 170};
        
        public static Color ComparingColor { get; } = Color.FromArgb(36, 170, 225); // DeepSkyBlue
        public static int[] RgbComparing { get; } = { 36, 170, 225 };

        public static Color BearingColor { get; } = Color.FromArgb(252, 77, 102); // IndianRed
        public static int[] RgbBearing { get; } = { 252, 77, 102 };

        public static Color DefaultElemColor { get; } = Color.FromArgb(234, 167, 105); // SandyBrown
        public static int[] RgbDefault { get; } = { 234, 167, 105 };

        public static Pen BackPen { get; } = new Pen(BackColor, 3);
        public static Brush BackBrush { get; } = new SolidBrush(BackColor);

        public static Pen DrawingPen (Color clr) => new Pen(clr, 3);
        public static Brush DrawingBrush (Color clr) => new SolidBrush(clr);

        public static Pen Pen { get; set; } = new Pen(DefaultElemColor, 3);
        public static SolidBrush Brush { get; set; } = new SolidBrush(DefaultElemColor);
        #endregion

        #region Values
        public static int MaxN { get; } = 12;
        public static int Radius { get; } = 30;        
        public static int Diameter => Radius * 2;
        public static int Split => Radius / 3 * 2;  // 20
        public static int TopBorder { get; } = 10;
        public static int UnderBorder { get; } = 30;
        public static int UnderAndTopBorder => UnderBorder + TopBorder;
        #endregion

        public static int PosToX(int pos)
        {
            return pos * (Diameter + Split) + Radius + Split;            
        }

        public static int LeftRelativePos(int pos)
        {
            return PosToX(pos) - Radius - Split / 2;
        }

        public static int RightRelativePos(int pos)
        {
            return PosToX(pos) + Radius + Split / 2;
        }

        public static Point ElemetPosition(int pos, int val, int height)
        {
            height -= 2*Diameter + 2*UnderAndTopBorder;
            return new Point(PosToX(pos), Diameter + UnderAndTopBorder + height - height / 100 * val );
        }

        public static void DrawCurve(Point[] array, Graphics graphics) {                     
            graphics.DrawLines(new Pen(BearingColor), array);
        }

        public static float[] DisplayPie(int i)
        {
            switch (i)
            {
                case 0:
                    return new[] { 90f, -45f };
                case 1:
                    return new[] { 45, -45f };
                case 2:
                    return new[] { 0f, -45f };
                case 3:
                    return new[] { -45, -45f };
                case 4:
                    return new[] { -90f, -45f };
                case 5:
                    return new[] { -135f, -45f };
                case 6:
                    return new[] { -180f, -45f };
                case 7:
                    return new[] { -225f, -45f };
                default:
                    return new[] { -1f, -1f };
            }
        }

        public static Point[] GetCircleAroundCenter(Point center)
        {            
            return new[]
            {
                new Point(center.X, center.Y - Split),
                new Point(center.X + EllipseDistance, center.Y - EllipseDistance),
                new Point(center.X + Split, center.Y),
                new Point(center.X + EllipseDistance, center.Y + EllipseDistance),
                new Point(center.X, center.Y + Split),
                new Point(center.X - EllipseDistance, center.Y + EllipseDistance),
                new Point(center.X - Split, center.Y),
                new Point(center.X - EllipseDistance, center.Y - EllipseDistance)
            };
        }

        private static int EllipseDistance => Convert.ToInt32(Math.Sqrt(Math.Pow(Split, 2) / 2));
       

    }
}