using System;
using System.Windows.Forms;
using csTask4_ex5a_QuickSort.Source;

namespace csTask4_ex5a_QuickSort
{
    public partial class FormMain : Form
    {
        private HoareSort _hoare;
        public FormMain()
        {
            InitializeComponent();
            pbDraw.BackColor = DrawingUtils.BackColor;
            Application.Idle += (sender, args) => btnSort.Enabled = _hoare != null;
        }

        private void btnSort_Click(object sender, EventArgs e)
        {            
            DrawingUtils.Speed = Convert.ToInt32(updwnSpeed.Value);
            _hoare?.QuickSort();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            _hoare = new HoareSort(pbDraw);
            _hoare.Clear();
            _hoare.Show();
        }

    }
}
