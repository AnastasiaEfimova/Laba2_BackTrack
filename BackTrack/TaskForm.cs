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
    public partial class TaskForm : Form
    {
        public int topIndex;
        public double distance;
        public TaskForm()
        {
            InitializeComponent();
        }

        private void BtAct_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(tbTop.Text, out topIndex) && Double.TryParse(tbDistance.Text, out distance))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Введены некорректные данные!");
            }
        }
    }
}
