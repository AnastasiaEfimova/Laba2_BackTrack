using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmilGraph
{
    public partial class EdgeForm : Form
    {
        private int maxNum;
        public Tuple<int, int, double> tuple;
        public EdgeForm(int maxNum)
        {
            InitializeComponent();
            this.maxNum = maxNum;
        }

        private void BtAct_Click(object sender, EventArgs e)
        {
            int first;
            int second;
            double distance;
            if (Int32.TryParse(tbFirst.Text, out first) && Int32.TryParse(tbSecond.Text, out second) &&
                Double.TryParse(tbDistance.Text, out distance))
            {
                if (first != second && first >= 0 && second >= 0 && first <= maxNum && second <= maxNum)
                {
                    tuple = new Tuple<int, int, double>(first, second, distance);
                    DialogResult = DialogResult.OK;
                    return;
                }
            }
            MessageBox.Show("Введеные некорректные данные!");
        }
    }
}
