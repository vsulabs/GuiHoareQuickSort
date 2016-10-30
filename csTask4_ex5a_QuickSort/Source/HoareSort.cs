using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace csTask4_ex5a_QuickSort.Source
{
    public class HoareSort
    {
        private readonly TheElement[] _elements;
        private readonly PictureBox _pictureBox;

        public HoareSort(PictureBox pb)
        {
            _pictureBox = pb;
            Random rnd = new Random();
            _elements = new TheElement[DrawingUtils.MaxN];
            for (int i = 0; i < _elements.Length; ++i) {
                var tmp = rnd.Next(1, 100);
                _elements[i] = new TheElement(
                    DrawingUtils.ElemetPosition(i, tmp, pb.Height), tmp, pb);
            }            
        }
        
        public void Show()
        {
            foreach (var e in _elements)
                e.Show();
        }

        public void Hide()
        {
            foreach (var e in _elements)
                e.Hide();
        }

        public void Clear()
        {
            _pictureBox.CreateGraphics().FillRectangle(DrawingUtils.DrawingBrush(DrawingUtils.BackColor), 
                0, 0, _pictureBox.Width, _pictureBox.Height);
        }

        public void QuickSort()
        {
            Clear();
            Show();
            SortRec(0, _elements.Length - 1);
            //DrawingUtils.DrawCurve(VerticesPoints(0, _elements.Length - 1), _pictureBox.CreateGraphics());            
        }

        private void SortRec(int left, int right)
        {            
            TheElement.DrawRange(left, right, _pictureBox, DrawingUtils.PartitionColor);
            // определяем границы сортируемого отрезка   
            int i = left;
            int j = right;
            int x = _elements[(left + right) / 2].Value;

            _elements[(left + right) / 2].BearingElement(); // элемент принимаем за опорный 
            do
            {
                while (_elements[i].Value < x) { // ищем слева больший элемент                                        
                    _elements[i].ComparingElement();
                    ++i;    
                }
                while (_elements[j].Value > x) { // а справа меньший                                        
                    _elements[j].ComparingElement();
                    --j;                    
                }                
                if (i <= j) { // если таковые обнаружились, меняем местами
                    Swap(i, j);
                    ++i;
                    --j;
                }
            } while (i < j);
            _elements[(left + right) / 2].DefaultElement();            
            TheElement.DrawRange(left, right, _pictureBox, DrawingUtils.BackColor); // стираем границы
                        
            if (left < j)
                SortRec(left, j);            
            if (i < right)
                SortRec(i, right);
        }

        private void Swap(int one, int two)
        {
            if (one == two || _elements[one].Value == _elements[two].Value)
                return;

            _elements[one].ComparingElement();
            _elements[two].ComparingElement();
            
            _elements[one].SwapPositions(_elements[two]);
            var tmp = _elements[one];
            _elements[one] = _elements[two];
            _elements[two] = tmp;
        }

        public Point[] VerticesPoints(int left, int right)
        {
            List<Point> list = new List<Point>();
            for (; left <= right; ++left)
                list.Add(new Point(_elements[left].X, 
                    _elements[left].Y - DrawingUtils.Radius));
            return list.ToArray();
        }

        public void Refresh()
        {
            Clear();
            Show();
        }

    }
}