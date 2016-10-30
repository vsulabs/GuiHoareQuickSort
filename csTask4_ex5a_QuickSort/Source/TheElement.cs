using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace csTask4_ex5a_QuickSort.Source
{
    public class TheElement
    {
        public static int Speed { get; } = 4;
        public int Value { get; }

        private readonly Pen _pen =  new Pen(DrawingUtils.DefaultElemColor, 3);
        private readonly SolidBrush _brush = new SolidBrush(DrawingUtils.DefaultElemColor);
        private readonly Graphics _graphics;
        public Color BackColor { get; }     
        
        public int X { get; private set; }
        public int Y { get; private set; }
        public int UnderLine { get; }
        private Rectangle R => new Rectangle(X - DrawingUtils.Radius, Y - DrawingUtils.Radius,
            DrawingUtils.Diameter, DrawingUtils.Diameter);        

        public TheElement(Point point, int value, PictureBox picture)
        {
            Value = value;
            X = point.X;
            Y = point.Y;
            _graphics = picture.CreateGraphics();
            BackColor = picture.BackColor;
            UnderLine = picture.Height - DrawingUtils.Radius;
            SetElementColor();
            _i = 0;
        }

        public void Show()
        {
            Draw(true);
        }

        public void Hide()
        {
            Draw(false);
        }
        
        public void DefaultElement()
        {
            SetElementColor();            
        }

        public void SwapPositions(TheElement other)
        {
            var futureSeltDest = Y;
            var futureOtherDest = other.Y;

            _pen.Color = DrawingUtils.ComparingColor;
            Draw(true);
            other._pen.Color = DrawingUtils.ComparingColor;
            other.Draw(true);

            _graphics.DrawRectangle(Pens.DeepSkyBlue, X, DrawingUtils.Radius, 1, Y - DrawingUtils.Radius);
            MoveToLine(DrawingUtils.Radius);

            _graphics.DrawRectangle(Pens.DeepSkyBlue, other.X, other.Y + DrawingUtils.Radius, 1, Math.Abs(other.Y + DrawingUtils.Radius - UnderLine));
            other.MoveToLine(UnderLine);            

            var step = X < other.X ? 1 : -1;
            var diff = Math.Abs(X - other.X); // количество шагов между вершинами по горизонтали
            for (int i = 0; i < diff; ++i) {
                MoveX(step);
                other.MoveX(-step);
                Thread.Sleep(Speed - DrawingUtils.Speed);
            }
            //_graphics.DrawRectangle(Pens.OrangeRed, X, futureSeltDest + DrawingUtils.Radius, 1, UnderLine - futureSeltDest - DrawingUtils.Radius);
            //MoveToLine(DrawingUtils.Radius);
            //_graphics.DrawRectangle(Pens.OrangeRed, other.X, other.Y + DrawingUtils.Radius, 1, futureSeltDest - other.Y + DrawingUtils.Radius);
            //other.MoveToLine(UnderLine);
            MoveToLine(futureSeltDest);
            other.MoveToLine(futureOtherDest);            

            _pen.Color = DrawingUtils.DefaultElemColor;
            Draw(true);
            other._pen.Color = DrawingUtils.DefaultElemColor;                      
            other.Draw(true);
        }
        
        private void Draw(bool visible)
        {
            if (!visible) {                
                _graphics.DrawEllipse(DrawingUtils.BackPen, R);
                _graphics.FillRectangle(DrawingUtils.BackBrush, R);
                return;
            }
            _graphics.DrawEllipse(_pen, R);                        
            _graphics.DrawString(
                Value.ToString(),
                new Font("Arial", 16),   
                Brushes.Black, // _brush, 
                X - 15, Y - 10,
                new StringFormat()
                );            
        }

        public static void DrawRange(int left, int right, PictureBox pb, Color clr)
        {
            Graphics g = pb.CreateGraphics();
            left = DrawingUtils.LeftRelativePos(left);
            right = DrawingUtils.RightRelativePos(right);
            g.DrawRectangle(DrawingUtils.DrawingPen(clr), left, 0, 1, pb.Height);
            g.DrawRectangle(DrawingUtils.DrawingPen(clr), right, 0, 1, pb.Height);
            Thread.Sleep(12 * (Speed - DrawingUtils.Speed));
        }

        private void MoveX(int byX)
        {
            Hide();
            X += byX;
            Show();
        }

        private void MoveY(int byY)
        {
            Hide();
            Y += byY;
            Show();
        }

        private void MoveToLine(int line)
        {
            var step = Y < line ? 1 : -1;
            var diff = Math.Abs(Y - line); // количество шагов между вершинами по горизонтали
            for (int i = 0; i < diff; ++i) {
                MoveY(step);
                Thread.Sleep(Speed - DrawingUtils.Speed);
            }
        }

        public void BearingElement()
        {
            SetElementColor(EnDrawingColor.Bearing);
            Thread.Sleep(10 + 5 * (Speed - DrawingUtils.Speed));
        }

        public void ComparingElement()
        {
            int len = (Y - DrawingUtils.Diameter) / 2;            
            _graphics.DrawRectangle(Pens.LightSkyBlue, X, DrawingUtils.Radius, 1, len);
            for (int i = 0; i < len; ++i)
            {
                _graphics.DrawRectangle(Pens.LightSkyBlue, X, DrawingUtils.Radius + len + i, 1, 1);
                _graphics.DrawRectangle(DrawingUtils.BackPen, X, DrawingUtils.Radius + i, 1, 1);
                Thread.Sleep(Speed - DrawingUtils.Speed);
            }
            for (int i = 0; i < len; ++i)
            {                
                _graphics.DrawRectangle(DrawingUtils.BackPen, X, DrawingUtils.Radius + len + i, 1, 1);
                Thread.Sleep(Speed - DrawingUtils.Speed);
            }
            Draw(true);
        }

        public void PartitionElement()
        {
            SetElementColor(EnDrawingColor.Partition);
            Thread.Sleep(10 + 5 * (Speed - DrawingUtils.Speed));
        }

        public Color ElementColor { get; private set; }
        public int[] RbgColor { get; private set; }
        private void SetElementColor(EnDrawingColor clr = EnDrawingColor.Default)
        {
            Hide();
            switch (clr)
            {
                case EnDrawingColor.Bearing:
                    RbgColor = DrawingUtils.RgbBearing;
                    ElementColor = DrawingUtils.BearingColor;
                    _pen.Color = DrawingUtils.BearingColor;
                    _brush.Color = DrawingUtils.BearingColor;
                    break;
                case EnDrawingColor.Comparing:
                    RbgColor = DrawingUtils.RgbComparing;
                    ElementColor = DrawingUtils.ComparingColor;
                    _pen.Color = DrawingUtils.ComparingColor;
                    _brush.Color = DrawingUtils.ComparingColor;
                    break;
                case EnDrawingColor.Partition:
                    RbgColor = DrawingUtils.RgbPartition;
                    ElementColor = DrawingUtils.PartitionColor;
                    _pen.Color = DrawingUtils.PartitionColor;
                    _brush.Color = DrawingUtils.PartitionColor;
                    break;
                default:
                    RbgColor = DrawingUtils.RgbDefault;
                    ElementColor = DrawingUtils.DefaultElemColor;
                    _pen.Color = DrawingUtils.DefaultElemColor;
                    _brush.Color = DrawingUtils.DefaultElemColor;
                    break;
            }
            Show();
        }

        private int _i;
        public void EatPie()
        {
            var a = DrawingUtils.DisplayPie(_i);
            _graphics.FillPie(DrawingUtils.BackBrush, R, a[0], a[1]);
            _i = (_i + 1) % 8;
        }

        public void PointsAround()
        {
            var a = DrawingUtils.GetCircleAroundCenter(new Point(X, Y));
            for (int j = 0; j < a.Length - 1; ++j) {
                _graphics.FillEllipse(Brushes.Blue, a[_i].X, a[_i].Y, 3, 3);
                _i = (_i + 1) % a.Length;
            }
            _i = (_i + 1) % a.Length;
        }

        public void PieStyleDrawing()
        {
            _graphics.FillEllipse(_brush, R);
            _graphics.FillEllipse(DrawingUtils.BackBrush, X - 20, Y - 20, 40, 40);
            EatPie();
        }

        public void LineDawnAndHide()
        {
            _graphics.DrawRectangle(Pens.OrangeRed,
                    X, DrawingUtils.Radius,
                    1, Y - 2 * DrawingUtils.Radius - 1);
            for (int i = DrawingUtils.Radius; i < Y - DrawingUtils.Radius - 2; ++i)
            {
                _graphics.DrawRectangle(DrawingUtils.BackPen,
                    X, i,
                    1, 1);
                Thread.Sleep(Speed - DrawingUtils.Speed);
            }
        }

    }
}